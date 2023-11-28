using DiecastDestiny.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
        public class Supplier : IEntityBase
        {
            [Key]
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? Description { get; set; }

            //Relationships
            public List<ProductSupplier>? ProductsSuppliers { get; set; }
        }
}
