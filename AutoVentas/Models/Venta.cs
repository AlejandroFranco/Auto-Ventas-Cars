using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }
        public Double precio { get; set; }
        public DateTime fechaVenta { get; set; }
        public virtual Vehiculo vehiculo { get; set; }
    }
}