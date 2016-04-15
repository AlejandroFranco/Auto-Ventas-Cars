using AutoVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVentas.Controllers
{
    public class CuentaController : Controller
    {
        public DB_AUTOVENTAS_CARS db = new DB_AUTOVENTAS_CARS();
            // GET: Cuenta
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            int id;
            var usr = db.usuario.FirstOrDefault(u => u.correo == usuario.correo && u.password == usuario.password);
            if (usr != null)
            {
                if (usr.rol.idRol == 1) {
                    id = 1;
                }
                else {
                    id = 2;
                }
                Session["rol_idRol"] = usr.rol.idRol;
                Session["username"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion(id);
            }
            else {
                ModelState.AddModelError("", "Verifique sus credenciales");
            }

            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid) {
                Rol rol = db.rol.FirstOrDefault(r => r.idRol == 1);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " Fue registrado exitosamente.";
                ModelState.Clear();
            } 
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("idUsuario");
            Session.Remove("username");
            return RedirectToAction("../Principal/Index");

        }
        public ActionResult VerificarSesion(int id)
        {
            if (Session["idUsuario"] != null)
            {
                if (id == 1) {
                    return RedirectToAction("../Cliente/Index");
                }
                else {

                    return RedirectToAction("../Home/Index");
                }
                    
                
            }
            else {
                return RedirectToAction("Login");
            }

          

       
        }
    }
}