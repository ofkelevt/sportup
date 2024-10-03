using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [MaxLength(10)]
        public string HomeNum { get; set; }

        [MaxLength(100)]
        public string StreetName { get; set; }

        [MaxLength(50)]
        public string CityName { get; set; }

        [MaxLength(255)]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sport { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? EndsAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string EventName { get; set; }

        // Navigation Properties
        public ICollection<UserToEvent> UserToEvents { get; set; }
        public ICollection<ChatComment> ChatComments { get; set; }
    }

}
