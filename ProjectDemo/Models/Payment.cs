using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int pay_id { get; set; }
        [Required(ErrorMessage = "type required")]
        public string type { get; set; }
        [Required(ErrorMessage = "name required")]
        public string pay_name { get; set; }
    }
}
