using DiecastDestiny.Data.Base;
using DiecastDestiny.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DiecastDestiny.Models
{
    public class NewProductVM
{
        public int Id { get; set; }


        [Display(Name = "Product Image URL")]
        public string? ProductImageURL { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage ="Name is required")]
        public string? ProductName { get; set; }


        [Display(Name = "Model Year")]
        public int? ModelYear { get; set; }


        public string? Model { get; set; }


        [Required(ErrorMessage ="Price is required")]
        public double Price { get; set; }


        [Required(ErrorMessage ="Description is required")]
        public string? Description { get; set; }

        [Display(Name ="Select Product Line")]
        public ProductLine ProductLine { get; set; }

        //Relationships
        [Display(Name = "Select Manufacturer")]
        [Required(ErrorMessage = "Manufacturer selection is required")]
        public int ManufacturerId { get; set; }


        [Display(Name = "Select Brand")]
        [Required(ErrorMessage ="Brand selection is required")]
        public int BrandId { get; set; }


        
        [Display(Name = "Select Suppliers")]
        [Required(ErrorMessage ="Supplier is required")]
        public List<int>? SupplierIds { get; set; }


        
    }
}
