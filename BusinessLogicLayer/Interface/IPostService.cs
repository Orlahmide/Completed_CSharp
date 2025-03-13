using DomainLayer.DataTransferObject;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Defines the contract for post-related operations.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Retrieves a post by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post.</param>
        /// <returns>A <see cref="PostResponse"/> containing post details.</returns>
        PostResponse? GetPostById(int id);

        /// <summary>
        /// Retrieves all posts.
        /// </summary>
        /// <returns>A collection of <see cref="PostResponse"/>.</returns>
        IEnumerable<PostResponse> GetAllPosts();

        /// <summary>
        /// Adds a new post.
        /// </summary>
        /// <param name="postRequest">The post request object containing necessary data.</param>
        /// <returns>A <see cref="PostResponse"/> representing the newly created post.</returns>
        PostResponse AddPost(PostRequest postRequest);

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="postRequest">The updated post request data.</param>
        /// <returns>A <see cref="PostResponse"/> with updated post details.</returns>
        PostResponse UpdatePost(UpdatePostDto updatePostDto);

        /// <summary>
        /// Deletes a post by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the post to delete.</param>
        void DeletePost(int id);
    }
}
