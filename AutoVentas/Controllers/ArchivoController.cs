using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;
namespace AutoVentas.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo

        private DB_AUTOVENTAS_CARS db = new DB_AUTOVENTAS_CARS();
        public ActionResult ObtenerArchivo(int id) {
            var imagen = db.archivo.Find(id);
                return File(imagen.contenido, imagen.tipoContenido); 
        }

        public ActionResult ObtenerImagenes() {

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}