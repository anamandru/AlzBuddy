using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlzBuddy.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Clinic")]
        [Required(ErrorMessage = "Clinic's name is required")]
        public string Clinic { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
    }
}
