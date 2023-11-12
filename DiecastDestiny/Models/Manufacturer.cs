using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Manufacturer Name")]
        public string? ManufacturerName { get; set; }
        [Display(Name = "Logo")]
        public string? LogoURL { get; set; }
        public string? History { get; set; }

        // Relationships
        public List<Product> Products { get; set; }
    }
}
