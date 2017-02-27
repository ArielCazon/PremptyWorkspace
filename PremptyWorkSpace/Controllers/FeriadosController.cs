using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;
using System.Data.Entity.Validation;

namespace PremptyWorkSpace.Controllers
{
    public class FeriadosController : Controller
    {
        private PremptyDb db = new PremptyDb();

        //
        // GET: /Feriados/

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date desc" : "";
            ViewBag.SearchString = searchString;

            var anioActual = DateTime.Today.Year;
            var feriados = db.Feriados.Where(x => x.Fecha.Year == anioActual);

            if (!String.IsNullOrEmpty(searchString))
            {
                feriados = feriados.Where(x => x.Descripcion.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date desc":
                    feriados = feriados.OrderByDescending(s => s.Fecha);
                    break;

                default:
                    feriados = feriados.OrderBy(s => s.Fecha);
                    break;
            }
            return View(feriados.ToList());
        }
        //
        // GET: /Feriados/Details/5

        public ActionResult Details(int id = 0)
        {
            Feriados feriados = db.Feriados.Find(id);
            if (feriados == null)
            {
                return HttpNotFound();
            }
            return View(feriados);
        }

        //
        // GET: /Feriados/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Feriados/Create

        [HttpPost]

        public ActionResult Create(Feriados feriados)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    feriados.IdFeriado = feriados.IdFeriado;
                    feriados.Fecha = feriados.Fecha;
                    feriados.Descripcion = feriados.Descripcion;

                    db.Feriados.Add(feriados);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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


            return View(feriados);
        }

        //
        // GET: /Feriados/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Feriados feriados = db.Feriados.Find(id);
            if (feriados == null)
            {
                return HttpNotFound();
            }
            Session["IdFeriado"] = id;
            return View(feriados);
        }

        //
        // POST: /Feriados/Edit/5

        [HttpPost]
        public ActionResult Edit(Feriados feriados)
        {
            if (ModelState.IsValid)
            {
                feriados.IdFeriado = (Int32)Session["IdFeriado"];
                feriados.Fecha = feriados.Fecha;
                feriados.Descripcion = feriados.Descripcion;

                db.Entry(feriados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feriados);
        }

        //
        // GET: /Feriados/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Feriados feriados = db.Feriados.Find(id);
            if (feriados == null)
            {
                return HttpNotFound();
            }
            return View(feriados);
        }

        //
        // POST: /Feriados/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Feriados feriados = db.Feriados.Find(id);
            db.Feriados.Remove(feriados);
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