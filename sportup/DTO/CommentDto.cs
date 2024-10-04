using sportup.Models;

namespace sportup.DTO
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int CommenterId { get; set; }
        public int CommentedOnId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public Models.Comment ToModelsComment()
        {
            return new Models.Comment()
            {
                CommentId = CommentId,
                CommenterId = CommenterId,
                CommentedOnId = CommentedOnId,
                CommentText = CommentText,
                CreatedAt = CreatedAt,
                Rating = Rating
            };
        }

        public                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        CommentDto() { }
        public CommentDto(Models.Comment modelComment)
        {
            this.CommentId = modelComment.CommentId;
            this.CommenterId = modelComment.CommenterId;
            this.CommentedOnId = modelComment.CommentedOnId;
            this.CommentText = modelComment.CommentText;
            this.CreatedAt = modelComment.CreatedAt;
            this.Rating = modelComment.Rating;
        }
    }
}
