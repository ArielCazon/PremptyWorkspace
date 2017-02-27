using PremptyWorkSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using System.Data.Entity.Validation;
using System.Data;
using System.Data.Entity;
using PagedList;

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
            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            var proximosEventos = db.Eventos.Include(e => e.Respuestas)
                .Where(x => x.Fecha > DateTime.Today)
                .Where(x => x.Entidades.IdEntidad == idEntidad)
                .Where(x => !x.Respuestas.Where(r => r.IdUsuario == idUsuario).Any())
                .OrderBy(x => x.Fecha).Take(4);


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


        public ViewResult Licencia(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.SearchString = searchString;

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;

            var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());
            var idEntidad = int.Parse(Session["IdEntidad"].ToString());
            var licencias = db.Licencias.Include(l => l.MotivoLicencia).Include(l => l.Usuarios).Where(x => x.MotivoLicencia.IdEntidad == idEntidad).Where(x => x.IdUsuario == idUsuario);

            if (!String.IsNullOrEmpty(searchString))
            {
                licencias = licencias.Where(x => x.Descripcion.Contains(searchString)
                           || x.MotivoLicencia.Descripcion.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    licencias = licencias.OrderByDescending(s => s.Usuarios.Nombre);
                    break;
                case "date":
                    licencias = licencias.OrderBy(s => s.Fecha);
                    break;
                case "date_desc":
                    licencias = licencias.OrderByDescending(s => s.Fecha);
                    break;
                default:
                    licencias = licencias.OrderBy(s => s.Usuarios.Nombre);
                    break;
            }

            var motivos = db.MotivoLicencia.Where(x => x.IdEntidad == idEntidad);
            var usuarios = db.Usuarios.Where(x => x.IdEntidad == idEntidad);
            ViewBag.Motivo = new SelectList(motivos, "IdMotivo", "Descripcion");
            ViewBag.IdUsuario = new SelectList(usuarios, "IdUsuario", "Nombre");

            List<LicenciaViewModel> listaViewModel = ListFromLicencia(licencias.ToList());
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View(listaViewModel.ToPagedList(pageIndex, pageSize));

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

        public JsonResult OpinarNovedad(int idNovedad, int respuesta)
        {

            if (idNovedad != 0 && respuesta != 0)
            {
                var idUsuario = int.Parse(Session["sesIdUsuario"].ToString());

                var respuestaExistente = db.Respuestas.FirstOrDefault(x => x.IdEvento == idNovedad && x.IdUsuario == idUsuario);
                if (respuestaExistente == null)
                {
                    db.Respuestas.Add(new Respuestas()
                    {
                        IdUsuario = idUsuario,
                        Respuesta = respuesta,
                        IdEvento = idNovedad
                    });
                    db.SaveChanges();
                    return Json(true);
                }
                return Json(true);
            }
            return Json(false);
        }
        private LicenciaViewModel FromLicencia(Licencias licencia)
        {
            var estado = (EstadoLicenciaEnum)licencia.Estado;

            string legajo = licencia.Usuarios.Legajo.Value.ToString();
            var viewmodel = new LicenciaViewModel()
            {
                Descripcion = licencia.Descripcion,
                Estado = estado.ToString(),
                Fecha = licencia.Fecha.ToString("dd/MM/yyyy"),
                IdLicencia = licencia.IdLicencia,
                Motivo = licencia.MotivoLicencia.Descripcion,
                Usuario = licencia.Usuarios.Apellido + " ," + licencia.Usuarios.Nombre + " (" + legajo + ")"

            };
            return viewmodel;
        }

        private List<LicenciaViewModel> ListFromLicencia(List<Licencias> licencias)
        {
            var listaLicenciaViewModel = new List<LicenciaViewModel>();

            foreach (var licencia in licencias)
            {
                listaLicenciaViewModel.Add(FromLicencia(licencia));
            }

            return listaLicenciaViewModel;
        }
    }
}
