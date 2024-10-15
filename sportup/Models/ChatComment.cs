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

        [Required]
        public int CommenterId { get; set; }

        [Required]
        public int EventId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public Users Commenter { get; set; }
        public Event Event { get; set; }
    }

}
