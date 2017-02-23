using PremptyWorkSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using System.Data.Entity.Validation;
using System.Data;

namespace PremptyWorkSpace.Controllers
{
    public class PerfilUsuarioController : Controller
    {
        private PremptyDb db = new PremptyDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novedades()
        {
            var db = new PremptyDb();
            var idEntidad = int.Parse(Session["IdEntidad"].ToString());
            var proximosEventos = db.Eventos.Where(x => x.Fecha > DateTime.Today).Where(x=>x.Entidades.IdEntidad == idEntidad);
            var NovedadesList = new List<NovedadesViewModel>();
            foreach (var evento in proximosEventos)
            {
                var item = new NovedadesViewModel()
                {
                    Fecha = evento.Fecha.ToString("dd/MM/yy"),
                    Descripcion = evento.Descripcion,
                    Titulo = evento.Titulo,
                    IdEventos = evento.IdEventos,
                    Areas = evento.Areas == null ? "Todas" : evento.Areas.Descripcion
                };
                NovedadesList.Add(item);
            }

            var eventosDeHoy = db.Eventos.Where(x => x.Fecha == DateTime.Today).Where(x => x.Entidades.IdEntidad == idEntidad);
            var novedadesDelDia = new List<NovedadesViewModel>();

            foreach (var evento in eventosDeHoy)
            {
                var item = new NovedadesViewModel()
                {
                    Fecha = evento.Fecha.ToString("dd/MM/yy"),
                    Descripcion = evento.Descripcion,
                    Titulo = evento.Titulo,
                    IdEventos = evento.IdEventos,
                    Areas = evento.Areas == null ? "Todas" : evento.Areas.Descripcion
                };
                novedadesDelDia.Add(item);
            }

            ViewBag.EventosDelDia = novedadesDelDia;
            return View(NovedadesList);
        }

        public ActionResult Licencia()
        {
            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            var licencias = db.Licencias.Where(x => x.IdUsuario == idUsuario);


            var licenciasList = new List<LicenciaViewModel>();
            foreach (var licencia in licencias)
            {
                var estado = (EstadoLicenciaEnum)licencia.Estado;
                var item = new LicenciaViewModel()
                {
                    Estado = estado.ToString(),
                    Descripcion = licencia.Descripcion,
                    Fecha = licencia.Fecha.ToString("dd/MM/yyyy"),
                    IdLicencia = licencia.IdLicencia,
                    Motivo = licencia.MotivoLicencia.Descripcion,
                    Usuario = licencia.Usuarios.Nombre + ' ' + licencia.Usuarios.Apellido
                };

                licenciasList.Add(item);

            }

            ViewBag.Motivo = new SelectList(db.MotivoLicencia, "IdMotivo", "Descripcion");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View(licenciasList);
        }

        public ActionResult SolicitarLicencia()
        {
            ViewBag.Motivo = new SelectList(db.MotivoLicencia, "IdMotivo", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult SolicitarLicencia(Licencias licencia)
        {
            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            licencia.Estado = (int)EstadoLicenciaEnum.Pendiente;
            licencia.IdUsuario = idUsuario;

            if (ModelState.IsValid)
            {
                db.Licencias.Add(licencia);
                db.SaveChanges();
                return RedirectToAction("Licencia");
            }

            ViewBag.Motivo = new SelectList(db.MotivoLicencia, "IdMotivo", "Descripcion", licencia.Motivo);
            return View(licencia);
        }

        public ActionResult Horas()
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
            return RedirectToAction("Horas", "PerfilUsuario");
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
            return RedirectToAction("Horas", "PerfilUsuario");
        }


        public ActionResult Perfil()
        {
            int id = Convert.ToInt32(Session["sesIdUsuario"]);

            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        public ActionResult EditarPerfil(int id)
        {

            Usuarios usuarios = db.Usuarios.Single(x => x.IdUsuario == id);

            Session["IdUsu"] = id;

            return View(usuarios);
        }



        [HttpPost]
        public ActionResult EditarPerfil(Usuarios user)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    //mostrar en el formulario  todos los datos obligatorios de la bbdd
                    Int32 id = (Int32)Session["IdUsu"];
                    var usuar = db.Usuarios.Find(id);
                    usuar.Nombre = user.Nombre;
                    usuar.Apellido = user.Apellido;
                    usuar.NombreUsuario = user.NombreUsuario;
                    usuar.FechaNac = user.FechaNac;
                    var area = db.Areas.FirstOrDefault(x => x.IdArea == user.IdArea);
                    usuar.Email = user.Email;
                    usuar.Domicilio = user.Domicilio;
                    db.Entry(usuar).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Perfil");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

            }

            return View(user);
        }






    }
}
