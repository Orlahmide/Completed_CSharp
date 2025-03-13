using DomainLayer.Models;

namespace BusinessLogic.Interfaces
{
    public interface ILikeService
    {
        /// <summary>
        /// Retrieves all likes associated with a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>A collection of Like objects for the given post.</returns>
        IEnumerable<Like> GetLikesByPostId(int postId);

        /// <summary>
        /// Adds a like to a post from a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user who liked the post.</param>
        /// <param name="postId">The ID of the post being liked.</param>
        void AddLike(int userId, int postId);

        /// <summary>
        /// Removes a like from a post for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user who unliked the post.</param>
        /// <param name="postId">The ID of the post being unliked.</param>
        void RemoveLike(int userId, int postId);

        /// <summary>
        /// Retrieves the total number of likes for a specific post.
        /// </summary>
        /// <param name="postId">The ID of the post.</param>
        /// <returns>The total count of likes for the given post.</returns>
        int GetLikeCountByPostId(int postId);
    }
}
