using DiecastDestiny.Data.Base;
using DiecastDestiny.Data.ViewModels;
using DiecastDestiny.Models;

namespace DiecastDestiny.Data.Services
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
