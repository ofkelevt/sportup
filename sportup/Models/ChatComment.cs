using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{
    public class ChatComment
    {
        [Key]
        public int CommentId { get; set; }

        public int CommenterId { get; set; }

        public int EventId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("CommenterId")]
        public User Commenter { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }


}
