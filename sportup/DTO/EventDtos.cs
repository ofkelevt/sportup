using Microsoft.AspNetCore.Http.HttpResults;
using sportup.Models;
using System.Security.Cryptography;

namespace sportup.DTO
{
    public class EventDtos
    {
        public int EventId { get; set; }
        public string? HomeNum { get; set; }
        public string? StreetName { get; set; }
        public string? CityName { get; set; }
        public string? PictureUrl { get; set; }
        public string Sport { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
        public DateTime? EndsAt { get; set; }
        public string EventName { get; set; }
        public int CratorId { get; set; }
        public EventDtos(Event e)
        {
            EventId = e.EventId;
            HomeNum = e.HomeNum;
            StreetName = e.StreetName;
            CityName = e.CityName;
            PictureUrl = ConvertToBase64(e.PictureUrl);
            Sport = e.Sport;
            CreatedAt = e.CreatedAt;
            Description = e.Description;
            EndsAt = e.EndsAt;
            EventName = e.EventName;
            CratorId = e.CratorId;
        }
        public static string ConvertToBase64(byte[] data)
        {
            if (data == null || data.Length == 0)
                return null;

            return Convert.ToBase64String(data);
        }
    }
}
