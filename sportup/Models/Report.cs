using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public int ReporterId { get; set; }

        [Required]
        public int TargetId { get; set; }

        public string? CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [Required]
        public Users Reporter { get; set; }
        [Required]
        public Users Target { get; set; }
    }

}
