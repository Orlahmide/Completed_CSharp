using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogApp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public User GetById(int id) => _context.Set<User>().Find(id);

        public IEnumerable<User> GetAll() => _context.Set<User>().ToList();

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate) =>
            _context.Set<User>().Where(predicate).ToList();

        public void Add(User entity) => _context.Set<User>().Add(entity);

        public void Update(User entity) => _context.Set<User>().Update(entity);

        public void Remove(User entity) => _context.Set<User>().Remove(entity);
    }
}
