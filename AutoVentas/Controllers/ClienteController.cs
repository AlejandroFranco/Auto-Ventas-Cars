using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;
using System.Data.Entity.Infrastructure;

namespace AutoVentas.Controllers
{
    public class ClienteController : Controller
    {
        private DB_AUTOVENTAS_CARS db = new DB_AUTOVENTAS_CARS();

        // GET: Cliente
        public ActionResult Index()
        {
            var vehiculoes = db.Vehiculoes.Include(v => v.Linea).Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.Tipo);
            return View(vehiculoes.ToList());
        }
    }
}