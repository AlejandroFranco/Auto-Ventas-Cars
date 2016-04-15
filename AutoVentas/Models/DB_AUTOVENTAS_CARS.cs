using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoVentas.Models
{
    public class DB_AUTOVENTAS_CARS : DbContext
    {
        public DB_AUTOVENTAS_CARS() : base("name=DB_AUTOVENTAS_CARS") { }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Compra> compra { get; set; }
        public virtual DbSet<Venta> venta { get; set; }
        public virtual DbSet<Linea> linea { get; set; }
        public virtual DbSet<Marca> marca { get; set; }

        public virtual DbSet<Modelo> modelo { get; set; }
        public virtual DbSet<Tipo> tipo { get; set; }

        public virtual DbSet<AutoVentasMASTER> autoventasmaster { get; set; }

        public System.Data.Entity.DbSet<AutoVentas.Models.Vehiculo> Vehiculoes { get; set; }
    }
}