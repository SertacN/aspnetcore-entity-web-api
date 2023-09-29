using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitySQLApiStudy.ApiStudy.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string UserName { get; set; } = "";
        public int Age { get; set; }
        public int Number { get; set; }
    }
}
