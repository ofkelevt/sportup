using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        public int ReporterId { get; set; }

        public int TargetId { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("ReporterId")]
        public User Reporter { get; set; }

        [ForeignKey("TargetId")]
        public User Target { get; set; }
    }
}
