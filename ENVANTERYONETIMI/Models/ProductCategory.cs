using System.ComponentModel.DataAnnotations;


namespace ENVANTERYONETIMI.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
