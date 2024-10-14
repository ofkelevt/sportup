using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace sportup.Models
{
    public class UserToEvent
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EventId { get; set; }

        [MaxLength(8)]
        public string RealtionshipType { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Event Event { get; set; }
    }

}
