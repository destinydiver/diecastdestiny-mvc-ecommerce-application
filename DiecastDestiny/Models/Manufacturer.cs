using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string? ManufacturerName { get; set; }
        public string? LogoURL { get; set; }
        public string? History { get; set; }

        // Relationships
        public List<Product> Products { get; set; }
    }
}
