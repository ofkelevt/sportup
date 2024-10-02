using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace sportup.Models
{
    public class UserToEvent
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int EventId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
