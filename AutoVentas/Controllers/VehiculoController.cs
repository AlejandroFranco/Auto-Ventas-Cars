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
    public class VehiculoController : Controller
    {
        private DB_AUTOVENTAS_CARS db = new DB_AUTOVENTAS_CARS();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculoes = db.Vehiculoes.Include(v => v.Linea).Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.Tipo);
            return View(vehiculoes.ToList());
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.LineaID = new SelectList(db.linea, "LineaID", "nombreLinea");
            ViewBag.MarcaID = new SelectList(db.marca, "MarcaID", "proveedor");
            ViewBag.ModeloID = new SelectList(db.modelo, "ModeloID", "ModeloID");
            ViewBag.TipoID = new SelectList(db.tipo, "TipoID", "nombre");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVehiculo,numeroMotor,color,TipoID,ModeloID,MarcaID,LineaID")] Vehiculo vehiculo, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null)
                {

                    var imagen = new Archivo
                    {

                        nombre = System.IO.Path.GetFileName(archivo.FileName), 
                        tipo = TipoArchivo.JPG,
                        tipoContenido = archivo.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                    };
                    vehiculo.archivos = new List<Archivo> { imagen };
                }


                db.Vehiculoes.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LineaID = new SelectList(db.linea, "LineaID", "nombreLinea", vehiculo.LineaID);
            ViewBag.MarcaID = new SelectList(db.marca, "MarcaID", "proveedor", vehiculo.MarcaID);
            ViewBag.ModeloID = new SelectList(db.modelo, "ModeloID", "ModeloID", vehiculo.ModeloID);
            ViewBag.TipoID = new SelectList(db.tipo, "TipoID", "nombre", vehiculo.TipoID);
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.LineaID = new SelectList(db.linea, "LineaID", "nombreLinea", vehiculo.LineaID);
            ViewBag.MarcaID = new SelectList(db.marca, "MarcaID", "proveedor", vehiculo.MarcaID);
            ViewBag.ModeloID = new SelectList(db.modelo, "ModeloID", "ModeloID", vehiculo.ModeloID);
            ViewBag.TipoID = new SelectList(db.tipo, "TipoID", "nombre", vehiculo.TipoID);
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase archivo)
        {
            if (id == null) {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 
            }
            var vehiculo = db.Vehiculoes.Find(id);
            if (TryUpdateModel(vehiculo,"",new String[] { "idVehiculo,numeroMotor,color,TipoID,ModeloID,MarcaID,LineaID" })) {
                try {
                    if (archivo !=null && archivo.ContentLength> 0) {
                        if (vehiculo.archivos.Any(f=> f.tipo==TipoArchivo.JPG))  {
                            db.archivo.Remove(vehiculo.archivos.First(f => f.tipo == TipoArchivo.JPG));
                        }
                        var imagen = new Archivo
                        {
                            nombre = System.IO.Path.GetFileName(archivo.FileName),
                            tipo   = TipoArchivo.JPG,
                            tipoContenido = archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream)) {

                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);

                        }
                        vehiculo.archivos = new List<Archivo> { imagen };
                    }
                    db.Entry(vehiculo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(RetryLimitExceededException ex){
                    ModelState.AddModelError("","Imposible guardar los cambios...");

                }
              
            }


              return View(vehiculo);
    }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo.archivos.Any(f => f.tipo == TipoArchivo.JPG))
            {
                db.archivo.Remove(vehiculo.archivos.First(f => f.tipo == TipoArchivo.JPG));
            }
            db.Entry(vehiculo).State = EntityState.Deleted;
            db.Vehiculoes.Remove(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
