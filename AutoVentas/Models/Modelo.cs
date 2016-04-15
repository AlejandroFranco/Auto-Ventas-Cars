using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Modelo
    {

        public int ModeloID { get; set; }
        [Display(Name = "Año de fabricación "), Required(ErrorMessage = "Campo Obligatorio")]
        public int año { get; set; }
        public virtual List<Vehiculo> vehiculos { get; set; }
    }
}