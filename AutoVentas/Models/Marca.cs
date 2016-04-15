using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Marca
    {
        public int MarcaID { get; set; }
        [StringLength(10)]
        [Display(Name = "Proveedor"), Required(ErrorMessage = "Campo Obligatorio")]
        public String proveedor { get; set; }

        public virtual List<Vehiculo> vehiculos { get; set; }
    }
}