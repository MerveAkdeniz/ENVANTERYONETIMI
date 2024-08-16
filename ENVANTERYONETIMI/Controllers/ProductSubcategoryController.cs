using ENVANTERYONETIMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ENVANTERYONETIMI.Controllers
{
    public class ProductSubcategoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductSubcategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ProductSubcategory/Index
        public async Task<IActionResult> Index()
        {
            var subcategories = await _context.ProductSubcategories.ToListAsync(); // ProductSubcategory tablosundan tüm verileri alıyoruz
            return View(subcategories);
        }

        // GET: ProductSubcategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductSubcategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductSubcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Başarıyla oluşturulursa Index sayfasına yönlendirir
            }

            // Model geçersizse hata mesajlarını console'a yazdır
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(subcategory); // Hata varsa Create view'ını tekrar göster
        }

        // GET: ProductSubcategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.ProductSubcategories.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // POST: ProductSubcategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubcategoryID,SubcategoryName")] ProductSubcategory subcategory)
        {
            if (id != subcategory.SubcategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSubcategoryExists(subcategory.SubcategoryID))
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

            return View(subcategory);
        }

        // GET: ProductSubcategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.ProductSubcategories
                .FirstOrDefaultAsync(m => m.SubcategoryID == id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // POST: ProductSubcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategory = await _context.ProductSubcategories.FindAsync(id);
            _context.ProductSubcategories.Remove(subcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubcategoryExists(int id)
        {
            return _context.ProductSubcategories.Any(e => e.SubcategoryID == id);
        }
    }
}
