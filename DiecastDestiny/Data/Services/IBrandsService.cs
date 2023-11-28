using DiecastDestiny.Data.Base;
using DiecastDestiny.Models;

namespace DiecastDestiny.Data.Services
{
    public interface IBrandsService : IEntityBaseRepository<Brand>
    {
        // Below is commented out because, now, IBrandsService inherits CRUD functionality from IEntityBaseRepository

        //Task<IEnumerable<Brand>> GetAllAsync();
        //Task<Brand> GetByIdAsync(int id);
        //Task AddAsync(Brand brand);
        //Task<Brand> UpdateAsync(int id, Brand updatedBrand);
        //Task DeleteAsync(int id);
    }
}
