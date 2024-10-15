using sportup.Models;

namespace sportup.Dtos
{
    public class UserToEventDto
    {
        public int TableId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string? RealtionshipType { get; set; }

        public UserToEventDto() { }

        public UserToEventDto(UserToEvent userToEvent)
        {
            TableId = userToEvent.TableId;
            UserId = userToEvent.UserId;
            EventId = userToEvent.EventId;
            RealtionshipType = userToEvent.RealtionshipType;
        }

        public UserToEvent ToModel()
        {
            return new UserToEvent
            {
                TableId = TableId,
                UserId = UserId,
                EventId = EventId,
                RealtionshipType = RealtionshipType
            };
        }
    }

}
