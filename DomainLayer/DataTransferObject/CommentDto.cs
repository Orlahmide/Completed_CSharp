namespace DomainLayer.DataTransferObject
{
    public class CommentDto
    {
        public int UserId { get; set; }
        public required string Content { get; set; }
        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
