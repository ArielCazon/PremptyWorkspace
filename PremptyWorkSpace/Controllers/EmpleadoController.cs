using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;
using System.Web.Security;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data;
using PagedList;


namespace PremptyWorkSpace.Controllers
{
    public class EmpleadoController : Controller
    {

        private PremptyDb db = new PremptyDb();

        // GET: /Empleado/

        public ActionResult Index()
        {
            return View();
        }

        //Devuelve todos los empleados por area que se asigno (como obtener ese dato?)
        public ViewResult Details(int id, string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "lastname" ? "lastname_desc" : "lastname";
            ViewBag.UserNameSortParm = sortOrder == "username" ? "username_desc" : "username";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.Id = id;

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString; 


            var users = (from u in db.Usuarios
                         where u.IdArea.Equals(id)
                         && u.Entidades.IdEntidad.Equals(1) //"CEL3 colocar entidad
                         select u);

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(x => x.NombreUsuario.Contains(searchString)
                                       || x.Apellido.Contains(searchString)
                                       || x.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Nombre);
                    break;
                case "date":
                    users = users.OrderBy(s => s.FechaIngreso);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.FechaIngreso);
                    break;
                case "lastname":
                    users = users.OrderBy(s => s.Apellido);
                    break;
                case "lastname_desc":
                    users = users.OrderByDescending(x => x.Apellido);
                    break;
                case "username":
                    users = users.OrderBy(x => x.IdUsuario);
                    break;
                case "username_desc":
                    users = users.OrderByDescending(x => x.NombreUsuario);
                    break;
                default:
                    users = users.OrderBy(s => s.Nombre);
                    break;
            }

            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View(users.ToPagedList(pageIndex, pageSize)); 
        }

    }
}
