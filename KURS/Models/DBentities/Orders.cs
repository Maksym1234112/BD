using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KURS.Models.DBentities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50")]
        public string Title{ get; set; }
        public string TypeOfProduct { get; set; }
        public string Email { get; set; }
        public double Price { get; set; }

    }
}
