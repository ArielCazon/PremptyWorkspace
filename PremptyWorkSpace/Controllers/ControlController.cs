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
using PagedList;



namespace PremptyWorkSpace.Controllers
{
    public class ControlController : Controller
    {
        //
        // GET: /Control/

        public ActionResult Index()
        {
            //Metodos para completar el DropDown List
            ObtenerListaDeMeses();

            ObtenerListaDeAreas();

            return View();
        }



        private void ObtenerListaDeMeses()
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

            ViewBag.IdMes = new SelectList(mes, "Id", "Nombre");

        }

        private void ObtenerListaDeAreas()
        {
            //Conexion a la base de datos
            PremptyDb dc = new PremptyDb();

            //Lista de Areas
            var areasDb = (from a in dc.Areas
                           join e in dc.Entidades
                           on a.IdEntidad equals e.IdEntidad
                           where e.IdEntidad.Equals(1)               // CEL3 obtener de session
                           select a).ToList();

            var area = new List<Areas>();

            for (int i = 0; i < areasDb.Count; i++)
            {
                area.Add(new Areas()
                {
                    IdArea = areasDb[i].IdArea,
                    Descripcion = areasDb[i].Descripcion
                });

            }

            ViewBag.IdArea = new SelectList(area, "IdArea", "Descripcion");
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "IdArea, FechaInicio, FechaFin")]ControlHsViewModel ctrlHs, string searchString, string currentFilter, int? page,string sortOrder)
        {
            PremptyDb dc = new PremptyDb();

            ObtenerListaDeAreas();

            var idAreaI = ctrlHs.IdArea;
            Session["s_idAreaI"] = ctrlHs.IdArea;
            Session["s_fechaIni"] = ctrlHs.FechaInicio;
            Session["s_fechaFin"] = ctrlHs.FechaFin;

            var resultado = new List<ControlHsViewModel>();

            if (idAreaI > 0 )
            {

                var usuariosPorArea = (from u in dc.Usuarios
                                where u.IdArea.Equals(idAreaI)
                                && u.Entidades.IdEntidad.Equals(1)
                                select u).ToList();

                foreach (var item in usuariosPorArea)
                {
                    DateTime fechaInicial_aux = Convert.ToDateTime(ctrlHs.FechaInicio);
                    DateTime fechaFinal_aux = Convert.ToDateTime(ctrlHs.FechaFin);

                    int cantidad_ingreso = (from u in dc.Usuarios
                                             join i in dc.Ingresos
                                             on u.IdUsuario equals i.IdUsuario
                                             where u.IdArea.Equals(idAreaI)
                                             && i.FechaActual >= fechaInicial_aux
                                             && i.FechaActual <= fechaFinal_aux
                                             && i.IdUsuario.Equals(item.IdUsuario)
                                             && u.Entidades.IdEntidad.Equals(1)
                                             select u).Count();   

                    resultado.Add(new ControlHsViewModel()
                    {
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        CantIngresos = cantidad_ingreso
                    });

                }
            }
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            ViewBag.tablaResultado = new SelectList(resultado, "Nombre", "Apellido", "CantIngresos");
            int pageSize = 10;
            int pageIndex = (page ?? 1);
            return View("Index",resultado.ToPagedList(pageIndex, pageSize)); 
        }


        public ActionResult Download()
        {
            PremptyDb dc = new PremptyDb();

            List<ControlHsViewModel> resultado = (List<ControlHsViewModel>)ViewBag.tablaResultado;
            var gv = new GridView();

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
