using DiecastDestiny.Data;
using DiecastDestiny.Data.Base;
using DiecastDestiny.Data.Services;
using DiecastDestiny.Models;

namespace DiecastDestiny.Data.Services
{
    public class SuppliersService : EntityBaseRepository<Supplier>, ISuppliersService
    {
        public SuppliersService(AppDbContext context) : base(context) { }
    }
}


//public class BrandsService : EntityBaseRepository<Brand>, IBrandsService
//{
//    public BrandsService(AppDbContext context) : base(context) { }