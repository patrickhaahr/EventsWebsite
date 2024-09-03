using System.ComponentModel.DataAnnotations;

namespace EventsWebsite.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        [MaxLength(255)]
        public string CityName { get; set; }
        public City City { get; set; }

        public DateTime Date { get; set; }

        public int OrganizerID { get; set; }
        public User Organizer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Registration> Registrations { get; set; }
        public ICollection<EventCategoryMapping> EventCategoryMappings { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
