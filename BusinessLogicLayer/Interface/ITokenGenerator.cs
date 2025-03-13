namespace BusinessLogicLayer.Interface
{
    /// <summary>
    /// Defines a contract for generating authentication tokens.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates a token for the specified user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <returns>A JWT or other token representing the user's authentication.</returns>
        string GenerateToken(string userId, string email);
    }
}
