namespace sportup.Dtos
{
    public class UserToEventDto
    {
        public int UserToEventId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public Models.UserToEvent ToModelsUserToEvent(UserToEventDto dto)
        {
            return new Models.UserToEvent()
            {
                UserToEventId = dto.UserToEventId,
                UserId = dto.UserId,
                EventId = dto.EventId
            };
        }
        // Empty builder
        public UserToEventDto() { }

        // Builder that accepts a UserToEvent model
        public UserToEventDto(Models.UserToEvent userToEvent)
        {
            UserToEventId = userToEvent.UserToEventId;
            UserId = userToEvent.UserId;
            EventId = userToEvent.EventId;
        }
    }
}
