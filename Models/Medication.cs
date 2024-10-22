using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlzBuddy.Models
{
    public class Medication
    {
        public int Id { get; set; }

        [DisplayName("Name of pills")]
        [Required(ErrorMessage = "Name of the pills is required")]
        public string Name { get; set; }

        [DisplayName("Morning dose")]
        public string Morning { get; set; }

        [DisplayName("Noon dose")]
        public string Noon { get; set; }

        [DisplayName("Evening dose")]
        public string Evening { get; set; }
    }
}
