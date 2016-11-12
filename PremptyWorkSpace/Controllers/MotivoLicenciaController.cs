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
    public class MotivoLicenciaController : Controller
    {
        private PremptyDb db = new PremptyDb();

        //
        // GET: /MotivoLicencia/

        public ActionResult Index()
        {
            return View(db.MotivoLicencia.ToList());
        }

        //
        // GET: /MotivoLicencia/Details/5

        public ActionResult Details(int id = 0)
        {
            MotivoLicencia motivolicencia = db.MotivoLicencia.Find(id);
            if (motivolicencia == null)
            {
                return HttpNotFound();
            }
            return View(motivolicencia);
        }

        //
        // GET: /MotivoLicencia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MotivoLicencia/Create

        [HttpPost]
        public ActionResult Create(MotivoLicencia motivolicencia)
        {
            if (ModelState.IsValid)
            {

                Int32 id = (Int32)Session["sesIdUsuario"];
                var usuar = db.Usuarios.Find(id);
                motivolicencia.IdEntidad = usuar.IdEntidad;
                
                motivolicencia.Descripcion = motivolicencia.Descripcion;
                db.MotivoLicencia.Add(motivolicencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motivolicencia);
        }

        //
        // GET: /MotivoLicencia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MotivoLicencia motivolicencia = db.MotivoLicencia.Find(id);
            if (motivolicencia == null)
            {
                return HttpNotFound();
            }
            Session["IdMotivo"] = id;
            return View(motivolicencia);
        }

        //
        // POST: /MotivoLicencia/Edit/5

        [HttpPost]
        public ActionResult Edit(MotivoLicencia motivolicencia)
        {
            if (ModelState.IsValid)
            {
                Int32 id = (Int32)Session["sesIdUsuario"];
                var usuar = db.Usuarios.Find(id);
                motivolicencia.IdMotivo = (Int32)Session["IdMotivo"];
                motivolicencia.IdEntidad = usuar.IdEntidad;
                motivolicencia.Descripcion = motivolicencia.Descripcion;
                db.Entry(motivolicencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motivolicencia);
        }

        //
        // GET: /MotivoLicencia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MotivoLicencia motivolicencia = db.MotivoLicencia.Find(id);
            if (motivolicencia == null)
            {
                return HttpNotFound();
            }
            return View(motivolicencia);
        }

        //
        // POST: /MotivoLicencia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MotivoLicencia motivolicencia = db.MotivoLicencia.Find(id);
            db.MotivoLicencia.Remove(motivolicencia);
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