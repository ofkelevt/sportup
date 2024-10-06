using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace sportup.DTO
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string HomeNum { get; set; }

        public string StreetName { get; set; }

        public string CityName { get; set; }
        public string PictureUrl { get; set; }

        public string Sport { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Description { get; set; }

        public DateTime EndsAt { get; set; }

        public string EventName { get; set; }
        public string Crator_Id { get; set; }

        public Models.Event ToModelsUserToEvent(EventDto dto)
        {
            return new Models.Event()
            {
                EventId = dto.EventId,
                HomeNum = dto.HomeNum,
                StreetName = dto.StreetName,
                CityName = dto.CityName,
                PictureUrl = dto.PictureUrl,
                Sport = dto.Sport,
                CreatedAt = dto.CreatedAt,
                EndsAt = dto.EndsAt,
                EventName = dto.EventName,
                Crator_Id = dto.Crator_Id,
                Description = dto.Description
            };
        }
        // Empty builder
        public EventDto() { }

        // Builder that accepts a UserToEvent model
        public EventDto(Models.Event events)
        {
            EventId = events.EventId;
            HomeNum = events.HomeNum;
            StreetName = events.StreetName;
            CityName = events.CityName;
            PictureUrl = events.PictureUrl;
            Sport = events.Sport;
            CreatedAt = events.CreatedAt;
            EndsAt = (System.DateTime)events.EndsAt;
            EventName = events.EventName;
            Crator_Id = events.Crator_Id;
            Description = events.Description;
        }
    }
}
