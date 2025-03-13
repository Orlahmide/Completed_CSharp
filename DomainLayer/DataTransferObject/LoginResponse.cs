namespace DomainLayer.DataTransferObject
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }

        public required string Token { get; set; }
    }
}
