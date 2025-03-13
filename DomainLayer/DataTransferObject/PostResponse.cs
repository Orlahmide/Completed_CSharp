using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DataTransferObject
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // New properties
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public int LikeCount { get; set; }
    }

}
