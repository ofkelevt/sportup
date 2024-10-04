using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace sportup.Models
{
    public class UserToEvent
    {
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Column(Order = 1)]
        public int EventId { get; set; }

        [Key, Column (Order = 2)]
        public int TableId { get; set; }
        // Navigation Properties
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
