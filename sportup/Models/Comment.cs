using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int CommenterId { get; set; }

        public int CommentedOnId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Range(1, 5)]
        public int Rating { get; set; }

        // Navigation Properties
        [ForeignKey("CommenterId")]
        public User Commenter { get; set; }

        [ForeignKey("CommentedOnId")]
        public User CommentedOn { get; set; }
    }
}
