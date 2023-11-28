using DiecastDestiny.Data;
using DiecastDestiny.Data.Services;
using DiecastDestiny.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsService _service;
        public BrandsController(IBrandsService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var allBrands = await _service.GetAllAsync();
            return View(allBrands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BrandName, LogoURL, History")] Brand brand)
        {
            if (!ModelState.IsValid)
            { 
                return View(brand);
            } 
            
            await _service.AddAsync(brand);
            return RedirectToAction(nameof(Index));
            
        }

        // Get: Brands/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) { return View("NotFound"); }
            return View(brandDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) { return View("NotFound"); }
            return View(brandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, BrandName, LogoURL, History")] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            await _service.UpdateAsync(id, brand);
            return RedirectToAction(nameof(Index));

        }

        // Get: Brand/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) { return View("NotFound"); }
            return View(brandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) { return View("NotFound"); }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
