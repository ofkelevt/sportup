using Humanizer;
using sportup.Models;
using System.ComponentModel.DataAnnotations;

namespace sportup.DTO
{
    public class EventDtor
    {
        public int EventId { get; set; }
        public string? HomeNum { get; set; }
        public string? StreetName { get; set; }
        public string? CityName { get; set; }
        public IFormFile? PictureUrl { get; set; }
        public string Sport { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
        public DateTime? EndsAt { get; set; }
        public string EventName { get; set; }
        public int CratorId { get; set; }

        public EventDtor() { }

        public Event ToModel()
        {
            return new Event
            {
                EventId = EventId,
                HomeNum = HomeNum,
                StreetName = StreetName,
                CityName = CityName,
                PictureUrl = ConvertToByteArray(PictureUrl),
                Sport = Sport,
                CreatedAt= CreatedAt,
                Description = Description,
                EndsAt = EndsAt,
                EventName = EventName,
                CratorId = CratorId
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
