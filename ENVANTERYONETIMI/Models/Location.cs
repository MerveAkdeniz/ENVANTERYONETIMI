using System.ComponentModel.DataAnnotations;

namespace ENVANTERYONETIMI.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        public string LocationName { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}
