using System.ComponentModel.DataAnnotations;

namespace EventsWebsite.Models
{
    public class EventCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }

        public ICollection<EventCategoryMapping> EventCategoryMappings { get; set; }
    }

}
