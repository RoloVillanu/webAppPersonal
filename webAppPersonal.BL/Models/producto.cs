using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAppPersonal.BL.Models
{
    [Table(name: "producto", Schema = "dbo")]
    public class producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int puntoreorden{ get; set; }
        public double precio { get; set; }
        public string estado { get; set; }

    }
}
