using Humanizer;
using sportup.Models;
using System.ComponentModel.DataAnnotations;

namespace sportup.DTO
{
    public class EventDto
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

        public EventDto() { }

        public EventDto(Event e)
        {
            EventId = e.EventId;
            HomeNum = e.HomeNum;
            StreetName = e.StreetName;
            CityName = e.CityName;
            PictureUrl = e.PictureUrl;
            Sport = e.Sport;
            CreatedAt = e.CreatedAt;
            Description = e.Description;
            EndsAt = e.EndsAt;
            EventName = e.EventName;
            CratorId = e.CratorId;
        }

        public Event ToModel()
        {
            return new Event
            {
                EventId = EventId,
                HomeNum = HomeNum,
                StreetName = StreetName,
                CityName = CityName,
                PictureUrl = PictureUrl,
                Sport = Sport,
                CreatedAt= CreatedAt,
                Description = Description,
                EndsAt = EndsAt,
                EventName = EventName,
                CratorId = CratorId
            };
        }
    }

}
