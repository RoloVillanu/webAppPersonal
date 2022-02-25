using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webAppPersonal.BL.DTO
{
    public class personaDTO
    {
        [Required(ErrorMessage ="Id de la persona es requerido")]
        public int idPersona { get; set; }

        [Required(ErrorMessage = "Primer nombre de la persona es requerido")]
        [StringLength(50)]
        public string primerNombre { get; set; }

        [Required(ErrorMessage = "Segundo nombre de la persona es requerido")]
        [StringLength(50)]
        public string segundoNombre { get; set; }

        [Required(ErrorMessage = "Primer apellido de la persona es requerido")]
        [StringLength(50)]
        public string primerApellido { get; set; }

        [Required(ErrorMessage = "Segundo apellido de la persona es requerido")]
        [StringLength(50)]
        public string segundoApellido { get; set; }

        public string fullName
        {
            get {
                return string.Format("{0} {1} {2} {3}",
                                      this.primerNombre, this.segundoNombre,
                                      this.primerApellido, this.segundoApellido);
            }
        }
    }
}
