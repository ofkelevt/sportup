using sportup.Models;
using System.ComponentModel.DataAnnotations;
namespace sportup.DTO
{
    public class UserDtor
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }  // Sensitive info made nullable
        public IFormFile? PictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNum { get; set; }
        public string? HomeNum { get; set; }
        public string? StreetName { get; set; }
        public string? CityName { get; set; }
        public int? Urank { get; set; }
        public string? Description { get; set; }

        // Function to convert DTO back to Users model
        public Users ToModel()
        {
            return new Users
            {
                UserId = UserId,
                Username = Username,
                Password = Password,
                PictureUrl = ConvertToByteArray(PictureUrl),
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
        public static byte[] ConvertToByteArray(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream); // Synchronous version of CopyToAsync
                return memoryStream.ToArray();
            }
        }
    }

}
