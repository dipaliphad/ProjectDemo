using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.DAL
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int product_id { get; set; }
        [Required(ErrorMessage ="product name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "product discription is required")]
        [MaxLength(9000)]
        public decimal disc { get; set; }
        [Required(ErrorMessage = "product price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "product image is required")]
        [RegularExpression(@"(.pngl.jpgl.gif)$",ErrorMessage ="only image files allowed.")]
        public string Product_image { get; set; }
        [Display(Name="category")]
        public string category_id { get; set; }
        [Required(ErrorMessage = "product status is required")]
        public string Status { get; set; }
        [NotMapped]
        public int category_Name{ get; set; }
    }
}
