using ENVANTERYONETIMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ENVANTERYONETIMI.Controllers
{
    public class ProductInventoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductInventoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ProductInventory/Index
        public async Task<IActionResult> Index()
        {
            var productInventories = await _context.ProductInventories.Include(pi => pi.Product).Include(pi => pi.Location).ToListAsync();
            return View(productInventories);
        }

        // GET: ProductInventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductInventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductInventory productInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productInventory);
        }

        // GET: ProductInventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInventory = await _context.ProductInventories.FindAsync(id);
            if (productInventory == null)
            {
                return NotFound();
            }

            return View(productInventory);
        }

        // POST: ProductInventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryID,ProductID,LocationID,Quantity,Shelf,Bin")] ProductInventory productInventory)
        {
            if (id != productInventory.InventoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInventoryExists(productInventory.InventoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(productInventory);
        }

        // GET: ProductInventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInventory = await _context.ProductInventories
                .FirstOrDefaultAsync(m => m.InventoryID == id);
            if (productInventory == null)
            {
                return NotFound();
            }

            return View(productInventory);
        }

        // POST: ProductInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productInventory = await _context.ProductInventories.FindAsync(id);
            _context.ProductInventories.Remove(productInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInventoryExists(int id)
        {
            return _context.ProductInventories.Any(e => e.InventoryID == id);
        }
    }
}
