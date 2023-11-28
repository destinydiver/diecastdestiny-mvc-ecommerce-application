using DiecastDestiny.Data.Base;
using DiecastDestiny.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DiecastDestiny.Models
{
    public class Product : IEntityBase
{
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Image")]
        public string? ProductImageURL { get; set; }
        public string? ProductName { get; set; }
        [Display(Name = "Model Year")]
        public int? ModelYear { get; set; }
        public string? Model { get; set; }
        public double Price { get; set; }
        public ProductLine ProductLine { get; set; }
        public string? Description { get; set; }

        //Relationships
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<ProductSupplier>? ProductsSuppliers { get; set; }

           
    }
}
