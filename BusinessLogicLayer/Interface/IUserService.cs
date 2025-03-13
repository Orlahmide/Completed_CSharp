using DomainLayer.DataTransferObject;
using DomainLayer.Models;
using DomainLayer.NewFolder;

namespace BusinessLogic.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Retrieves a user by their unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        UserResponseDto GetUserById(int id);

        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        IEnumerable<UserResponseDto> GetAllUsers();

        /// <summary>
        /// Creates a new user based on the provided data.
        /// </summary>
        /// <param name="createUserDto">The data transfer object containing user details.</param>
        /// <returns>A response DTO containing the newly created user details.</returns>
        UserResponseDto AddUser(CreateUserDto createUserDto, Role role);

        /// <summary>
        /// Updates an existing user's details.
        /// </summary>
        /// <param name="updateUserDto">The data transfer object containing updated user details.</param>
        /// <returns>A response DTO with the updated user details.</returns>
        UserResponseDto UpdateUser(UpdateUserDto updateUserDto);

        /// <summary>
        /// Deletes a user by their unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user to be deleted.</param>
        void DeleteUser(int id);

        /// <summary>
        /// Authenticates a user based on provided login credentials.
        /// </summary>
        /// <param name="loginDto">The login data transfer object containing email and password.</param>
        /// <returns>A response DTO containing user details if authentication is successful; otherwise, null.</returns>
        LoginResponse Login(LoginDto loginDto);
    }
}
