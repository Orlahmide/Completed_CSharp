using DataAccess.Repositories;
using DataAccessLayer.Repository;

namespace BlogApp.DataAccess.Abstractions
{
    /// <summary>
    /// Represents the Unit of Work pattern for coordinating repository operations and managing transactions.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the user repository for managing user-related data operations.
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Gets the post repository for managing post-related data operations.
        /// </summary>
        IPostRepository Posts { get; }

        /// <summary>
        /// Gets the like repository for managing like-related data operations.
        /// </summary>
        ILikeRepository Likes { get; }

        /// <summary>
        /// Gets the comment repository for managing comment-related data operations.
        /// </summary>
        ICommentRepository Comment { get; }

        /// <summary>
        /// Saves all changes made within the unit of work to the database.
        /// </summary>
        void Save();
    }
}
