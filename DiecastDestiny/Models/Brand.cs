using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string? BrandName { get; set; }
        [Display(Name = "Brand")]
        public string? LogoURL { get; set; }
        public string? History { get; set; }

        // Relationships
        public List<Product> Products { get; set; }
    }
}
