using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;
using PagedList;

namespace PremptyWorkSpace.Controllers
{
    public class AreasController : Controller
    {
        private PremptyDb db = new PremptyDb();

        public ViewResult Index(string sortOrder, string searchString,string currentFilter,int? page)
        {
            ViewBag.DecripcionSortParm = String.IsNullOrEmpty(sortOrder) ? "decripcion_desc" : "";
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

            var areas = db.Areas.Include(a => a.Entidades);

            if (!String.IsNullOrEmpty(searchString))
            {
                areas = areas.Where(x => x.Descripcion.Contains(searchString));
                                     
                                      
            }
            switch (sortOrder)
            {
                case "descripcion_desc":
                    areas = areas.OrderByDescending(s => s.Descripcion);
                    break;
                default:
                    areas = areas.OrderBy(s => s.Descripcion);
                    break;
            }
           
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View(areas.ToPagedList(pageIndex, pageSize)); 

        }

        //
        // GET: /Areas/Details/5

        public ActionResult Details(int id = 0)
        {
            Areas area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        //
        // GET: /Areas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Areas/Create

        [HttpPost]
        public ActionResult Create(Areas area)
        {
            if (ModelState.IsValid)
            {
                if (Session["IdEntidad"] == null)
                {
                    return RedirectToAction("Login", "Home");
                }

                var idEntidad = int.Parse(Session["IdEntidad"].ToString());
                area.IdEntidad = idEntidad;
                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(area);
        }

        //
        // GET: /Areas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Areas area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            Session["IdArea"] = id;
            ViewBag.IdEntidad = new SelectList(db.Entidades, "IdEntidad", "RazonSocial", area.IdEntidad);
            return View(area);
        }

        //
        // POST: /Areas/Edit/5

        [HttpPost]
        public ActionResult Edit(Areas area)
        {
            if (ModelState.IsValid)
            {

                area.IdArea = (Int32)Session["IdArea"];
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEntidad = new SelectList(db.Entidades, "IdEntidad", "RazonSocial", area.IdEntidad);
            return View(area);
        }

        //
        // GET: /Areas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Areas area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mensaje = ValidarUsuariosAsociados(id);
            return View(area);
        }

        //
        // POST: /Areas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Areas area = db.Areas.Find(id);
            db.Areas.Remove(area);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string ValidarUsuariosAsociados(int idArea)
        {
            var usuariosAsociados = db.Usuarios.Where(x => x.Areas.IdArea == idArea).ToList();

            if (usuariosAsociados.Count() > 0)
            {
                return string.Format("El Area que desea eliminar está asociada a {0} usuarios", usuariosAsociados.Count());
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}