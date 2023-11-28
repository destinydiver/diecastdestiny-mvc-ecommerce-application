using DiecastDestiny.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class Brand : IEntityBase
    {
        // I commented out the Key/Id below because now have this class inheriting from
        // IEntityBase who's Id/Key will override this Key anyway (don't need)
        //[Key]
        //public int Id { get; set; }

        [Display(Name ="Brand Name")]
        [Required(ErrorMessage = "Brand name is required!")]
        public string? BrandName { get; set; }


        [Display(Name = "Brand")]
        public string? LogoURL { get; set; }


        [Required(ErrorMessage ="Short history or description is required.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "History/Description must be between 10 and 100 chars.")]
        public string? History { get; set; }

        // Relationships
        public List<Product>? Products { get; set; }
        public int Id { get; set; }
    }
}
