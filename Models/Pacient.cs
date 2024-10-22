using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlzBuddy.Models
{
    public class Pacient
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [DisplayName("Blood type")]
        [Required(ErrorMessage = "Blood type is required")]
        public string BloodType { get; set; }

        public List<Medication> Medications { get; set; }

        [DisplayName("Description of patient's condition")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [DisplayName("Doctor's name")]
        [Required(ErrorMessage = "Doctor's name is required")]
        public Doctor Doctor { get; set; }
    }
}
