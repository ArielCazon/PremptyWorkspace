using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace PremptyWorkSpace.Controllers
{
    public class LicenciasController : Controller
    {
        private PremptyDb db = new PremptyDb();

        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
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

            var idEntidad = int.Parse(Session["IdEntidad"].ToString());
            var licencias = db.Licencias.Include(l => l.MotivoLicencia).Include(l => l.Usuarios).Where(x => x.MotivoLicencia.IdEntidad == idEntidad);

            if (!String.IsNullOrEmpty(searchString))
            {
                licencias = licencias.Where(x => x.Usuarios.Nombre.Contains(searchString)
                            || x.Usuarios.Apellido.Contains(searchString)
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

        //
        // GET: /Licencias/Details/5

        public ActionResult Details(int id = 0)
        {
            Licencias licencias = db.Licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        public ActionResult Aprobar(int id)
        {
            var licencia = db.Licencias.FirstOrDefault(x => x.IdLicencia == id);
            if (licencia != null)
            {
                licencia.Estado = (int)EstadoLicenciaEnum.Aprobado;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Index");
        }
        public ActionResult Rechazar(int id)
        {
            var licencia = db.Licencias.FirstOrDefault(x => x.IdLicencia == id);
            if (licencia != null)
            {
                licencia.Estado = (int)EstadoLicenciaEnum.Rechazado;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Index");
        }


        public ActionResult Create()
        {
            var idEntidad = int.Parse(Session["IdEntidad"].ToString());
            var motivos = db.MotivoLicencia.Where(x => x.IdEntidad == idEntidad);

            var usuarios = db.Usuarios.Where(x => x.IdEntidad == idEntidad);
            var comboUsuarios = new List<SelectListItem>();
            foreach (var usuario in usuarios)
            {
                var item = new SelectListItem()
                {
                    Value = usuario.IdUsuario.ToString(),
                    Text = usuario.Apellido + " ," + usuario.Nombre + "(" + usuario.Legajo + ")"
                };
                comboUsuarios.Add(item);
            }


            ViewBag.Motivo = new SelectList(motivos, "IdMotivo", "Descripcion");
            ViewBag.IdUsuario = comboUsuarios;
            return View();
        }

        //
        // POST: /Licencias/Create

        [HttpPost]
        public ActionResult Create(Licencias licencias)
        {
            var idEntidad = int.Parse(Session["IdEntidad"].ToString());
            licencias.Estado = (int)EstadoLicenciaEnum.Pendiente;
            if (ModelState.IsValid)
            {
                db.Licencias.Add(licencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var motivos = db.MotivoLicencia.Where(x => x.IdEntidad == idEntidad);
            var usuarios = db.Usuarios.Where(x => x.IdEntidad == idEntidad);

            ViewBag.Motivo = new SelectList(motivos, "IdMotivo", "Descripcion", licencias.Motivo);
            ViewBag.IdUsuario = new SelectList(usuarios, "IdUsuario", "Nombre", licencias.IdUsuario);
            return View(licencias);
        }

        // GET: /Licencias/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Licencias licencias = db.Licencias.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        //
        // POST: /Licencias/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Licencias licencias = db.Licencias.Find(id);
            db.Licencias.Remove(licencias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
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