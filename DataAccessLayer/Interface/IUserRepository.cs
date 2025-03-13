using DomainLayer.Models;
using System.Linq.Expressions;

public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by their unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The User object if found; otherwise, null.</returns>
    User GetById(int id);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A collection of all User objects.</returns>
    IEnumerable<User> GetAll();

    /// <summary>
    /// Finds users that match the specified criteria.
    /// </summary>
    /// <param name="predicate">An expression used to filter users.</param>
    /// <returns>A collection of User objects matching the given criteria.</returns>
    IEnumerable<User> Find(Expression<Func<User, bool>> predicate);

    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="entity">The User object to be added.</param>
    void Add(User entity);

    /// <summary>
    /// Updates an existing user in the database.
    /// </summary>
    /// <param name="entity">The User object with updated data.</param>
    void Update(User entity);

    /// <summary>
    /// Removes a user from the database.
    /// </summary>
    /// <param name="entity">The User object to be removed.</param>
    void Remove(User entity);


}
