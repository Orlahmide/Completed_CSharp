using AutoMapper;
using BlogApp.DataAccess.Abstractions;
using BusinessLogic.Interfaces;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;

namespace BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Comment GetCommentById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid comment ID.", nameof(id));

            var comment = _unitOfWork.Comment.GetById(id);
            return comment ?? throw new KeyNotFoundException("Comment not found.");
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _unitOfWork.Comment.GetAll();
        }

        public CommentResponse AddComment(CreateCommentDto createCommentDto)
        {
            if (createCommentDto == null)
                throw new ArgumentNullException(nameof(createCommentDto));

            if (string.IsNullOrWhiteSpace(createCommentDto.Content))
                throw new ArgumentException("Content is required.", nameof(createCommentDto.Content));

            if (_unitOfWork.Posts.GetById(createCommentDto.PostId) == null)
                throw new KeyNotFoundException("Post not found.");

            if (_unitOfWork.Users.GetById(createCommentDto.UserId) == null)
                throw new KeyNotFoundException("User not found.");

            var comment = new Comment
            {
                Content = createCommentDto.Content,
                PostId = createCommentDto.PostId,
                UserId = createCommentDto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Save();

            return new CommentResponse
            {
                commentId = comment.Id,
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
                CreatedAt = comment.CreatedAt
            };
        }

        public CommentResponse UpdateComment(CommentResponse commentResponse)
        {
            if (commentResponse == null)
                throw new ArgumentNullException(nameof(commentResponse));

            if (commentResponse.commentId <= 0)
                throw new ArgumentException("Invalid comment ID.", nameof(commentResponse.commentId));

            if (string.IsNullOrWhiteSpace(commentResponse.Content))
                throw new ArgumentException("Content is required.", nameof(commentResponse.Content));

            var existingComment = _unitOfWork.Comment.GetById(commentResponse.commentId);
            if (existingComment == null)
                throw new KeyNotFoundException("Comment not found.");

            existingComment.Content = commentResponse.Content;
            existingComment.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Comment.Update(existingComment);
            _unitOfWork.Save();

            return _mapper.Map<CommentResponse>(existingComment);
        }

        public void DeleteComment(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid comment ID.", nameof(id));

            var comment = _unitOfWork.Comment.GetById(id);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found.");

            _unitOfWork.Comment.Remove(comment);
            _unitOfWork.Save();
        }

        public IEnumerable<CommentResponse> GetCommentsByPostId(int postId)
        {
            if (postId <= 0)
                throw new ArgumentException("Invalid post ID.", nameof(postId));

            if (_unitOfWork.Posts.GetById(postId) == null)
                throw new KeyNotFoundException("Post not found.");

            var comments = _unitOfWork.Comment.GetByPostId(postId);

            return comments.Select(comment => new CommentResponse
            {
                commentId = comment.Id,
                Content = comment.Content,
                UserId = comment.UserId,
                PostId = comment.PostId,
                CreatedAt = comment.CreatedAt
            });
        }
    }
}
