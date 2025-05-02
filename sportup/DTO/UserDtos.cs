using sportup.Models;
using System.ComponentModel.DataAnnotations;
namespace sportup.DTO
{
    public class UserDtos
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
        public UserDtos() { }
        public UserDtos(Users user)
        {
            UserId = user.UserId;
            Username = user.Username;
            Password = null;  // Hide sensitive data
            PictureUrl = ConvertToBase64(user.PictureUrl);
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
        public static string ConvertToBase64(byte[] data)
        {
            if (data == null || data.Length == 0)
                return null;

            return Convert.ToBase64String(data);
        }
    }

}
