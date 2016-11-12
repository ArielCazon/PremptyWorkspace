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
    public class AreasController : Controller
    {
        private PremptyDb db = new PremptyDb();

        //
        // GET: /Areas/

        public ActionResult Index()
        {
            var areas = db.Areas.Include(a => a.Entidades);
            return View(areas.ToList());
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}