using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{

    [Table("report")]
    public class Report
    {
        [Key]
        [Column("report_id")]
        public int ReportId { get; set; }

        [ForeignKey("User")]
        [Column("reporter_id")]
        public int ReporterId { get; set; }

        [ForeignKey("User")]
        [Column("target_id")]
        public int TargetId { get; set; }

        [Column("comment")]
        public string? CommentText { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [Required]
        public Users Reporter { get; set; }
        [Required]
        public Users Target { get; set; }
    }

}
