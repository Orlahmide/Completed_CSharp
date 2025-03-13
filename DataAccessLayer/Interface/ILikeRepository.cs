using DomainLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public interface ILikeRepository
    {
        /// <summary>
        /// Retrieves a like by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the like.</param>
        /// <returns>The Like object if found; otherwise, null.</returns>
        Like GetById(int id);

        /// <summary>
        /// Retrieves all likes in the system.
        /// </summary>
        /// <returns>A collection of all Like objects.</returns>
        IEnumerable<Like> GetAll();

        /// <summary>
        /// Finds likes that match the specified criteria.
        /// </summary>
        /// <param name="predicate">An expression to filter likes.</param>
        /// <returns>A collection of likes matching the given criteria.</returns>
        IEnumerable<Like> Find(Expression<Func<Like, bool>> predicate);

        /// <summary>
        /// Adds a new like to the database.
        /// </summary>
        /// <param name="like">The like object to be added.</param>
        void Add(Like like);

        /// <summary>
        /// Updates an existing like in the database.
        /// </summary>
        /// <param name="like">The like object with updated data.</param>
        void Update(Like like);

        /// <summary>
        /// Removes a like from the database.
        /// </summary>
        /// <param name="like">The like object to be removed.</param>
        void Remove(Like like);

        /// <summary>
        /// Retrieves the total number of likes for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>The total count of likes for the given post.</returns>
        int CountByPostId(int postId);

    }
}
