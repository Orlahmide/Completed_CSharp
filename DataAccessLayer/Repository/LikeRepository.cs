using DataAccessLayer.Repository;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogApp.DataAccess.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DbContext _context;

        public LikeRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Like GetById(int id) =>
            _context.Set<Like>()
                .Include(l => l.User)
                .Include(l => l.Post)
                .FirstOrDefault(l => l.Id == id);

        public IEnumerable<Like> GetAll() =>
            _context.Set<Like>()
                .Include(l => l.User)
                .Include(l => l.Post)
                .ToList();

        public IEnumerable<Like> Find(Expression<Func<Like, bool>> predicate) =>
            _context.Set<Like>()
                .Where(predicate)
                .Include(l => l.User)
                .Include(l => l.Post)
                .ToList();

        public void Add(Like like)
        {
            if (like == null)
                throw new ArgumentNullException(nameof(like));

            _context.Set<Like>().Add(like);
        }

        public void Update(Like like)
        {
            if (like == null)
                throw new ArgumentNullException(nameof(like));

            _context.Set<Like>().Update(like);
        }

        public void Remove(Like like)
        {
            if (like == null)
                throw new ArgumentNullException(nameof(like));

            _context.Set<Like>().Remove(like);
        }

        public int CountByPostId(int postId) =>
            _context.Set<Like>().Count(l => l.PostId == postId);
    }
}
