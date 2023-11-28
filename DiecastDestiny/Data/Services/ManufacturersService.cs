using DiecastDestiny.Data.Base;
using DiecastDestiny.Models;

namespace DiecastDestiny.Data.Services
{
    public class ManufacturersService : EntityBaseRepository<Manufacturer>, IManufacturersService
    {
        public ManufacturersService(AppDbContext context) : base(context) { }

        // Below is commented out because, now, IManufacturersService inherits CRUD functionality from IEntityBaseRepository
        // All that needs to be done is bring in the dbContext and pass it to the base as you see above.

        //public Task AddManufacturerAsync(Manufacturer manufacturer)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteManufacturerAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Manufacturer>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task GetManufacturerByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Manufacturer> UpdateBrandAsync(int id, Manufacturer updatedManufacturer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
