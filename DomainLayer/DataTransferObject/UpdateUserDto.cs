using DomainLayer.Models;

namespace DomainLayer.DataTransferObject
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }

        public DateTime UpdatedAt { get; set; }
        public string Password { get; set; }
    }
}
