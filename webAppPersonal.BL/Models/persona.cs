using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAppPersonal.BL.Models
{
    [Table(name:"persona", Schema ="dbo")]
    public class persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPersona { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }

    }
}
