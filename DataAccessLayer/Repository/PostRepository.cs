using DataAccessLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Post? GetById(int id)
        {
            return _context.Posts
                .Include(p => p.user)         // Include User details
                .Include(p => p.Comments)     // Include related Comments
                .Include(p => p.Likes)        // Include related Likes
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(p => p.user)
                .ToList();
        }

        public IEnumerable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            return _context.Posts
                .Where(predicate)
                .Include(p => p.user)
                .ToList();
        }

        public void Add(Post post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            _context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            _context.Posts.Update(post);
        }

        public void Remove(Post post)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            _context.Posts.Remove(post);
        }

        public IEnumerable<Post> GetPostsWithDetails()
        {
            return _context.Posts
                .Include(p => p.user)         // Include User
                .Include(p => p.Comments)     // Include Comments
                .Include(p => p.Likes)        // Include Likes
                .ToList();
        }

    }
}
