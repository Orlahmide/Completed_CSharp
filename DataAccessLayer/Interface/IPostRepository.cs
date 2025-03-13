using DomainLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public interface IPostRepository
    {
        /// <summary>
        /// Retrieves a post by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the post.</param>
        /// <returns>The Post object if found; otherwise, null.</returns>
        Post GetById(int id);

        /// <summary>
        /// Retrieves all posts from the database.
        /// </summary>
        /// <returns>A collection of all Post objects.</returns>
        IEnumerable<Post> GetAll();

        /// <summary>
        /// Finds posts that match the specified criteria.
        /// </summary>
        /// <param name="predicate">An expression used to filter posts.</param>
        /// <returns>A collection of Post objects matching the given criteria.</returns>
        IEnumerable<Post> Find(Expression<Func<Post, bool>> predicate);

        /// <summary>
        /// Adds a new post to the database.
        /// </summary>
        /// <param name="post">The Post object to be added.</param>
        void Add(Post post);

        /// <summary>
        /// Updates an existing post in the database.
        /// </summary>
        /// <param name="post">The Post object with updated data.</param>
        void Update(Post post);

        /// <summary>
        /// Removes a post from the database.
        /// </summary>
        /// <param name="post">The Post object to be removed.</param>
        void Remove(Post post);

        /// <summary>
        /// Retrieves all posts with their related details (e.g., comments, likes, author).
        /// </summary>
        /// <returns>A collection of Post objects with additional details.</returns>
        IEnumerable<Post> GetPostsWithDetails();

    }
}
