using DiecastDestiny.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Manufacturer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Manufacturer Name")]
        [Required(ErrorMessage ="Manufacturer name is required")]
        public string? ManufacturerName { get; set; }
        [Display(Name = "Manufacturer's Logo")]
        public string? LogoURL { get; set; }
        public string? History { get; set; }

        // Relationships
        public List<Product>? Products { get; set; }
    }
}
