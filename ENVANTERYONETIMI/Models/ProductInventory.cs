using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENVANTERYONETIMI.Models
{
    public class ProductInventory
    {
        [Key]
        public int InventoryID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Shelf { get; set; } //raf adı
        [Required]
        public int Bin { get; set; } // raf içindeki saklama bölmesi kodu
        [Required]
        public int ProductID { get; set; }
        public int LocationID { get; set; }
        [ForeignKey("LocationID")]
        public Location Location { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}
