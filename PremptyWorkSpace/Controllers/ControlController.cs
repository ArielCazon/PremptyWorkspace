using PremptyWorkSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;



namespace PremptyWorkSpace.Controllers
{
    public class ControlController : Controller
    {
        //
        // GET: /Control/

        public ActionResult Index()
        {

            var mes = new List<Mes>();

            mes.Add(new Mes()
            {
                Id = 1,
                Nombre = "Enero"
            });
            mes.Add(new Mes()
            {
                Id = 2,
                Nombre = "Febrero"
            });
            mes.Add(new Mes()
            {
                Id = 3,
                Nombre = "Marzo"
            });
            mes.Add(new Mes()
            {
                Id = 4,
                Nombre = "Abril"
            });
            mes.Add(new Mes()
            {
                Id = 5,
                Nombre = "Mayo"
            });
            mes.Add(new Mes()
            {
                Id = 6,
                Nombre = "Junio"
            });
            mes.Add(new Mes()
            {
                Id = 7,
                Nombre = "Julio"
            });
            mes.Add(new Mes()
            {
                Id = 8,
                Nombre = "Agosto"
            });
            mes.Add(new Mes()
            {
                Id = 9,
                Nombre = "Septiembre"
            });
            mes.Add(new Mes()
            {
                Id = 10,
                Nombre = "Octubre"
            });
            mes.Add(new Mes()
            {
                Id = 11,
                Nombre = "Noviembre"
            });
            mes.Add(new Mes()
            {
                Id = 12,
                Nombre = "Diciembre"
            });

            // var list = new SelectList(mes, "Id", "Nombre");
            // ViewData["mes"] = list;
            //var areaList = new SelectList(area, "IdArea", "Descripcion");
            //ViewData["area"] = areaList;
            //ControlHsViewModel ctrlHs = new ControlHsViewModel();

            //Conexion a la base de datos
            PremptyDb dc = new PremptyDb();

            //Lista de Areas
            var areas = dc.Areas.ToList();
            var area = new List<Areas>();

            for (int i = 0; i < areas.Count; i++)
            {
                area.Add(new Areas()
                {
                    IdArea = areas[i].IdArea,
                    Descripcion = areas[i].Descripcion
                });

            }

            ViewBag.IdArea = new SelectList(area, "IdArea", "Descripcion");

            ViewBag.IdMes = new SelectList(mes, "Id", "Nombre");

            return View();
        }


        public ActionResult Visual([Bind(Include = "IdArea, IdMes")]ControlHsViewModel ctrlHs)
        {
            PremptyDb dc = new PremptyDb();

            var idAreaI = ctrlHs.IdArea;
            var idMesI = ctrlHs.IdMes;

            Session["s_idAreaI"] = ctrlHs.IdArea;
            Session["s_idMesI"] = ctrlHs.IdMes;

            var resultado = new List<ControlHsViewModel>();

            if (idAreaI > 0 && idMesI > 0)
            {
                var user_ingreso = from u in dc.Usuarios
                                   join i in dc.Ingresos
                                   on u.IdUsuario equals i.IdUsuario
                                   where u.IdArea.Equals(idAreaI)
                                   && i.FechaActual.Month.Equals(idMesI)
                                   select new
                                   {
                                       Nombre = u.Nombre,
                                       Apellido = u.Apellido,
                                       HoraIngreso = i.HoraIngreso,
                                       HoraEgreso = i.HoraEgreso
                                   };


                foreach (var item in user_ingreso)
                {

                    resultado.Add(new ControlHsViewModel()
                    {
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        HoraIngreso = item.HoraIngreso.ToString(),
                        HoraEgreso = item.HoraEgreso.ToString()
                    });
                }
            }

            return View(resultado);
        }


        public ActionResult Download()
        {
            PremptyDb dc = new PremptyDb();

            var resultado = new List<ControlHsViewModel>();
            var gv = new GridView();

            Int32 idAreaI = (Int32)Session["s_idAreaI"];
            Int32 idMesI = (Int32)Session["s_idMesI"];

            var user_ingreso = from u in dc.Usuarios
                               join i in dc.Ingresos
                               on u.IdUsuario equals i.IdUsuario
                               where u.IdArea.Equals(idAreaI)
                               && i.FechaActual.Month.Equals(idMesI)
                               select new
                               {
                                   Nombre = u.Nombre,
                                   Apellido = u.Apellido,
                                   HoraIngreso = i.HoraIngreso,
                                   HoraEgreso = i.HoraEgreso
                               };

            foreach (var item in user_ingreso)
            {

                resultado.Add(new ControlHsViewModel()
                {
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    HoraIngreso = item.HoraIngreso.ToString(),
                    HoraEgreso = item.HoraEgreso.ToString()
                });
            }

            gv.DataSource = resultado;

            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename = _Empleados_Area.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View();
        }


    }
}
