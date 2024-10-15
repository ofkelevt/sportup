using sportup.Models;

namespace sportup.Dtos
{
    public class ChatCommentDto
    {
        public int CommentId { get; set; }
        public int CommenterId { get; set; }
        public int EventId { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedAt { get; set; }

        public ChatCommentDto() { }

        public ChatCommentDto(ChatComment chatComment)
        {
            CommentId = chatComment.CommentId;
            CommenterId = chatComment.CommenterId;
            EventId = chatComment.EventId;
            CommentText = chatComment.CommentText;
            CreatedAt = chatComment.CreatedAt;
        }

        public ChatComment ToModel()
        {
            return new ChatComment
            {
                CommentId = CommentId,
                CommenterId = CommenterId,
                EventId = EventId,
                CommentText = CommentText,
                CreatedAt = CreatedAt
            };
        }
    }

}
