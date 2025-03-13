using AutoMapper;
using BlogApp.DataAccess.Abstractions;
using BusinessLogic.Interfaces;
using DomainLayer.Models;

namespace BusinessLogic.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Like> GetLikesByPostId(int postId)
        {
            if (postId <= 0)
                throw new ArgumentException("Invalid post ID.", nameof(postId));

            return _unitOfWork.Likes.Find(l => l.PostId == postId);
        }

        public int GetLikeCountByPostId(int postId)
        {
            if (postId <= 0)
                throw new ArgumentException("Invalid post ID.", nameof(postId));

            return _unitOfWork.Likes.CountByPostId(postId);
        }

        public void AddLike(int userId, int postId)
        {
            if (userId <= 0 || postId <= 0)
                throw new ArgumentException("Invalid user or post ID.");

            if (_unitOfWork.Posts.GetById(postId) == null)
                throw new KeyNotFoundException("Post not found.");

            if (_unitOfWork.Users.GetById(userId) == null)
                throw new KeyNotFoundException("User not found.");

            if (_unitOfWork.Likes.Find(l => l.UserId == userId && l.PostId == postId).Any())
                throw new InvalidOperationException("User has already liked this post.");

            var like = new Like
            {
                UserId = userId,
                PostId = postId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _unitOfWork.Likes.Add(like);
            _unitOfWork.Save();
        }

        public void RemoveLike(int userId, int postId)
        {
            if (userId <= 0 || postId <= 0)
                throw new ArgumentException("Invalid user or post ID.");

            var like = _unitOfWork.Likes.Find(l => l.UserId == userId && l.PostId == postId).FirstOrDefault();
            if (like == null)
                throw new KeyNotFoundException("Like not found.");

            _unitOfWork.Likes.Remove(like);
            _unitOfWork.Save();
        }
    }
}
