using DataAccessLayer.Data;
using DomainLayer.Models;

namespace DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Comment GetById(int id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Comment> GetByPostId(int postId)
        {
            return _context.Comments
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
        }

        public void Add(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Update(comment);
        }

        public void Remove(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Remove(comment);
        }

        public int CountByPostId(int postId)
        {
            return _context.Comments.Count(c => c.PostId == postId);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
        }

    }
}
