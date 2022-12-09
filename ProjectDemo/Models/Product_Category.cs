using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Models
{
    [Table("Product_Catagory")]
    public class Product_Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int category_id { get; set; }

        [Required(ErrorMessage = "name required")]
        public string Name { get; set; }
    }
}
