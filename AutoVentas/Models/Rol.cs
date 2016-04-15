using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Campo Obligatorio!")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }
    }
}