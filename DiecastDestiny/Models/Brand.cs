using DiecastDestiny.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Brand : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Brand Name")]
        [Required(ErrorMessage = "Brand name is required!")]
        public string? BrandName { get; set; }

        [Display(Name = "Brand Logo URL")]
        public string? LogoURL { get; set; }
        public string? History { get; set; }

        // Relationships
        public List<Product>? Products { get; set; }
        
    }
}
