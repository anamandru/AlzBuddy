using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlzBuddy.Models
{
    public class AccountUser
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
    }
}
