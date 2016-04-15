using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class Archivo
    {
        [Key]
        public int idArchivo { get; set; }
        public String nombre { get; set; }
        public String tipoContenido { get; set; }
        public TipoArchivo tipo { get; set; }
        public byte[] contenido { get; set; }
        public virtual Vehiculo vehiculo { get; set; }
    }
}