using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ENVANTERYONETIMI.Models
{
    public class ProductSubcategory
    {
        [Key]
        public int SubcategoryID { get; set; }

        [Required]
        public string SubcategoryName { get; set; }
        [Required]
        public int CategoryID { get; set; }


        [ForeignKey("CategoryID")]
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
