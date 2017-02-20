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
            //Metodos para completar el DropDown List
            ObtenerListaDeMeses();

            ObtenerListaDeAreas();

            ObtenerListaDeMotivos();

            //Retorno a la Vista que lo invoco
            return View();
        }

        //Metodo POST de INDEX
        [HttpPost]
        public ActionResult Index(string selectedBookId, [Bind(Include = "IdArea, IdMes, IdMotivo")]UsuarioLicencia usuLic)
        {
            PremptyDb dc = new PremptyDb();
            //Por cas usuario que se loguea se obtiene LAS CANTIDADES
            string usuarioLogueado = HttpContext.User.Identity.Name;
            var array_ausencias = new List<Ingresos>();
            var user_area = new List<Usuarios>();
            int cantDiasHabiles = 0;
            int cantAusencias = 0;
            int cantPresencias = 0;
            int anio = DateTime.Now.Year;
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int cantAusenciasF = 0;
            int cantPresenciasF = 0;
            int cantEventosPre = 0;
            int cantEventosPos = 0;
            int feriadosPre = 0;
            int feriadosPos = 0;
            int cantDiasHabilesPre = 0;
            int cantDiasHabilesPos = 0;
            var ingresoUsu = new List<Usuarios>();

            ObtenerListaDeMeses();
            ObtenerListaDeAreas();
            ObtenerListaDeMotivos();

            //Si no selecciono MES VALIDO; mensaje popup: INGRESE UN MES
            if (usuLic.IdMes == 0)
            {
                return View();
            }

            //Cantidad TOTAL DEL MES del MES
            int diasDelMes = DateTime.DaysInMonth(anio, usuLic.IdMes);

            //Cantidad HABIL DEL MES
            cantDiasHabiles = obtenerDiasHabiles(usuLic.IdMes, anio);

            //USUARIOS por AREA para esa Entidad
            user_area = (from u in dc.Usuarios
                         where u.IdArea.Equals(usuLic.IdArea)
                         && u.Entidades.IdEntidad.Equals(1)              // CEL3 obtener de session
                         select u).ToList();


            /************   PRE  ***************/

            //Si es del mismo MES
            if (usuLic.IdMes == mes)
            {
                //OBTENER CANTIDAD DIA HABIL PRE
                for (int i = 1; i <= dia; i++)
                {
                    if (diaHabil(anio, usuLic.IdMes, i) == true)
                    {
                        cantDiasHabilesPre = cantDiasHabilesPre + 1;
                    }

                }

                //Obtener FERIADOS DEL MES SELECCIONADO
                var tablaferiadosPre = (from f in dc.Feriados
                                        where f.Fecha.Day >= 1
                                        && f.Fecha.Day < dia
                                        && f.Fecha.Month.Equals(usuLic.IdMes)
                                        && f.Fecha.Year.Equals(anio)
                                        select f).ToList();

                //Cantida de feriados de lun a vier
                foreach (var item in tablaferiadosPre)
                {
                    if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                    {
                        feriadosPre = feriadosPre + 1;
                    }

                }

                //Obtener EVENTOS DEL MES SELECCIONADO 
                var tablaEventos = (from e in dc.Eventos
                                   where e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Day >= 1
                                   && e.Fecha.Day < dia 
                                   && e.Fecha.Year.Equals(anio)
                                   && e.Entidades.IdEntidad.Equals(1)    // CEL3 Obtener ENTIDAD DE LA SESSION 
                                   select e).ToList();
                //Cantida de eventos de lun a vier
                foreach (var item in tablaEventos)
                {
                    if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                    {
                        cantEventosPre = cantEventosPre + 1;
                    }

                }

            }
            else
            {   //Si el mes seleccionado es MENOR al MES actual
                if (usuLic.IdMes < mes)
                {
                    cantDiasHabilesPre = cantDiasHabiles;
                    
                    //Obtener FERIADOS DEL MES SELECCIONADO 
                    var tablaferiadosPre = (from f in dc.Feriados
                                          where  f.Fecha.Month.Equals(usuLic.IdMes)
                                          && f.Fecha.Year.Equals(anio)
                                          select f).ToList();


                    //Cantida de feriados de lun a vier
                    foreach (var item in tablaferiadosPre)
                    {
                        if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                        {
                            feriadosPre = feriadosPre + 1;
                        }

                    }

                    //Obtener EVENTOS DEL MES SELECCIONADO para la Entidad
                    var tablaEventosPre = (from e in dc.Eventos
                                      where e.Fecha.Month.Equals(usuLic.IdMes)
                                      && e.Fecha.Year.Equals(anio)
                                      && e.Entidades.IdEntidad.Equals(1)    // CEL3 Obtener ENTIDAD DE LA SESSION 
                                      select e).ToList();

                    foreach (var item in tablaEventosPre)
                    {
                        if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                        {
                            cantEventosPre = cantEventosPre + 1;
                        }

                    }
                }
            }


            //DIAS PRE HABILES
            cantDiasHabilesPre = cantDiasHabilesPre - feriadosPre - cantEventosPre;



            /************   POS ***************/
            //Si es el mismo MES
            if (usuLic.IdMes == mes)
            {
                int diaPos = dia + 1;
                //Cantidad de dias Habiles desde 1 hasta dia actual ==> CANTIDAD DIA HABIL PRE
                for (int i = diaPos; i <= diasDelMes; i++)
                {
                    if (diaHabil(anio, usuLic.IdMes, i) == true)
                    {
                        cantDiasHabilesPos = cantDiasHabilesPos + 1;
                    }

                }

                //Feriados POS 
                var tablaferiadosPos = (from f in dc.Feriados
                                        where f.Fecha.Day > dia
                                        && f.Fecha.Day <= diasDelMes
                                        && f.Fecha.Month.Equals(usuLic.IdMes)
                                        && f.Fecha.Year.Equals(anio)
                                        select f).ToList();

                foreach (var item in tablaferiadosPos)
                {
                    if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                    {
                        feriadosPos = feriadosPos + 1;
                    }
                }


                //Obtener POS EVENTOS DEL MES SELECCIONADO 
                var tablaEventos = (from e in dc.Eventos
                                    where e.Fecha.Month.Equals(usuLic.IdMes)
                                    && e.Fecha.Day > dia
                                    && e.Fecha.Day <= diasDelMes
                                    && e.Fecha.Year.Equals(anio)
                                    && e.Entidades.IdEntidad.Equals(1)    // CEL3 Obtener ENTIDAD DE LA SESSION 
                                    select e).ToList();
                //Cantida de eventos de lun a vier
                foreach (var item in tablaEventos)
                {
                    if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                    {
                        cantEventosPos = cantEventosPos + 1;
                    }
                }
            }
            else
            {
                if (usuLic.IdMes > mes)
                {
                    //CANTIDAD DE DIAS HABILES POS
                    cantDiasHabilesPos = cantDiasHabiles;

                    //CANTIDAD DE FERIADOS POS
                    feriadosPos = (from f in dc.Feriados
                                   where f.Fecha.Month.Equals(usuLic.IdMes)
                                   && f.Fecha.Year.Equals(anio)
                                   select f).Count();

                    //CANTIDAD DE EVENTOS POS
                    cantEventosPos = (from e in dc.Eventos
                                      where e.Fecha.Month.Equals(usuLic.IdMes)
                                      && e.Fecha.Year.Equals(anio)
                                      && e.Entidades.IdEntidad.Equals(1)    // CEL3 Obtener ENTIDAD DE LA SESSION 
                                      select e).Count();

                }
            }

            cantDiasHabilesPos = cantDiasHabilesPos - cantEventosPos - feriadosPos;

           

            //Logica de Presentismo REAL
            int cantidadFaltas = 0;
            int cantidadPresente = 0;


            //AUSENCIAS Y ASISTENCIA DEL MES ANTERIOR
            if (usuLic.IdMes < mes)
            {
                //Cuento la cantidad de asistencias del mes por empleado
                foreach (var item in user_area)
                {
                    //Sin selecccion de MOTIVO
                    if (usuLic.IdMotivo == 0)
                    {
                        ingresoUsu = (from u in dc.Usuarios
                                      join i in dc.Ingresos
                                      on u.IdUsuario equals i.IdUsuario
                                      where u.IdUsuario.Equals(item.IdUsuario)
                                      && i.FechaActual.Month.Equals(usuLic.IdMes)
                                      && i.FechaActual.Year.Equals(anio)
                                      && u.Entidades.IdEntidad.Equals(1)
                                      select u).ToList();

                    }
                    //Filtro de motivo
                    else
                    {

                     //Se modifica tabla Licencia == Campo== FECHA; falta indicar filtro de fecha!! "CEL3
                     //   ingresoUsu = dc.Licencias.Include(x => x.MotivoLicencia).Include(x => x.Usuarios)
                     //       .Where(x => x.MotivoLicencia.IdMotivo == usuLic.IdMotivo).Where(x => x.FechaInicio.Month == usuLic.IdMes).Select(x => x.Usuarios).ToList();
                    }

                    cantidadFaltas = cantDiasHabilesPre - ingresoUsu.Count;
                    cantidadPresente = ingresoUsu.Count;
                }

                //Se acumula la cantidad de Ausencia y Presentismo de cada Empleado
                cantAusencias = cantAusencias + cantidadFaltas;

                cantPresencias = cantPresencias + cantidadPresente;
            }



            //AUSENCIAS Y ASISTENCIA DEL MES FUTURO
            if (usuLic.IdMes > mes)
            {

                foreach (var item in user_area)
                {
                    //Sin selecccion de MOTIVO
                    if (usuLic.IdMotivo == 0)
                    {
                        //var licenciasMesPasado = dc.Licencias.Include(x => x.MotivoLicencia).Include(x => x.Usuarios)
                        //                          .Where(x => x.MotivoLicencia.IdMotivo == usuLic.IdMotivo)
                        //                          .Where(x => x.FechaInicio.Month == usuLic.IdMes)
                        //                          .Select(x => x.Usuarios);


                        //ingresoUsu = dc.Usuarios.Include(x => x.Areas).Include(x => x.Respuestas).ToList();

                        // ingresoUsu = dc.Respuestas.Include(x => x.Usuarios).Include(x => x.Eventos).Where(x => x.Usuarios.IdUsuario == item.IdUsuario).ToList();

                    }

                }

                ////Cuento la cantidad de asistencias del mes FUTURO
                //foreach (var item in user_area)
                //{
                //    ingresoUsu = (from u in dc.Usuarios
                //                  join r in dc.Respuestas
                //                  on u.IdUsuario equals r.IdUsuario
                //                  where u.IdUsuario.Equals(item.IdUsuario)
                //                  //&& i.FechaActual.Month.Equals(usuLic.IdMes)
                //                  select u).ToList();

                //    if (usuLic.IdMes < DateTime.Now.Month)
                //    {
                //        cantidadFaltas = cantDiasHabilesPre - ingresoUsu.Count;
                //    }
                //    else
                //    {
                //        cantidadFaltas = cantDiasHabilesPos - ingresoUsu.Count;
                //    }


                //    cantidadPresente = ingresoUsu.Count;
                //}

            }


            //logica de Presentismo Futuro


            //Session[keySession] = new { CantidadAusencias = cantAusencias, CantidadPresencias = cantPresencias };
            var keyAusencias = usuarioLogueado + "-Ausencias";
            var keyPresencias = usuarioLogueado + "-Presencias";

            var keyAusenciasF = usuarioLogueado + "-AusenciasF";
            var keyPresenciasF = usuarioLogueado + "-PresenciasF";


            cantAusencias = 10;
            cantPresencias = 15;
            cantAusenciasF = 0;
            cantPresenciasF = 0;

            Session[keyAusencias] = cantAusencias;
            Session[keyPresencias] = cantPresencias;
            Session[keyAusenciasF] = cantAusenciasF;
            Session[keyPresenciasF] = cantPresenciasF;

            Graficar(cantAusencias, cantPresencias, cantAusenciasF, cantPresenciasF);  // Grafica para Ausencia Real

            ViewBag.mes = usuLic.IdMes;
            ViewBag.area = usuLic.IdArea;

            return View();
        }


        private void Graficar(int cantAusencias, int cantPresencias, int cantAusFutura, int cantPreFutura)
        {
            //Se completa la grafica de Ausencias Reales
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

            //Se completa la grafica de Ausencias futuras
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("item"));
            dt2.Columns.Add(new DataColumn("cantidad"));

            DataRow row3 = dt2.NewRow();
            row3[0] = "Asistencias Futuras";
            row3[1] = cantPresencias;

            DataRow row4 = dt2.NewRow();
            row4[0] = "Inasistencias Futuras";
            row4[1] = cantAusencias;

            dt2.Rows.Add(row3);
            dt2.Rows.Add(row4);

            ViewBag.data2 = dt2;
        }

        //Obtener dias habiles del mes correspondiente al año
        private int obtenerDiasHabiles(int mes, int anio)
        {
            var diasMes = DateTime.DaysInMonth(anio, mes);
            int diaLaboral = 0;

            for (var i = 0; i < diasMes; i++)
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

        //Descarga del Archivo con los datos
        public ActionResult Download()
        {
            PremptyDb dc = new PremptyDb();

            var gv = new GridView();

            gv.DataSource = (from u in dc.Usuarios
                             join l in dc.Licencias
                             on u.IdUsuario equals l.IdUsuario
                             join a in dc.Areas
                             on u.IdArea equals a.IdArea
                             select new UsuarioLicencia
                             {
                                 Nombre = u.Nombre,
                                 Apellido = u.Apellido,
                                 NombreUsuario = u.NombreUsuario,
                                 AreaDescripcion = a.Descripcion,
                                 FechaInicio = l.Fecha
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


        public ActionResult VerDetalleReal([Bind(Include = "IdArea, IdMes")] UsuarioLicencia usuLic)
        {

            PremptyDb dc = new PremptyDb();
            //Por cas usuario que se loguea se obtiene LAS CANTIDADES
            string usuarioLogueado = HttpContext.User.Identity.Name;
            List<UsuarioListado> usuarioList = new List<UsuarioListado>();
            var array_ausencias = new List<Ingresos>();
            var user_area = new List<Usuarios>();
            int cantDiasHabiles = 0;
            int cantAusenciasEmpl = 0;
            DateTime fecha;
            int anio = DateTime.Now.Year;

            anio = anio - 1;

            //Se comple el dropdown
            ObtenerListaDeMeses();
            ObtenerListaDeAreas();
            ObtenerListaDeMotivos();


            //Session[keySession] = new { CantidadAusencias = cantAusencias, CantidadPresencias = cantPresencias };
            var keyAusencias = usuarioLogueado + "-Ausencias";
            var keyPresencias = usuarioLogueado + "-Presencias";
            var cantAusencias = int.Parse(Session[keyAusencias].ToString());
            var cantPresencias = int.Parse(Session[keyPresencias].ToString());
            var cantidadAusFutura = 1;          //Cel3
            var cantidadPreFutura = 99;         //Cel3

            Graficar(cantAusencias, cantPresencias, cantidadAusFutura, cantidadPreFutura);

            //Si no selecciono MES VALIDO
            if (usuLic.IdMes == 0)
            {
                return View();
            }

            //Se obtienen los USUARIOS
            user_area = (from u in dc.Usuarios
                         where u.IdArea.Equals(usuLic.IdArea)
                         select u).ToList();

            //Se obtiene los feriados para ese mes
            int feriados = (from e in dc.Eventos
                            where e.Fecha.Month.Equals(usuLic.IdMes)
                            && e.Fecha.Year.Equals(anio)
                            select e).Count();

            //Obtener Cant de Dias Habiles
            cantDiasHabiles = obtenerDiasHabiles(usuLic.IdMes, anio);
            cantDiasHabiles = cantDiasHabiles - feriados;

            foreach (var item in user_area)
            {
                cantAusenciasEmpl = 0;

                for (int j = 1; j < cantDiasHabiles; j++)
                {

                    //Se valida por usuario si ingreso los dias del mes seleccionado
                    fecha = new DateTime(anio, usuLic.IdMes, j);

                    var ingreso = (from u in dc.Usuarios
                                   join i in dc.Ingresos
                                   on u.IdUsuario equals i.IdUsuario
                                   where u.IdUsuario.Equals(item.IdUsuario)
                                         && i.FechaActual.Day.Equals(j)
                                         && i.FechaActual.Month.Equals(usuLic.IdMes)
                                         && i.FechaActual.Year.Equals(anio)
                                   select u).ToList();

                    if (ingreso.Count == 0)
                    {
                        cantAusenciasEmpl++;

                    }
                }

                if (cantAusenciasEmpl > 0)
                {
                    var descrArea = (from a in dc.Areas
                                     where a.IdArea.Equals(usuLic.IdArea)
                                     select a).First();

                    usuarioList.Add(new UsuarioListado()
                    {
                        Legajo = (int)item.Legajo,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        DescrArea = descrArea.Descripcion,
                        CantInas = cantAusenciasEmpl
                    }

                     );// fin de agregar registro de usuario
                }

            }

            return View("Index", usuarioList);
        }// fin de la rutina


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

        private void ObtenerListaDeMotivos()
        {
            //Conexion a la base de datos
            PremptyDb dc = new PremptyDb();

            var ausencias2 = dc.MotivoLicencia.ToList();

            var ausencias = (from m in dc.MotivoLicencia
                             join e in dc.Entidades
                             on m.IdEntidad equals e.IdEntidad
                             where e.IdEntidad.Equals(1)               // CEL3 obtener de session
                             select m).ToList();

            var motivo = new List<MotivoLicencia>();

            for (int i = 0; i < ausencias.Count; i++)
            {
                motivo.Add(new MotivoLicencia()
                {
                    IdMotivo = ausencias[i].IdMotivo,
                    Descripcion = ausencias[i].Descripcion
                });
            }
            //Retorno a la Vista el listado de Motivos
            ViewBag.IdMotivo = new SelectList(motivo, "IdMotivo", "Descripcion");
        }
    }

}
