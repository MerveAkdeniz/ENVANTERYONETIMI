using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENVANTERYONETIMI.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderID { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }//toplam tutar 
        [Required]
        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        public Vendor Vendor { get; set; }
    }
}
