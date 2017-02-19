using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;
using System.Web.Security;


namespace PremptyWorkSpace.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index(Usuarios usuario)
        {
            return View();
        }

        public ActionResult logIn()
        {
            return View();
        }
      

        [HttpPost]
    //    [ValidateAntiForgeryToken]
        public ActionResult logIn(Login l, string ReturnUrl = "")
        {
            if (string.IsNullOrEmpty(l.NombreUsuario))
            {
                ViewBag.Error = "Ingrese un nombre de usuario.";
                ModelState.Remove("Password");
                return View();
            }

            if (string.IsNullOrEmpty(l.Password))
            {
                ViewBag.Error = "Ingrese un password.";
                ModelState.Remove("Password");
                return View();
            }

            using (PremptyDb dc = new PremptyDb())
            {
                var user = dc.Usuarios.Where(a => a.NombreUsuario.Equals(l.NombreUsuario) && a.Password.Equals(l.Password)).FirstOrDefault();
                if (user != null)
                {
                    //Obtener IdUsuario para verificar la session del usuario
                    Session["sesIdUsuario"] = user.IdUsuario;
                    Session["sesNombCompleto"] = user.Nombre + " " + user.Apellido;
                    Session["IdEntidad"] = user.IdEntidad;



                    if (user.IdRol == 1) //Empleado
                    {
                        return RedirectToAction("Index", "PerfilUsuario");
                    }
                    if (user.IdRol == 2) //Administrador
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    if (user.IdRol == 3) //Gerente
                    {
                        return RedirectToAction("Index", "Menu");
                    }

                }
                else
                {
                    ViewBag.Error = "Credenciales Invalidas.";
                }
            }
            ModelState.Remove("Password");
            return View();

        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        public ActionResult Nosotros()
        {
            return View();
        }



    }
}
