using DiecastDestiny.Models;

namespace DiecastDestiny.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Brands = new List<Brand>();
            Manufacturers = new List<Manufacturer>();
            Suppliers = new List<Supplier>();
        }
        public List<Brand> Brands { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
