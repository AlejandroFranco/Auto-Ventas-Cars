using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre de Usuario"), Required(ErrorMessage = "Campo Obligatorio")]

        [StringLength(50, ErrorMessage = "El username no puede tener mas de 50 caracteres")]
        public String username { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "Campo Obligatorio"), DataType(DataType.Password)]
        public String password { get; set; }
        [Display(Name = "Comparar Contraseña"), Required(ErrorMessage = "Confirmar Contraseña"), DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "No coinciden las contraseñas")]
        public String compararPassword { get; set; }

        [Display(Name = "Correo electronico"), Required(ErrorMessage = "Campo Obligatorio"), DataType(DataType.EmailAddress)]
        public String correo { get; set; }
        [StringLength(10)]
        [Display(Name = "Nombre "), Required(ErrorMessage = "Campo Obligatorio")]
        public String nombre { get; set; }
        [Display(Name = "Apellido "), Required(ErrorMessage = "Campo Obligatorio")]
        public String apellido { get; set; }
        [Display(Name = "Numero Telefonico"), Required(ErrorMessage = "Campo Obligatorio"), DataType(DataType.PhoneNumber)]
        public int telefono { get; set; }
        public virtual Rol rol { get; set; }
        public virtual Compra compra { get; set; }
    }
}