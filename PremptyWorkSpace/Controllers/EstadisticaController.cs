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
            var array_ausencias = new List<Ingresos>();
            var user_area = new List<Usuarios>();
            int cantDiasHabiles = 0;
            int cantAusencias = 0;
            int cantPresencias = 0;
            DateTime fecha;


            //Se obtienen los USUARIOS
            if (usuLic.IdArea == 0) //Selecciono: Todas las Areas
            {
                user_area = (from u in dc.Usuarios
                             select u).ToList();
            }
            else
            {
                user_area = (from u in dc.Usuarios
                             where u.IdArea.Equals(usuLic.IdArea)
                             select u).ToList();
            }


            //Agregar feriados
            //Funcion de cantidad de feriados del mes seleccionado, sino retornar todo

            //Obtener Cant de Dias Habiles
            cantDiasHabiles = obtenerDiasHabiles(usuLic.IdMes, 2016);

            //Cuento la cantidad de asistencias del mes por empleado
            foreach (var item in user_area)
            {
                for (int j = 1; j < cantDiasHabiles; j++)
                {
                    //Fecha es variable de diaDelMes + usuLic.Mothn + añoActual == fecha habil del mes
                    fecha = new DateTime(2016, usuLic.IdMes, j);
                    var ingreso = (from u in dc.Usuarios
                                   join i in dc.Ingresos
                                   on u.IdUsuario equals i.IdUsuario
                                   where u.IdUsuario.Equals(item.IdUsuario)
                                         && i.FechaActual.Day.Equals(j)
                                         && i.FechaActual.Month.Equals(usuLic.IdMes)
                                         && i.FechaActual.Year.Equals(2016)
                                   select u).ToList();
                    if (ingreso.Count == 0)
                    {
                        cantAusencias++;
                        array_ausencias.Add(new Ingresos()
                        {
                            IdUsuario = item.IdUsuario,
                            FechaActual = fecha
                        });
                    }
                    else
                    {
                        cantPresencias++;
                    }

                }

            }


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("item"));
            dt.Columns.Add(new DataColumn("cantidad"));


            DataRow row1 = dt.NewRow();
            row1[0] = "Asistencias";
            row1[1] = cantPresencias;

            DataRow row2 = dt.NewRow();
            row2[0] = "Inasistencias";
            row2[1] = cantAusencias;

            dt.Rows.Add(row1);
            dt.Rows.Add(row2);

            ViewBag.data = dt;

            return View();

        }

        private int obtenerDiasHabiles(int mes, int anio)
        {
            var days = DateTime.DaysInMonth(anio, mes);
            int diaLaboral = 0;

            for (var i = 0; i < days; i++)
            {
                //Si es dia Habil, incremento
                if (diaHabil(anio, mes, i + 1))
                    diaLaboral++;

            }
            return diaLaboral;
        }

        //Devuelve si el dia esta entre el Lunes y Viernes
        private bool diaHabil(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            DayOfWeek dia = dt.DayOfWeek;
            if (dia != DayOfWeek.Saturday && dia != DayOfWeek.Sunday)
                return true;

            return false;
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
