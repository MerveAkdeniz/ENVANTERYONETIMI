using System.ComponentModel.DataAnnotations;

namespace ENVANTERYONETIMI.Models
{
    public class ProductModel
    {
        [Key]
        public int ModelID { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string CatalogDescription { get; set; }
    }
}
