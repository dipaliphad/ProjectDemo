using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.DAL
{
    [Table("Cart")]
    public class Cart
    {

        [Key]
        [ScaffoldColumn(false)]
        public int cart_id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public string status { get; set; }
        public int quantity { get; set; }
    }
}
