using DiecastDestiny.Data;
using DiecastDestiny.Data.Services;
using DiecastDestiny.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly IManufacturersService _service;

        public ManufacturersController(IManufacturersService service)
        {
            _service = service;
        }

        // GET: ManufacturersController
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: ManufacturersController/Details/5
        public async Task<IActionResult> Details(int id)
        { 
            var details = await _service.GetByIdAsync(id);
            return details == null ? View("NotFound") : (IActionResult)View(details);
        }

        // GET: ManufacturersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturersController/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ManufacturerName, LogoURL, History")] Manufacturer manufacturer)
        {
            try
            {
                await _service.AddAsync(manufacturer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(manufacturer);
            }
        }

        // GET: Manufacturers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound"); ;
            return View(data);
        }

        // POST: ManufacturersController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ManufacturerName, LogoURL, History")] Manufacturer manufacturer)
        {
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();

            Console.WriteLine(errors);

            if (!ModelState.IsValid) return View(manufacturer);

            if (id == manufacturer.Id)
            {
                await _service.UpdateAsync(id, manufacturer);
                return RedirectToAction(nameof(Index));
            }
            
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var manufacturerToDelete = await _service.GetByIdAsync(id);
            if (manufacturerToDelete == null) return View("NotFound"); ;
            return View(manufacturerToDelete);
        }

        // POST: ManufacturersController/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var manufacturerToDelete = await _service.GetByIdAsync(id);
            if (manufacturerToDelete == null) return View("NotFound"); ;

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
