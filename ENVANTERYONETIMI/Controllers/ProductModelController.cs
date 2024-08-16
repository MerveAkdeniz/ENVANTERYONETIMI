using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ENVANTERYONETIMI.Models;
using System.Linq;
using System.Threading.Tasks;

public class ProductModelController : Controller
{
    private readonly ApplicationDBContext _context;

    public ProductModelController(ApplicationDBContext context)
    {
        _context = context;
    }

    // GET: ProductModel/Index
    public async Task<IActionResult> Index()
    {
        var productModels = await _context.ProductModels.ToListAsync();
        return View(productModels);
    }

    // GET: ProductModel/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _context.ProductModels
            .FirstOrDefaultAsync(m => m.ModelID == id);
        if (productModel == null)
        {
            return NotFound();
        }

        return View(productModel);
    }

    // GET: ProductModel/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ProductModel/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductModel productModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(productModel);
    }

    // GET: ProductModel/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _context.ProductModels.FindAsync(id);
        if (productModel == null)
        {
            return NotFound();
        }

        return View(productModel);
    }

    // POST: ProductModel/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProductModelID,Name,Description,Color,Size,StandardCost,ListPrice")] ProductModel productModel)
    {
        if (id != productModel.ModelID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(productModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(productModel.ModelID))
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

        return View(productModel);
    }

    // GET: ProductModel/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _context.ProductModels
            .FirstOrDefaultAsync(m => m.ModelID == id);
        if (productModel == null)
        {
            return NotFound();
        }

        return View(productModel);
    }

    // POST: ProductModel/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var productModel = await _context.ProductModels.FindAsync(id);
        _context.ProductModels.Remove(productModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductModelExists(int id)
    {
        return _context.ProductModels.Any(e => e.ModelID == id);
    }
}
