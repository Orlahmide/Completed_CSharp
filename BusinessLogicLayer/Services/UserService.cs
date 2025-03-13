using BlogApp.DataAccess.Abstractions;
using BusinessLogicLayer.Interface;
using DomainLayer.DataTransferObject;
using DomainLayer.Models;
using DomainLayer.NewFolder;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public UserResponseDto GetUserById(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return new UserResponseDto
            {
                Email = user.Email,
                Username = user.Username,
                Id = user.Id,
                CreatedAt = user.CreatedAt
            };
        }

        public IEnumerable<UserResponseDto> GetAllUsers()
        {
            var users = _unitOfWork.Users.GetAll();

            return users.Select(user => new UserResponseDto
            {
                Email = user.Email,
                Username = user.Username,
                Id = user.Id,
                CreatedAt = user.CreatedAt
            });
        }

        public UserResponseDto AddUser(CreateUserDto createUserDto, Role role)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.Username) ||
                string.IsNullOrWhiteSpace(createUserDto.Email) ||
                string.IsNullOrWhiteSpace(createUserDto.Password))
            {
                throw new Exception("All fields are required.");
            }

            // Check if a user with the same email already exists
            var existingUser = _unitOfWork.Users.Find(u => u.Email == createUserDto.Email);
            if (existingUser.Any())
            {
                throw new Exception("A user with this email already exists.");
            }

            // Create a new User from the CreateUserDto
            var user = new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                role = role,
                Password = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password)
            };

            // Add the new user to the repository
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();

            // Map the User entity to a UserResponseDto to return to the client
            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.role,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public UserResponseDto UpdateUser(UpdateUserDto updateUserDto)
        {
            var existingUser = _unitOfWork.Users.GetById(updateUserDto.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

            existingUser.Username = updateUserDto.Username;
            existingUser.Email = updateUserDto.Email;
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);
            existingUser.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Users.Update(existingUser);
            _unitOfWork.Save();

            return new UserResponseDto
            {
                Id = existingUser.Id,
                Username = existingUser.Username,
                Email = existingUser.Email,
                CreatedAt = existingUser.CreatedAt,
                UpdatedAt = existingUser.UpdatedAt
            };
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            _unitOfWork.Users.Remove(user);
            _unitOfWork.Save();
        }

        public LoginResponse? Login(LoginDto loginDto)
        {
            var user = _unitOfWork.Users.Find(u => u.Email == loginDto.Email).FirstOrDefault();

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null; // Authentication failed
            }

            // Generate JWT token using TokenGenerator
            var token = _tokenGenerator.GenerateToken(user.Id.ToString(), user.Email);

            return new LoginResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token // Return token with response
            };
        }
    }
}
