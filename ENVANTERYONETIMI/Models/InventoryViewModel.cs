using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENVANTERYONETIMI.Models
{
    public class InventoryViewModel
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int InventoryID { get; set; }
        public int SubcategoryID { get; set; }
        public string ProductName { get; set; }
        public short SafetyStockLevel { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public string Shelf { get; set; }
        public int Bin { get; set; }
        public string SubcategoryName { get; set; }

    }
}
