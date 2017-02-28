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

            ObtenerListaDeAreas();

            return View();
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index([Bind(Include = "IdArea, FechaInicio, FechaFin")]ControlHsViewModel ctrlHs, int? page)
        {
            return Paginar(ctrlHs, ref page);
        }

        public ActionResult Filter([Bind(Include = "IdArea, FechaInicio, FechaFin")]ControlHsViewModel ctrlHs, int? page)
        {
            return Paginar(ctrlHs, ref page);
        }

        private ActionResult Paginar(ControlHsViewModel ctrlHs, ref int? page)
        {


            ObtenerListaDeAreas();

            var idAreaI = ctrlHs.IdArea;
            ViewBag.IdAreaSeleccionada = ctrlHs.IdArea;
            ViewBag.FechaInicio = ctrlHs.FechaInicio;
            ViewBag.FechaFin = ctrlHs.FechaFin;

            var resultado = ObtenerCantidadDeIngresos(ctrlHs);

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageSize = 5;
            int pageIndex = (page ?? 1);
            return View("Index", resultado.ToPagedList(pageIndex, pageSize));
        }

        private static List<ControlHsViewModel> ObtenerCantidadDeIngresos(ControlHsViewModel ctrlHs)
        {
            var resultado = new List<ControlHsViewModel>();

            if (ctrlHs.IdArea > 0)
            {
                PremptyDb dc = new PremptyDb();
                var usuariosPorArea = (from u in dc.Usuarios
                                       where u.IdArea.Equals(ctrlHs.IdArea)
                                       && u.Entidades.IdEntidad.Equals(1)
                                       select u).ToList();

                foreach (var item in usuariosPorArea)
                {
                    DateTime fechaInicial_aux = Convert.ToDateTime(ctrlHs.FechaInicio);
                    DateTime fechaFinal_aux = Convert.ToDateTime(ctrlHs.FechaFin);

                    int cantidad_ingreso = (from u in dc.Usuarios
                                            join i in dc.Ingresos
                                            on u.IdUsuario equals i.IdUsuario
                                            where u.IdArea.Equals(ctrlHs.IdArea)
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
            return resultado;
        }


        public ActionResult Download([Bind(Include = "IdArea, FechaInicio, FechaFin")]ControlHsViewModel ctrlHs)
        {

            var registros = ObtenerCantidadDeIngresos(ctrlHs);

            var fechaInicio = ctrlHs.FechaInicio.ToString();
            var fechaFin = ctrlHs.FechaFin.ToString();
            var nombreArchivo = string.Format("Asistencia_{0}_{1}.xls", fechaInicio, fechaFin);
            var resultadoFormateado = registros.Select(a => new {
            Nombre = a.Nombre,
            Apellido = a.Apellido,
            Cantidad_De_Ingresos = a.CantIngresos
            });

            var gv = new GridView();

            gv.DataSource = resultadoFormateado;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename =" + nombreArchivo);
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
