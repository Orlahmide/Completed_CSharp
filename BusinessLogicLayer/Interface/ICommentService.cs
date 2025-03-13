using DomainLayer.DataTransferObject;
using DomainLayer.Models;

namespace BusinessLogic.Interfaces
{
    /// <summary>
    /// Provides methods to manage comments.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Retrieves a comment by its ID.
        /// </summary>
        /// <param name="id">The ID of the comment.</param>
        /// <returns>The comment object.</returns>
        Comment GetCommentById(int id);

        /// <summary>
        /// Retrieves all comments.
        /// </summary>
        /// <returns>A collection of all comments.</returns>
        IEnumerable<Comment> GetAllComments();

        /// <summary>
        /// Adds a new comment.
        /// </summary>
        /// <param name="comment">The comment object to add.</param>
        CommentResponse AddComment(CreateCommentDto createCommentDto);

        /// <summary>
        /// Updates an existing comment.
        /// </summary>
        /// <param name="id">The ID of the comment to update.</param>
        /// <param name="content">The new content of the comment.</param>
        CommentResponse UpdateComment(CommentResponse commentResponse);

        /// <summary>
        /// Deletes a comment by its ID.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        void DeleteComment(int id);

        /// <summary>
        /// Retrieves comments for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of comments for the specified post.</returns>
        IEnumerable<CommentResponse> GetCommentsByPostId(int postId);
    }
}
