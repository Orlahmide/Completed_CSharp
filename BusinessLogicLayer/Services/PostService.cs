using AutoMapper;
using BlogApp.DataAccess.Abstractions;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;

namespace BusinessLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public PostResponse GetPostById(int id)
        {
            var post = _unitOfWork.Posts.GetById(id);
            if (post == null)
                throw new KeyNotFoundException("Post not found.");

            var comments = _unitOfWork.Comment.GetByPostId(post.Id)
                .Select(c => new CommentDto
                {
                    Content = c.Content,
                    UserId = c.UserId,
                    PostId = c.PostId,
                    CreatedAt = c.CreatedAt,
                })
                .ToList();

            int likeCount = _unitOfWork.Likes.CountByPostId(post.Id);

            var postResponse = new PostResponse
            {
                Id = post.Id,
                UserId = post.UserId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Comments = comments,
                LikeCount = likeCount
            };

            return postResponse;
        }

        public IEnumerable<PostResponse> GetAllPosts()
        {
            var posts = _unitOfWork.Posts.GetAll();
            return posts.Select(post =>
            {
                var comments = _unitOfWork.Comment.GetByPostId(post.Id)
                    .Select(c => _mapper.Map<CommentDto>(c))
                    .ToList();

                int likeCount = _unitOfWork.Likes.CountByPostId(post.Id);

                var postResponse = _mapper.Map<PostResponse>(post);
                postResponse.Comments = comments;
                postResponse.LikeCount = likeCount;

                return postResponse;
            }).ToList();
        }

        public PostResponse AddPost(PostRequest postRequest)
        {
            if (string.IsNullOrWhiteSpace(postRequest.Title) || string.IsNullOrWhiteSpace(postRequest.Content))
            {
                throw new ArgumentException("Title and content are required.");
            }

            var user = _unitOfWork.Users.GetById(postRequest.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var post = new Post
            {
                Title = postRequest.Title,
                Content = postRequest.Content,
                UserId = postRequest.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _unitOfWork.Posts.Add(post);
            _unitOfWork.Save();

            return new PostResponse
            {
                Title = post.Title,
                Content = post.Content,
                UserId = post.UserId,
                Id = post.Id,
                CreatedAt = post.CreatedAt
            };
        }

        public PostResponse UpdatePost(UpdatePostDto updatePostDto)
        {
            if (string.IsNullOrWhiteSpace(updatePostDto.Title) || string.IsNullOrWhiteSpace(updatePostDto.Content))
            {
                throw new ArgumentException("Title and content are required.");
            }

            var existingPost = _unitOfWork.Posts.GetById(updatePostDto.Id);
            if (existingPost == null)
            {
                throw new KeyNotFoundException("Post not found.");
            }

            existingPost.Title = updatePostDto.Title;
            existingPost.Content = updatePostDto.Content;
            existingPost.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Posts.Update(existingPost);
            _unitOfWork.Save();

            return new PostResponse
            {
                Id = existingPost.Id,
                Title = existingPost.Title,
                Content = existingPost.Content,
                UpdatedAt = existingPost.UpdatedAt
            };
        }

        public void DeletePost(int id)
        {
            var post = _unitOfWork.Posts.GetById(id);
            if (post == null)
            {
                throw new KeyNotFoundException("Post not found.");
            }

            _unitOfWork.Posts.Remove(post);
            _unitOfWork.Save();
        }
    }
}
