using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using PremptyWorkSpace.Models;
using System.Web.Security;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using System.IO;


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

        [HttpPost]
        public ActionResult Nosotros(MailModel objModelMail)
        {
            if (ModelState.IsValid)
            {
                string from = "yucramitarodrigo@gmail.com"; //example:- sourabh9303@gmail.com
                using (MailMessage mail = new MailMessage(from, objModelMail.To))
                {
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body;
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "Your Gmail Password");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("Nosotros", objModelMail);
                }
            }
            else
            {
                return View();
            }
        }

    }
}

