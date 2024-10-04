using sportup.Models;
using System.ComponentModel.DataAnnotations;
namespace sportup.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PictureUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNum { get; set; }

        public string HomeNum { get; set; }

        public string StreetName { get; set; }

        public string CityName { get; set; }

        public int? URank { get; set; }

        public string Description { get; set; }

        public Models.User ToModelsUser()
        {
            return new Models.User() { UserId = UserId,Username = Username, Password = Password,PictureUrl = PictureUrl,FirstName = FirstName,
                LastName = LastName, PhoneNum = PhoneNum,HomeNum = HomeNum, StreetName = StreetName, CityName = CityName, URank = URank, Description = Description};
        }

        public UserDTO() { }
        public UserDTO(Models.User modelUser)
        {
            this.UserId = modelUser.UserId;
            this.Username = modelUser.Username;
            this.Password = modelUser.Password;
            this.PictureUrl = modelUser.PictureUrl;
            this.FirstName = modelUser.FirstName;
            this.LastName = modelUser.LastName;
            this.PhoneNum = modelUser.PhoneNum;
            this.HomeNum = modelUser.HomeNum;
            this.StreetName = modelUser.StreetName;
            this.CityName = modelUser.CityName;
            this.URank = modelUser.URank;
            this.Description = modelUser.Description;
        }
    }
}
