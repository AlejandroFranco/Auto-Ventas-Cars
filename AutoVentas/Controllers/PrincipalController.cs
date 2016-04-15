using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;

namespace AutoVentas.Controllers
{
    public class PrincipalController : Controller
    {
        private DB_AUTOVENTAS_CARS db = new DB_AUTOVENTAS_CARS();
        // GET: Principal
        public ActionResult Index()
        {
            var vehiculoes = db.Vehiculoes.Include(v => v.Linea).Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.Tipo);
            return View(vehiculoes.ToList());
        }


        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Ponerse en contacto.";

            return View();
        }

    }
}