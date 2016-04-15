using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }
        [Display(Name = "Costo"), Required(ErrorMessage = "Campo Obligatorio")]
        public double precio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime fechaCompra { get; set; }

        [Display(Name = "#Tarjeta"), Required(ErrorMessage = "Campo Obligatorio"), DataType(DataType.CreditCard)]
        public String numeroTarjeta { get; set; }
        public String tipoPago { get; set; }
        public Double totalCompra { get; set; }
        public virtual Vehiculo vehiculo { get; set; }
        public virtual List<Usuario> usuarios { get; set; }
    }
}