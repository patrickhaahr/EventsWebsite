using System.ComponentModel.DataAnnotations;

namespace EventsWebsite.Models
{
    public class City
    {
        [Key]
        [MaxLength(10)]
        public int PostalCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string CityName { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
