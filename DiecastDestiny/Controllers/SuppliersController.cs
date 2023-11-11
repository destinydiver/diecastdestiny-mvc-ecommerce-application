using DiecastDestiny.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly AppDbContext _context;

        public SuppliersController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var suppliers =  await _context.Suppliers.ToListAsync();
            return View(suppliers);
        }
    }
}
