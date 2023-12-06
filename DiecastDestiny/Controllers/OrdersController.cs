using DiecastDestiny.Data.Cart;
using DiecastDestiny.Data.Services;
using DiecastDestiny.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiecastDestiny.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            var cartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = cartItems;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
