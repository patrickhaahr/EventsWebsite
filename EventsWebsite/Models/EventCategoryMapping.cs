using System.ComponentModel.DataAnnotations;

namespace EventsWebsite.Models
{
    public class EventCategoryMapping
    {
        [Key]
        public int MappingID { get; set; }

        public int EventID { get; set; }
        public Event Event { get; set; }

        public int CategoryID { get; set; }
        public EventCategory EventCategory { get; set; }
    }
}
