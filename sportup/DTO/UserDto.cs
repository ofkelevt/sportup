using sportup.Models;
using System.ComponentModel.DataAnnotations;
namespace sportup.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }  // Sensitive info made nullable
        public string? PictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNum { get; set; }
        public string? HomeNum { get; set; }
        public string? StreetName { get; set; }
        public string? CityName { get; set; }
        public int? Urank { get; set; }
        public string? Description { get; set; }

        // Empty constructor
        public UserDto() { }

        // Constructor that takes a Users model
        public UserDto(User user)
        {
            UserId = user.UserId;
            Username = user.Username;
            Password = null;  // Hide sensitive data
            PictureUrl = user.PictureUrl;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNum = user.PhoneNum;
            HomeNum = user.HomeNum;
            StreetName = user.StreetName;
            CityName = user.CityName;
            Urank = user.Urank;
            Description = user.Description;
        }

        // Function to convert DTO back to Users model
        public User ToModel()
        {
            return new User
            {
                UserId = UserId,
                Username = Username,
                Password = Password,
                PictureUrl = PictureUrl,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNum = PhoneNum,
                HomeNum = HomeNum,
                StreetName = StreetName,
                CityName = CityName,
                Urank = Urank,
                Description = Description
            };
        }
    }

}
