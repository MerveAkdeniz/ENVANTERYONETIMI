using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENVANTERYONETIMI.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

        [Required]

        public short SafetyStockLevel { get; set; }// güvenli stok seviyesidir. min seviye
        [Required]
        public bool FinishedGoodsFlag { get; set; }// ürün bitmişse 1 ; 0 ise stokta
        [Required]
        public decimal StandardCost { get; set; }  //ürünün standart maliyeti, üretim m veya satın alma m olaabilir
        [Required]
        public decimal ListPrice { get; set; } //müşteriye sunulan satış fiyatı
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int SubcategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public ProductCategory ProductCategory { get; set; }

        [ForeignKey("SubcategoryID")]
        public ProductSubcategory ProductSubcategory { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }


    }
}
