using PremptyWorkSpace.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace PremptyWorkSpace.Controllers
{
    public class UsuariosController : Controller
    {
        private PremptyDb db = new PremptyDb();

        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LegajoSortParm = sortOrder == "legajo" ? "legajo_desc" : "legajo";
            ViewBag.LastNameSortParm = sortOrder == "lastname" ? "lastname_desc" : "lastname";
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

            var usuarios = db.Usuarios.Include(u => u.Areas).Include(u => u.Roles);

            if (!String.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(x => x.NombreUsuario.Contains(searchString)
                                      || x.Apellido.Contains(searchString)
                                      || x.Nombre.Contains(searchString));
                            
            }
            switch (sortOrder)
            {
                case "name_desc":
                    usuarios = usuarios.OrderByDescending(s => s.Nombre);
                    break;
                case "legajo":
                    usuarios = usuarios.OrderBy(s => s.Legajo);
                    break;
                case "legajo_desc":
                    usuarios = usuarios.OrderByDescending(s => s.Legajo);
                    break;
                case "lastname":
                    usuarios = usuarios.OrderBy(s => s.Apellido);
                    break;
                case "lastname_desc":
                    usuarios = usuarios.OrderByDescending(x => x.Apellido);
                    break;
                case "date":
                    usuarios = usuarios.OrderBy(s => s.FechaIngreso);
                    break;
                case "date_desc":
                    usuarios = usuarios.OrderByDescending(s => s.FechaIngreso);
                    break;
                default:
                    usuarios = usuarios.OrderBy(s => s.Nombre);
                    break;
            }
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View(usuarios.ToPagedList(pageIndex, pageSize)); 
           

        }

        public ActionResult Details(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        public ActionResult Edit(int id)
        {

            Usuarios usuarios = db.Usuarios.Single(x => x.IdUsuario == id);

            Session["IdUsu"] = id;

            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion", usuarios.IdArea);

            return View(usuarios);
        }



        [HttpPost]
        public ActionResult Edit(Usuarios user)
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
                    usuar.Areas = area;
                    usuar.Email = user.Email;
                    usuar.Domicilio = user.Domicilio;
                    db.Entry(usuar).State = EntityState.Modified;
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

            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion", user.IdArea);

            return View(user);
        }


        public ActionResult Create()
        {

            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion");
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuarios user)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    int id = Convert.ToInt32(Session["sesIdUsuario"]);
                    if (id != 0)
                    {
                        user.Nombre = user.Nombre;
                        user.Apellido = user.Apellido;
                        user.NombreUsuario = user.NombreUsuario;
                        user.FechaNac = user.FechaNac;
                        user.FechaIngreso = user.FechaIngreso;
                        user.Legajo = user.Legajo;
                        user.Password = user.Password;
                        var area = db.Areas.FirstOrDefault(x => x.IdArea == user.IdArea);
                        var rol = db.Roles.FirstOrDefault(x => x.IdRol == user.IdRol);
                        user.Areas = area;
                        user.Roles = rol;
                        user.Email = user.Email;
                        user.Domicilio = user.Domicilio;
                        user.IdEntidad = area.IdEntidad;
                        if (user != null)
                        {
                            db.Usuarios.Add(user);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
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

            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "Descripcion", user.IdArea);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", user.IdRol);

            return View(user);
        }


        public ActionResult Delete(int id = 0)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios != null)
            {
                EliminarRelaciones(id);
            }

            db.Usuarios.Remove(usuarios);           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void EliminarRelaciones(int idUsuario)
        {
            var licenciasVinculadas = db.Licencias.Where(x => x.IdUsuario == idUsuario);
            foreach (var licencia in licenciasVinculadas)
            {
                db.Licencias.Remove(licencia);
            }

            var ingresos = db.Ingresos.Where(x => x.IdUsuario == idUsuario);

            foreach (var ingreso in ingresos)
            { 
                db.Ingresos.Remove(ingreso);
            }

            var respuestasAsociadas = db.Respuestas.Where(x => x.IdUsuario == idUsuario);

            foreach (var respuesta in respuestasAsociadas)
            {
                db.Respuestas.Remove(respuesta);
            }

            db.SaveChanges();
        }

    }
}