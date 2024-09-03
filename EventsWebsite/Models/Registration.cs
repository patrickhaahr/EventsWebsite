using EventsWebsite.Models.Enums;

namespace EventsWebsite.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }

        public int EventID { get; set; }
        public Event Event { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public EventStatus? Status { get; set; } // Nullable enum
    }
}
