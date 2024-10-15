using sportup.Models;

namespace sportup.DTO
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int CommenterId { get; set; }
        public int CommentedOnId { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }

        public CommentDto() { }

        public CommentDto(Comment comment)
        {
            CommentId = comment.CommentId;
            CommenterId = comment.CommenterId;
            CommentedOnId = comment.CommentedOnId;
            CommentText = comment.CommentText;
            CreatedAt = comment.CreatedAt;
            Rating = comment.Rating;
        }

        public Comment ToModel()
        {
            return new Comment
            {
                CommentId = CommentId,
                CommenterId = CommenterId,
                CommentedOnId = CommentedOnId,
                CommentText = CommentText,
                CreatedAt = CreatedAt,
                Rating = Rating
            };
        }
    }

}
