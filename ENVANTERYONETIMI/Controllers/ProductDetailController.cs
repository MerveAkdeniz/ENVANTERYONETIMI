using ENVANTERYONETIMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ENVANTERYONETIMI.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductDetailController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: /ProductDetail/
        public async Task<IActionResult> Index()
        {
            var products = await (from p in _context.Products
                                  join pc in _context.ProductCategories on p.CategoryID equals pc.CategoryID
                                  join pi in _context.ProductInventories on p.ProductID equals pi.ProductID
                                  join ps in _context.ProductSubcategories on p.SubcategoryID equals ps.SubcategoryID
                                  select new ProductDetail
                                  {
                                      ProductID = p.ProductID,
                                      CategoryID = p.CategoryID,
                                      InventoryID = pi.InventoryID,
                                      SubcategoryID = p.SubcategoryID,
                                      ProductName = p.ProductName,
                                      SafetyStockLevel = p.SafetyStockLevel,
                                      StandardCost = p.StandardCost,
                                      ListPrice = p.ListPrice,
                                      CategoryName = pc.CategoryName,
                                      Quantity = pi.Quantity,
                                      Shelf = pi.Shelf,
                                      Bin = pi.Bin,
                                      SubcategoryName = ps.SubcategoryName,
                                      ImageUrl = p.ImageUrl
                                  }).ToListAsync();

            // Get distinct categories for the dropdown
            var distinctCategories = await _context.ProductCategories
                                                   .Select(pc => pc.CategoryName)
                                                   .Distinct()
                                                   .ToListAsync();

            ViewBag.DistinctCategories = distinctCategories;

            return View(products);
        }

        // GET: /ProductDetail/FilterByCategory
        

        // POST: /ProductDetail/GetTable
        [HttpPost]
        public async Task<IActionResult> GetTable(List<string> selectedColumns)
        {
            // Debugging için seçilen kolonları kontrol et
            System.Diagnostics.Debug.WriteLine("Seçilen kolonlar: " + string.Join(", ", selectedColumns));

            var products = await (from p in _context.Products
                                  join pc in _context.ProductCategories on p.CategoryID equals pc.CategoryID
                                  join pi in _context.ProductInventories on p.ProductID equals pi.ProductID
                                  join ps in _context.ProductSubcategories on p.SubcategoryID equals ps.SubcategoryID
                                  select new ProductDetail
                                  {
                                      ProductID = p.ProductID,
                                      CategoryID = p.CategoryID,
                                      InventoryID = pi.InventoryID,
                                      SubcategoryID = p.SubcategoryID,
                                      ProductName = p.ProductName,
                                      SafetyStockLevel = p.SafetyStockLevel,
                                      StandardCost = p.StandardCost,
                                      ListPrice = p.ListPrice,
                                      CategoryName = pc.CategoryName,
                                      Quantity = pi.Quantity,
                                      Shelf = pi.Shelf,
                                      Bin = pi.Bin,
                                      SubcategoryName = ps.SubcategoryName,
                                      ImageUrl = p.ImageUrl
                                  }).ToListAsync();

            var dataTable = ConvertToDataTable(products);
            var filteredTable = FilterDataTable(dataTable, selectedColumns);

            var htmlTable = GenerateHtmlTable(filteredTable);
            return Content(htmlTable, "text/html");
        }

        private DataTable ConvertToDataTable(List<ProductDetail> list)
        {
            var dataTable = new DataTable();

            // Dynamically add columns based on the properties of InventoryViewModel
            dataTable.Columns.Add("ProductID");
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns.Add("InventoryID");
            dataTable.Columns.Add("SubcategoryID");
            dataTable.Columns.Add("ProductName");
            dataTable.Columns.Add("SafetyStockLevel");
            dataTable.Columns.Add("StandardCost");
            dataTable.Columns.Add("ListPrice");
            dataTable.Columns.Add("CategoryName");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Shelf");
            dataTable.Columns.Add("Bin");
            dataTable.Columns.Add("SubcategoryName");
            dataTable.Columns.Add("ImageUrl");

            foreach (var item in list)
            {
                var row = dataTable.NewRow();
                row["ProductID"] = item.ProductID;
                row["CategoryID"] = item.CategoryID;
                row["InventoryID"] = item.InventoryID;
                row["SubcategoryID"] = item.SubcategoryID;
                row["ProductName"] = item.ProductName;
                row["SafetyStockLevel"] = item.SafetyStockLevel;
                row["StandardCost"] = item.StandardCost;
                row["ListPrice"] = item.ListPrice;
                row["CategoryName"] = item.CategoryName;
                row["Quantity"] = item.Quantity;
                row["Shelf"] = item.Shelf;
                row["Bin"] = item.Bin;
                row["SubcategoryName"] = item.SubcategoryName;
                row["ImageUrl"] = item.ImageUrl;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private DataTable FilterDataTable(DataTable dataTable, List<string> selectedColumns)
        {
            var filteredTable = dataTable.DefaultView.ToTable(false, selectedColumns.ToArray());
            return filteredTable;
        }

        private string GenerateHtmlTable(DataTable dataTable)
        {
            var html = "<table class='table table-striped'><thead><tr>";

            // Header
            foreach (DataColumn column in dataTable.Columns)
            {
                html += $"<th>{column.ColumnName}</th>";
            }
            html += "</tr></thead><tbody>";

            // Rows
            foreach (DataRow row in dataTable.Rows)
            {
                html += "<tr>";
                foreach (DataColumn column in dataTable.Columns)
                {
                    html += $"<td>{row[column]}</td>";
                }
                html += "</tr>";
            }
            html += "</tbody></table>";

            return html;
        }
    }
}
