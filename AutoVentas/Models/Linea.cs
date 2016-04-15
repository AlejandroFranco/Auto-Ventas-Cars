using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Linea
    {
  
        public int LineaID { get; set; }
        [StringLength(10)]
        [Display(Name = "Linea del Automóvil "), Required(ErrorMessage = "Campo Obligatorio")]
        public String nombreLinea { get; set; }

        public virtual List<Vehiculo> vehiculos { get; set; }
    }
}