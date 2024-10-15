using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace sportup.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string PictureUrl { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string PhoneNum { get; set; }

        [MaxLength(10)]
        public string HomeNum { get; set; }

        [MaxLength(100)]
        public string StreetName { get; set; }

        [MaxLength(50)]
        public string CityName { get; set; }

        public int? Urank { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public ICollection<Event> CreatedEvents { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ChatComment> ChatComments { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<UserToEvent> UserEvents { get; set; }
    }

}
