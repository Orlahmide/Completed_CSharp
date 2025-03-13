using DomainLayer.Models;

namespace DomainLayer.NewFolder
{
    public class CreateUserDto
    {

        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        //public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
