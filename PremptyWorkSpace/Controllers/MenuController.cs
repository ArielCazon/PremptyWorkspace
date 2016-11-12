using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremptyWorkSpace.Models;
using System.Web.Security;

namespace PremptyWorkSpace.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Index(Login l, string ReturnUrl = "")
        {
            return View();
        }

        public ActionResult Select()
        {
            PremptyDb dc = new PremptyDb();
            var areas = dc.Areas.ToList();
            return View(areas);
        }

    }
}
