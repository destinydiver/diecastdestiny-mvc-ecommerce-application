using DiecastDestiny.Data;
using DiecastDestiny.Data.Services;
using DiecastDestiny.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiecastDestiny.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersService _service;
        public SuppliersController(ISuppliersService service)
        {
            _service = service;
        }

        // Get All: Suppliers/Index
        public async Task<IActionResult> Index()
        {
            var suppliers =  await _service.GetAllAsync();
            return View(suppliers);
        }
        
        // GET: Suppliers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var supplierDetails = await _service.GetByIdAsync(id);
            if(supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
        }
        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Email, Phone, Description")] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }

            await _service.AddAsync(supplier);
            return RedirectToAction(nameof(Index));

        }

        // GET: Suppliers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var supplierToEdit = await _service.GetByIdAsync(id);
            if (supplierToEdit == null) return View("NotFound");
            return View(supplierToEdit);
        }

        // POST: Suppliers/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Email, Phone, Description")] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }
            await _service.UpdateAsync(id, supplier);
            return RedirectToAction(nameof(Index));
        }

        // GET: Suppliers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var supplierToDelete = await _service.GetByIdAsync(id);
            if (supplierToDelete == null) return View("NotFound");
            return View(supplierToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplierToDelete = await _service.GetByIdAsync(id);
            if (supplierToDelete == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
