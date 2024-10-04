namespace sportup.Dtos
{
    public class ChatCommentDto
    {
        public int ChatCommentId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public Models.ChatComment ToModelsChatComment(ChatCommentDto dto)
        {
            return new Models.ChatComment()
            {
                CommentId = dto.ChatCommentId,
                CommenterId = dto.UserId,
                CommentText = dto.CommentText,
                CreatedAt = dto.CreatedAt
            };
        }

        // Empty builder
        public ChatCommentDto() { }

        // Builder that accepts a ChatComment model
        public ChatCommentDto(Models.ChatComment chatComment)
        {
            ChatCommentId = chatComment.CommentId;
            UserId = chatComment.CommenterId;
            CommentText = chatComment.CommentText;
            CreatedAt = chatComment.CreatedAt;
        }
    }
}
