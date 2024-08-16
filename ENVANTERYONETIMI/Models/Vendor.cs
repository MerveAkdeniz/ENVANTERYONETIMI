using System.ComponentModel.DataAnnotations;

namespace ENVANTERYONETIMI.Models
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }
        [Required]
        public string VendorName { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
