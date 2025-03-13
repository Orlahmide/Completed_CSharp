using BlogApp.DataAccess.Abstractions;
using BlogApp.DataAccess.Repositories;
using DataAccess.Repositories;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;

namespace BlogApp.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
        public ILikeRepository Likes { get; }
        public ICommentRepository Comment { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Posts = new PostRepository(_context);
            Likes = new LikeRepository(_context);
            Comment = new CommentRepository(_context);
        }

        public void Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
