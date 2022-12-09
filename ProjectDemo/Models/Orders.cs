using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [ScaffoldColumn(false)]
        public int orders_id { get; set; }
        public int user_id { get; set; }
        public int pay_id { get; set; }
        public int quantity { get; set; }
        public int product_id { get; set; }
    }
}
