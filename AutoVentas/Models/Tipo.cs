using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Tipo
    {
        
        public int TipoID { get; set; }
        [Display(Name = "Tipo de Carro "), Required(ErrorMessage = "Campo Obligatorio")]
        public String nombre { get; set; }
        public virtual List<Vehiculo> vehiculos { get; set; }
    }
}