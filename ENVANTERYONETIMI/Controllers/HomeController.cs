using ENVANTERYONETIMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
//using ENVANTERYONETIMI.Data;

namespace ENVANTERYONETIMI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int productCount = _context.Products.Count(); // Burada tabloya erişim sağlanmalı
            ViewBag.ProductCount = productCount;


            int totalStock = _context.ProductInventories.Sum(p => p.Quantity);
            ViewBag.TotalStock = totalStock;


            // SafetyStockLevel altında kalan ürünlerin sayısını bul
            var productCountBelowSafetyStock = _context.ProductInventories
                .Join(_context.Products,
                    pi => pi.ProductID,
                    p => p.ProductID,
                    (pi, p) => new { pi, p })
                .Where(x => x.pi.Quantity < x.p.SafetyStockLevel)
                .Select(x => x.pi.ProductID) // Ürün kimliğine göre say
                .Distinct() // Aynı üründen birden fazla olabilir, her ürün yalnızca bir kez sayılır
                .Count();
            // ViewBag ile sonuçları view'e gönder
            ViewBag.ProductCountBelowSafetyStock = productCountBelowSafetyStock;


            // Toplam kategori sayısını hesapla
            var totalCategories = _context.ProductCategories.Count();
            ViewBag.TotalCategories = totalCategories;


            // Toplam altkategori sayısını hesapla
            var totalSubcategories = _context.ProductSubcategories.Count();
            ViewBag.TotalSubcategories = totalSubcategories;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
