using System.ComponentModel.DataAnnotations;

namespace EventsWebsite.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }  // Surrogate key

        public int UserID { get; set; }
        public User User { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        public int? EventID { get; set; }
        public Event Event { get; set; }
    }
}
