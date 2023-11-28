using DiecastDestiny.Data;
using DiecastDestiny.Data.Services;
using DiecastDestiny.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync(n => n.Brand, m => m.Manufacturer);
            return View(products);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var products = await _service.GetAllAsync(n => n.Brand, m => m.Manufacturer);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = products.Where(n => n.ProductName.Contains(searchString) ||
                    n.Manufacturer.ManufacturerName.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", products);
        }

        // GET: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            return View(productDetails);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var productsDropdownData = await _service.GetNewProductDropdownsValues();

            ViewBag.Brands = new SelectList(productsDropdownData.Brands, "Id", "BrandName");
            ViewBag.Manufacturers = new SelectList(productsDropdownData.Manufacturers, "Id", "ManufacturerName");
            ViewBag.Suppliers = new SelectList(productsDropdownData.Suppliers, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productsDropdownData = await _service.GetNewProductDropdownsValues();

                ViewBag.Brands = new SelectList(productsDropdownData.Brands, "Id", "BrandName");
                ViewBag.Manufacturers = new SelectList(productsDropdownData.Manufacturers, "Id", "ManufacturerName");
                ViewBag.Suppliers = new SelectList(productsDropdownData.Suppliers, "Id", "Name");

                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }


        // GET: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                Model = productDetails.Model,
                ModelYear = productDetails.ModelYear,
                Price = productDetails.Price,
                Description = productDetails.Description,
                BrandId = productDetails.BrandId,
                ManufacturerId = productDetails.ManufacturerId,
                ProductImageURL = productDetails.ProductImageURL,
                ProductLine = productDetails.ProductLine,
                SupplierIds = productDetails.ProductsSuppliers.Select(s => s.ProductId).ToList()

            };

            var productsDropdownData = await _service.GetNewProductDropdownsValues();

            ViewBag.Brands = new SelectList(productsDropdownData.Brands, "Id", "BrandName");
            ViewBag.Manufacturers = new SelectList(productsDropdownData.Manufacturers, "Id", "ManufacturerName");
            ViewBag.Suppliers = new SelectList(productsDropdownData.Suppliers, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productsDropdownData = await _service.GetNewProductDropdownsValues();

                ViewBag.Brands = new SelectList(productsDropdownData.Brands, "Id", "BrandName");
                ViewBag.Manufacturers = new SelectList(productsDropdownData.Manufacturers, "Id", "ManufacturerName");
                ViewBag.Suppliers = new SelectList(productsDropdownData.Suppliers, "Id", "Name");

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            return View(productDetails);
        }

        // POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productToDelete = await _service.GetProductByIdAsync(id);
            if (productToDelete == null) return View("NotFound");
            
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
