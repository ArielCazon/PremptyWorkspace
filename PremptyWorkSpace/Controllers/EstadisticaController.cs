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
    public class EstadisticaController : Controller
    {
        //
        // GET: /Estadistica/

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

            ViewBag.IdMes = new SelectList(mes, "Id", "Nombre");


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

            //Lista de Ausencias              
            var ausencias = dc.MotivoLicencia.ToList();
            var motivo = new List<MotivoLicencia>();

            for (int i = 0; i < ausencias.Count; i++)
            {
                motivo.Add(new MotivoLicencia()
                {
                    IdMotivo = ausencias[i].IdMotivo,
                    Descripcion = ausencias[i].Descripcion
                });
            }
            ViewBag.IdMotivo = new SelectList(motivo, "IdMotivo", "Descripcion");

            return View();
        }

        public ActionResult Visual([Bind(Include = "IdArea, IdMes, IdMotivo")]UsuarioLic usuLic)
        {
            PremptyDb dc = new PremptyDb();

            var user_linc = (from u in dc.Usuarios
                             join l in dc.Licencias
                             on u.IdUsuario equals l.IdUsuario
                             join a in dc.Areas
                             on u.IdArea equals a.IdArea
                             where u.IdArea.Equals(usuLic.IdArea)
                             && (l.FechaInicio.Month.Equals(usuLic.IdMes)
                             && l.FechaFin.Month.Equals(usuLic.IdMes))

                             select new
                             {
                                 Nombre = u.Nombre,
                                 Apellido = u.Apellido,
                                 NombreUsuario = u.NombreUsuario,
                                 AreaDescripcion = a.Descripcion,
                                 FechaInicio = l.FechaInicio,
                                 FechaFin = l.FechaFin
                             });

            return View(user_linc);
        }


        public ActionResult Download()
        {
            PremptyDb dc = new PremptyDb();

            var gv = new GridView();
            gv.DataSource = (from u in dc.Usuarios
                             join l in dc.Licencias
                             on u.IdUsuario equals l.IdUsuario
                             join a in dc.Areas
                             on u.IdArea equals a.IdArea
                             select new UsuarioLic
                             {
                                 Nombre = u.Nombre,
                                 Apellido = u.Apellido,
                                 NombreUsuario = u.NombreUsuario,
                                 AreaDescripcion = a.Descripcion,
                                 FechaInicio = l.FechaInicio,
                                 FechaFin = l.FechaFin
                             });

            //foreach (var item in gv)
            //{

            //    resultado.Add(new ControlHsViewModel()
            //    {
            //        Nombre = item.Nombre,
            //        Apellido = item.Apellido,
            //        HoraIngreso = item.HoraIngreso,
            //        HoraEgreso = item.HoraEgreso
            //    });
            //}

            //ViewData["AreaDescr"] = gv.;

            gv.DataBind();  //error
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename = Empleados.xls");
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
