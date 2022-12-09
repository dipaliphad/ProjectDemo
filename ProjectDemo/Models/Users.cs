using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDemo.DAL
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [ScaffoldColumn(false)]
        public int user_id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int Contact_no { get; set; }
        public string? Email { get; set; }
        public string? State { get; set; }
        public int role_id { get; set; }

    }
}
