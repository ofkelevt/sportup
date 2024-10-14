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

        [Required]
        public int CommenterId { get; set; }

        [Required]
        public int CommentedOnId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Range(1, 5)]
        public int Rating { get; set; }

        // Navigation Properties
        public User Commenter { get; set; }
        public User CommentedOn { get; set; }
    }

}
