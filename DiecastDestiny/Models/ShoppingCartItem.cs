using System.ComponentModel.DataAnnotations;

namespace DiecastDestiny.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
