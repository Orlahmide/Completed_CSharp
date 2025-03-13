using DomainLayer.Models;

namespace DataAccess.Repositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Retrieves a comment by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the comment.</param>
        /// <returns>The comment if found; otherwise, null.</returns>
        Comment GetById(int id);

        /// <summary>
        /// Retrieves all comments associated with a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of comments for the given post.</returns>
        IEnumerable<Comment> GetByPostId(int postId);

        /// <summary>
        /// Adds a new comment to the database.
        /// </summary>
        /// <param name="comment">The comment entity to add.</param>
        void Add(Comment comment);

        /// <summary>
        /// Updates an existing comment in the database.
        /// </summary>
        /// <param name="comment">The comment entity with updated values.</param>
        void Update(Comment comment);



        /// <summary>
        /// Removes a comment from the database.
        /// </summary>
        /// <param name="comment">The comment entity to remove.</param>
        void Remove(Comment comment);

        /// <summary>
        /// Gets the total number of comments for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>The count of comments.</returns>
        int CountByPostId(int postId);

        /// <summary>
        /// Gets all comment from the database.
        /// </summary>
        IEnumerable<Comment> GetAll();

    }
}
