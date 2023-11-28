using DiecastDestiny.Data.Base;
using DiecastDestiny.Models;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Data.Services
{
    public class BrandsService : EntityBaseRepository<Brand>, IBrandsService
    {
        public BrandsService(AppDbContext context) : base(context) { }
        

        // All below is commented out because the above line is constructor for ActorsService
        // Which just takes in the context which is then passed to the base class generic constructor.

        //public async Task AddAsync(Brand brand)
        //{
        //    await _context.Brands.AddAsync(brand);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var brandToDelete = await _context.Brands.FirstOrDefaultAsync(n => n.Id == id);
        //    _context.Brands.Remove(brandToDelete);
        //    await _context.SaveChangesAsync();
        //}



        //public async Task<Brand> UpdateAsync(int id, Brand updatedBrand)
        //{
        //    _context.Brands.Update(updatedBrand);
        //    await _context.SaveChangesAsync();
        //    return updatedBrand;
        //}
    }
}
