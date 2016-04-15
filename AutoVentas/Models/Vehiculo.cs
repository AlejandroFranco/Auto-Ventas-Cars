using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Vehiculo
    {
        [Key]
        public int idVehiculo { get; set; }
        public int numeroMotor { get; set; }
        [StringLength(10)]
        [Display(Name = "Color del Vehículo "), Required(ErrorMessage = "Campo Obligatorio")]
        public String color { get; set; }

        public virtual Tipo Tipo { get; set; }
        public int TipoID { get; set; }
        public virtual Modelo Modelo { get; set; }
        public int ModeloID { get; set; }
        public virtual Marca Marca { get; set; }
        public int MarcaID { get; set; }
        public virtual Linea Linea { get; set; }
        public int LineaID { get; set; }

        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Compra> compras { get; set; }

    
    }
}