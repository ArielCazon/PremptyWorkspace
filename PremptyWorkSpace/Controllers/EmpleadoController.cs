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
        public ActionResult Details(int id)
        {

            var user = (from u in db.Usuarios
                        where u.IdArea.Equals(id)
                        select u).ToList();


            return View(user);
        }



    }
}
