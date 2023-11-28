using DiecastDestiny.Data.Base;
using DiecastDestiny.Data.ViewModels;
using DiecastDestiny.Models;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                ProductName = data.ProductName,
                ModelYear = data.ModelYear,
                Model = data.Model,
                Price = data.Price,
                ProductImageURL = data.ProductImageURL,
                ProductLine = data.ProductLine,
                Description = data.Description,
                ManufacturerId = data.ManufacturerId,
                BrandId = data.BrandId,

            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            // Add Suppliers to the newly created Product above
            foreach (var supplierId in data.SupplierIds)
            {
                var newProductSupplier = new ProductSupplier()
                {
                    ProductId = newProduct.Id,
                    SupplierId = supplierId
                };
                await _context.ProductsSuppliers.AddAsync(newProductSupplier);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM();
            response.Brands = await _context.Brands.OrderBy(n => n.BrandName).ToListAsync();
            response.Manufacturers = await _context.Manufacturers.OrderBy(n => n.ManufacturerName).ToListAsync();
            response.Suppliers = await _context.Suppliers.OrderBy(n => n.Name).ToListAsync();

            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(b => b.Brand)
                .Include(m => m.Manufacturer)
                .Include(ps => ps.ProductsSuppliers).ThenInclude(s => s.Supplier)
                .FirstOrDefaultAsync(n => n.Id == id);
            return productDetails;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(p=>p.Id == data.Id);
            if (dbProduct != null)
            {
                dbProduct.ProductName = data.ProductName;
                dbProduct.ModelYear = data.ModelYear;
                dbProduct.Model = data.Model;
                dbProduct.Price = data.Price;
                dbProduct.ProductImageURL = data.ProductImageURL;
                dbProduct.ProductLine = data.ProductLine;
                dbProduct.Description = data.Description;
                dbProduct.ManufacturerId = data.ManufacturerId;
                dbProduct.BrandId = data.BrandId;
                await _context.SaveChangesAsync();
            }

            // Remove the existing Suppliers
            var existingSuppliersDb = _context.ProductsSuppliers.Where(p => p.ProductId == data.Id).ToList();
            _context.RemoveRange(existingSuppliersDb);
            await _context.SaveChangesAsync();

            // Add new Suppliers list to the updated product above
            foreach (var supplierId in data.SupplierIds)
            {
                var newProductSupplier = new ProductSupplier()
                {
                    ProductId = data.Id,
                    SupplierId = supplierId
                };
                await _context.ProductsSuppliers.AddAsync(newProductSupplier);
            }
            await _context.SaveChangesAsync();
        }
    }
}
