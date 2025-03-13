namespace DomainLayer.DataTransferObject
{
    public class CommentResponse
    {


        public int commentId { get; set; }
        public required int UserId { get; set; }
        public required string Content { get; set; }
        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
