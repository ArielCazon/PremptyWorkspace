using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;

namespace PremptyWorkSpace.Controllers
{
    public class HorasController : Controller
    {
        private PremptyDb db = new PremptyDb();

        public ActionResult Index()
        {
            string horaSalida = "-";
            string horaEntrada = "-";

            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            var registroingreso = (from i in db.Ingresos
                                   where EntityFunctions.TruncateTime(i.FechaActual) == DateTime.Today &&
                                       i.IdUsuario == idUsuario
                                   select i).FirstOrDefault();
            if (registroingreso != null)
            {
                horaEntrada = registroingreso.HoraIngreso.ToString();
                if (registroingreso.HoraEgreso != registroingreso.HoraIngreso)
                    horaSalida = registroingreso.HoraEgreso.ToString();
            }
            ViewBag.HoraIngreso = horaEntrada;
            ViewBag.HoraSalida = horaSalida;
            return View();
        }

        public ActionResult MarcarEntrada()
        {
            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            var usuario = db.Usuarios.First(x => x.IdUsuario == idUsuario);
            var registroDelDia = (from i in db.Ingresos
                                  where EntityFunctions.TruncateTime(i.FechaActual) == DateTime.Today &&
                                      i.IdUsuario == idUsuario
                                  select i).FirstOrDefault();

            if (registroDelDia == null)
            {
                var ingreso = new Ingresos()
                {
                    Usuarios = usuario,
                    FechaActual = DateTime.Now,
                    HoraIngreso = DateTime.Now,
                    HoraEgreso = DateTime.Now,
                };

                db.Ingresos.Add(ingreso);

                db.SaveChanges();
            }
            return RedirectToAction("Index", "Horas");
        }

        public ActionResult MarcarSalida()
        {
            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            var usuario = db.Usuarios.First(x => x.IdUsuario == idUsuario);
            var registroDelDia = (from i in db.Ingresos
                                  where EntityFunctions.TruncateTime(i.FechaActual) == DateTime.Today &&
                                      i.IdUsuario == idUsuario
                                  select i).FirstOrDefault();

            if (registroDelDia != null)
            {
                if (registroDelDia.HoraEgreso == registroDelDia.HoraIngreso)
                {
                    registroDelDia.HoraEgreso = DateTime.Now;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Horas");
        }




    }
}
