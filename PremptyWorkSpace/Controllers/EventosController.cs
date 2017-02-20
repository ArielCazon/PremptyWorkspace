using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;


namespace PremptyWorkSpace.Controllers
{
    public class EventosController : Controller
    {
        private PremptyDb db = new PremptyDb();
        //
        // GET: /Eventos/

        public ActionResult Index()
        {
            var Eventos = db.Eventos.Include(l => l.Areas);
            return View(Eventos.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        public ActionResult Edit(int id = 0)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }

            Session["IdEvent"] = id;


            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion", eventos.IdArea);
            return View(eventos);
        }



        [HttpPost]
        public ActionResult Edit(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                eventos.IdEventos = (Int32)Session["IdEvent"];
                eventos.Titulo = eventos.Titulo;
                eventos.Descripcion = eventos.Descripcion;
                eventos.Fecha = eventos.Fecha;
                var area = db.Areas.FirstOrDefault(x => x.IdArea == eventos.IdArea);
                eventos.Areas = area;
                eventos.Tipo = eventos.Tipo;
                eventos.IdEntidad = area.IdEntidad;

                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion", eventos.IdArea);
            return View(eventos);
        }

        public ActionResult Create()
        {
            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                eventos.Titulo = eventos.Titulo;
                eventos.Descripcion = eventos.Descripcion;
                eventos.Fecha = eventos.Fecha;
                var area = db.Areas.FirstOrDefault(x => x.IdArea == eventos.IdArea);
                eventos.Areas = area;
                eventos.IdEntidad = area.IdEntidad;
                db.Eventos.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion", eventos.IdArea);
            return View(eventos);
        }

        public ActionResult Delete(int id = 0)
        {
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = db.Eventos.Find(id);
            db.Eventos.Remove(eventos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}
