using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webAppPersonal.BL.DTO
{
    public class productoDTO
    {
        [Required(ErrorMessage = "Id del producto es requerido")]
        public int idProducto { get; set; }

        [Required(ErrorMessage = "Nombre del producto es requerido")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Punto Reorden es requerido")]
        public int puntoreorden { get; set; }

        [Required(ErrorMessage = "Precio es requerido")]
        public double precio { get; set; }

        [Required(ErrorMessage = "Estado del producto es requerido")]
        [StringLength(1)]
        public string estado { get; set; }

        public string fullName
        {
            get
            {
                return string.Format("{0} {1} {2} {3}",
                                      this.idProducto, this.nombre,
                                      this.puntoreorden, this.precio);
            }
        }
    }
}
