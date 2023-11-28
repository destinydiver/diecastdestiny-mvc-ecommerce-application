using DiecastDestiny.Data.Base;
using DiecastDestiny.Models;

namespace DiecastDestiny.Data.Services
{
    public interface IManufacturersService : IEntityBaseRepository<Manufacturer>
    {
        // Below is commented out because, now, IManufacturersService inherits CRUD functionality from IEntityBaseRepository

        //Task<IEnumerable<Manufacturer>> GetAllAsync();
        //Task GetManufacturerByIdAsync(int id);
        //Task AddManufacturerAsync(Manufacturer manufacturer);
        //Task<Manufacturer> UpdateBrandAsync(int id, Manufacturer updatedManufacturer);
        //Task DeleteManufacturerAsync(int id);
    }
}
