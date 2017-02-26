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

            string usuarioLogueado = HttpContext.User.Identity.Name;
            var array_ausencias = new List<Ingresos>();
            var user_area = new List<Usuarios>();
            var ingresoUsu = new List<Usuarios>();

            int cantDiasHabiles = 0;
            int cantAusencias = 0;
            int cantPresencias = 0;
            int cantAusenciasF = 0;
            int cantPresenciasF = 0;
            int cantEventosPre = 0;
            int cantEventosPos = 0;
            int feriadosPre = 0;
            int feriadosPos = 0;
            int cantDiasHabilesPre = 0;
            int cantDiasHabilesPos = 0;

            int anioActual = DateTime.Now.Year;
            int diaActual = DateTime.Now.Day;
            int mesActual = DateTime.Now.Month;
            int IdEntidad = int.Parse(Session["IdEntidad"].ToString());

            ObtenerListaDeMeses();
            ObtenerListaDeAreas();
            ObtenerListaDeMotivos();


            //Se VALIDA el ingreso del AREA y MES
            if (usuLic.IdArea == 0 || usuLic.IdMes == 0)
            {
                return View();
            }

            //Cantidad TOTAL DEL MES SELECCIONAR
            int diasTotalDelMes = DateTime.DaysInMonth(anioActual, usuLic.IdMes);

            //Cantidad HABIL DEL MES
            cantDiasHabiles = obtenerDiasHabiles(usuLic.IdMes, anioActual);

            //USUARIOS por AREA para esa Entidad
            user_area = (from u in dc.Usuarios
                         where u.IdArea.Equals(usuLic.IdArea)
                         && u.Entidades.IdEntidad.Equals(IdEntidad)              // CEL3 obtener de session
                         select u).ToList();

            /*************** SE OBTIENEN DATOS PARA INASISTENCIAS REALES ********************/
            //Si es del mismo MES
            if (usuLic.IdMes == mesActual)
            {
                //Dias Habiles del MES ACTUAL hasta HOY
                cantDiasHabilesPre = CantidadHabillesMensualPre(usuLic, anioActual, diaActual, cantDiasHabilesPre);

                //Obtener FERIADOS DEL MES SELECCIONADO HASTA HOY
                feriadosPre = FeriadosHabilesMensualPre(usuLic, dc, anioActual, diaActual, feriadosPre);

            }
            else
            {   //Si el mes seleccionado es MENOR al MES actual
                if (usuLic.IdMes < mesActual)
                {
                    //Dias Habiles del MES SELECCIONADO
                    cantDiasHabilesPre = cantDiasHabiles;

                    //Obtener FERIADOS DEL MES SELECCIONADO
                    feriadosPre = FeriadosHabilMesAnterior(usuLic.IdMes, dc, anioActual, feriadosPre);
                }
            }

            //Total de DIAS que el EMPLEADO debio TRABAJAR ese MES(pasado)
            cantDiasHabilesPre = cantDiasHabilesPre - feriadosPre;



            /*************** SE OBTIENEN DATOS PARA INASISTENCIAS FUTURAS ********************/
            //Si es el mismo MES
            if (usuLic.IdMes == mesActual)
            {
                //Dias Habiles del MES de HOY hasta el Final del MES ACTUAL
                cantDiasHabilesPos = CantidadHabilMensualPos(usuLic, anioActual, diaActual, cantDiasHabilesPos, diasTotalDelMes);

                //Obtener FERIADOS DEL MES SELECCIONADO
                feriadosPos = FeriadosHabilMensualPos(usuLic, dc, anioActual, diaActual, feriadosPos, diasTotalDelMes);
            }
            else
            {
                if (usuLic.IdMes > mesActual)
                {
                    //CANTIDAD DE DIAS HABILES POS
                    cantDiasHabilesPos = cantDiasHabiles;

                    //Obtener FERIADOS DEL MES SIGUIENTE
                    feriadosPos = FeriadosHabilMesPosterior(usuLic, dc, anioActual, feriadosPos);
                }
            }

            //Total de DIAS que el EMPLEADO debe TRABAJAR ese MES(futuro)
            cantDiasHabilesPos = cantDiasHabilesPos - feriadosPos;


            //PRESENCIA REAL
            int cantidadFaltas = 0;
            int cantidadPresente = 0;
            List<UsuarioListado> usuarioInasReal = new List<UsuarioListado>();
            List<UsuarioListado> usuarioAsisReal = new List<UsuarioListado>();

            //var item = new Usuarios();

            //AUSENCIAS Y ASISTENCIA DEL MES ANTERIOR SOLO PARA EL GRAFICO, Y PARA MOSTRAR LISTADO DE INASISTENCIAS REALES 
            if (usuLic.IdMes <= mesActual)
            {
                //Cuento la cantidad de asistencias del mes por empleado
                foreach (var wa_user in user_area)
                {
                    cantidadFaltas = 0;
                    cantidadPresente = 0;
                    cantEventosPre = 0;

                    switch (usuLic.IdMotivo)
                    {
                        case 0: //Motivos en un rango de Fecha para ese usuario
                            if (usuLic.IdMes == mesActual)
                            {
                                cantEventosPre = EventosHabilesMensualPre(usuLic, dc, anioActual, diaActual, cantEventosPre, wa_user.IdUsuario, wa_user.FechaNac.Month, IdEntidad);
                                cantEventosPre = cantEventosPre + AusenciaInjustificada(usuLic, dc, cantEventosPre, anioActual, mesActual, IdEntidad, wa_user);

                            }
                            else
                            {
                                cantEventosPre = EventosHabilesMensualPre(usuLic, dc, anioActual, diasTotalDelMes, cantEventosPre, wa_user.IdUsuario, wa_user.FechaNac.Month, IdEntidad);
                            }
                            break;

                        case 1: //Motivo por DEPORTE
                            if (usuLic.IdMes == mesActual)
                            {
                                cantEventosPre = EventosHabilMensualXDeportePre(usuLic, dc, anioActual, diaActual, cantEventosPre, wa_user, IdEntidad);
                            }
                            else
                            {
                                cantEventosPre = EventosHabilMensualXDeportePre(usuLic, dc, anioActual, diasTotalDelMes, cantEventosPre, wa_user, IdEntidad);
                            }
                            break;

                        case 2: //Motivo por CUMPLEAÑOS
                            cantEventosPre = EventoCumpleaniosPre(usuLic, cantEventosPre, diaActual, mesActual, wa_user);

                            break;

                        case 3: //Gremio

                            if (usuLic.IdMes == mesActual)  // Mes Seleccionado == Mes Actual
                            {
                                cantEventosPre = EventosHabilMensualXGremioPre(usuLic, dc, anioActual, diaActual, cantEventosPre, wa_user, IdEntidad);
                            }
                            else
                            {
                                cantEventosPre = EventosHabilMensualXGremioPre(usuLic, dc, anioActual, diasTotalDelMes, cantEventosPre, wa_user, IdEntidad);
                            }
                            break;

                        case 4: //faltas injustificadas
                            cantEventosPre = AusenciaInjustificada(usuLic, dc, cantEventosPre, anioActual, mesActual, IdEntidad, wa_user);
                            break;

                    }

                    if (usuLic.IdMes < mesActual)
                    {
                        diaActual = diasTotalDelMes;
                    }

                    //Cantidad de asistencias por IDUSUARIO
                    int cantIngreso = (from u in dc.Usuarios
                                       join i in dc.Ingresos
                                       on u.IdUsuario equals i.IdUsuario
                                       where i.FechaActual.Day >= 1
                                        && i.FechaActual.Day <= diaActual
                                        && i.FechaActual.Month == usuLic.IdMes
                                        && i.FechaActual.Year == anioActual
                                        && u.IdArea == wa_user.IdArea
                                        && u.IdUsuario == wa_user.IdUsuario
                                        && u.IdEntidad == IdEntidad
                                       select u).Count();

                    int cantLicencias = (from u in dc.Usuarios
                                         join l in dc.Licencias
                                         on u.IdUsuario equals l.IdUsuario
                                         where l.Fecha.Day >= 1
                                          && l.Fecha.Day <= diaActual
                                          && l.Fecha.Month == usuLic.IdMes
                                          && l.Fecha.Year == anioActual
                                          && l.Estado == 1              //Estado aprobado
                                          && u.IdArea == wa_user.IdArea
                                          && u.IdUsuario == wa_user.IdUsuario
                                          && u.IdEntidad == IdEntidad
                                         select u).Count();

                    cantidadPresente = cantIngreso + cantLicencias;

                    if (cantidadPresente == cantDiasHabilesPre)
                    {
                        cantidadFaltas = 0;
                    }
                    else
                    {
                        int diferencia = cantDiasHabilesPre - cantidadPresente;
                        if (diferencia < cantEventosPre)
                        {
                            cantidadFaltas = diferencia;
                        }
                        else
                        {
                            cantidadFaltas = cantEventosPre;
                        }
                    }

                    //SE GUARDAN LAS INASISTENCIAS REALES DEL USUARIO
                    usuarioInasReal.Add(new UsuarioListado()
                    {
                        Legajo = (Int32)wa_user.Legajo,
                        Nombre = wa_user.Nombre,
                        Apellido = wa_user.Apellido,
                        DescrArea = wa_user.Areas.Descripcion,
                        CantInas = cantidadFaltas
                    });


                    //SUMA DE ASISTENCIAS E INASISTENCIAS REALES DE LOS EMPLEADOS  ==> GRAFICO REAL
                    cantAusencias = cantAusencias + cantidadFaltas;
                    cantPresencias = cantPresencias + cantidadPresente;
                }

            }


            //SE GUARDAN LOS REGISTROS DE USUARIO PARA MOSTRAR INASISTENCIAS REALES, viewbag solo guarda 4 datos
            Session["InasReal"] = new List<UsuarioListado>(usuarioInasReal);

            List<UsuarioListado> usuarioInasF = new List<UsuarioListado>();
            List<UsuarioListado> usuarioAsisF = new List<UsuarioListado>();


            //AUSENCIAS Y ASISTENCIA DEL MES A FUTURO SOLO PARA EL GRAFICO, Y PARA MOSTRAR LISTADO DE INASISTENCIAS FUTURAS 
            //int diaInicial = 1;
            if (usuLic.IdMes >= mesActual)
            {
                foreach (var wa_user in user_area)
                {
                    cantidadFaltas = 0;
                    cantidadPresente = 0;
                    cantEventosPos = 0;

                    switch (usuLic.IdMotivo)
                    {

                        case 0://Todos los eventos
                            if (usuLic.IdMes == mesActual)
                            {
                                cantEventosPos = EventosHabilMensualPos(usuLic, dc, anioActual, diaActual, cantEventosPos, diasTotalDelMes, wa_user, IdEntidad);
                                cantEventosPos = cantEventosPos + AusenciaInjustificada(usuLic, dc, cantEventosPos, anioActual, mesActual, IdEntidad, wa_user);

                            }
                            else
                            {
                                cantEventosPos = EventosHabilMensualPos(usuLic, dc, anioActual, 1, cantEventosPos, diasTotalDelMes, wa_user, IdEntidad);
                                cantEventosPos = cantEventosPos + AusenciaInjustificada(usuLic, dc, cantEventosPos, anioActual, mesActual, IdEntidad, wa_user);

                            }

                            break;

                        case 1://Deporte
                            if (usuLic.IdMes == mesActual)
                            {
                                cantEventosPos = EventosHabilMensulXDeportePos(usuLic, dc, anioActual, diaActual, cantEventosPos, diasTotalDelMes, wa_user, IdEntidad);
                            }
                            else
                            {
                                cantEventosPos = EventosHabilMensulXDeportePos(usuLic, dc, anioActual, 1, cantEventosPos, diasTotalDelMes, wa_user, IdEntidad);
                            }
                            break;

                        case 2:  //Cumpleaños
                            cantEventosPos = EventosMensualXCumplePos(usuLic, cantEventosPos, diaActual, mesActual, wa_user);
                            break;

                        case 3: //Gremio
                            if (usuLic.IdMes == mesActual)
                            {
                                cantEventosPos = EventosHabilMensualXGremioPos(usuLic, dc, anioActual, diaActual, cantEventosPos, diasTotalDelMes, wa_user, IdEntidad);
                            }
                            else
                            {
                                cantEventosPos = EventosHabilMensualXGremioPos(usuLic, dc, anioActual, 1, cantEventosPos, diasTotalDelMes, wa_user, IdEntidad);

                            }
                            break;
                        case 4://faltas injustificadas

                            cantEventosPos = AusenciaInjustificada(usuLic, dc, cantEventosPos, anioActual, mesActual, IdEntidad, wa_user);

                            break;


                    }


                    //Cantidad de INGRESOS para de un USUARIO par
                    cantidadFaltas = cantEventosPos;
                    cantidadPresente = cantDiasHabilesPos - cantEventosPos;

                    //SE GUARDAN LAS INASISTENCIAS REALES DEL USUARIO
                    usuarioInasF.Add(new UsuarioListado()
                    {
                        Legajo = (Int32)wa_user.Legajo,
                        Nombre = wa_user.Nombre,
                        Apellido = wa_user.Apellido,
                        DescrArea = wa_user.Areas.Descripcion,
                        CantInas = cantidadFaltas
                    });


                    //SUMA DE ASISTENCIAS E INASISTENCIAS REALES DE LOS EMPLEADOS  ==> GRAFICO REAL
                    cantAusenciasF = cantAusenciasF + cantidadFaltas;
                    cantPresenciasF = cantPresenciasF + cantidadPresente;
                }

            }

            //SE GUARDAN LOS REGISTROS DE USUARIO PARA MOSTRAR INASISTENCIAS REALES
            Session["InasFut"] = new List<UsuarioListado>(usuarioInasF);


            //Session[keySession] = new { CantidadAusencias = cantAusencias, CantidadPresencias = cantPresencias };
            var keyAusencias = usuarioLogueado + "-Ausencias";
            var keyPresencias = usuarioLogueado + "-Presencias";

            var keyAusenciasF = usuarioLogueado + "-AusenciasF";
            var keyPresenciasF = usuarioLogueado + "-PresenciasF";


            Session[keyAusencias] = cantAusencias;
            Session[keyPresencias] = cantPresencias;
            Session[keyAusenciasF] = cantAusenciasF;
            Session[keyPresenciasF] = cantPresenciasF;

            Graficar(cantAusencias, cantPresencias, cantAusenciasF, cantPresenciasF);  // Grafica para Ausencia Real

            ViewBag.mes = usuLic.IdMes;
            ViewBag.area = usuLic.IdArea;

            return View();
        }

        private int AusenciaInjustificada(UsuarioLicencia usuLic, PremptyDb dc, int cantEventosPre, int anioActual, int mesActual, int IdEntidad, Usuarios wa_user)
        {
            int totalCantMes = 0;
            int cantIngresoXMes = 0;
            int cantDiasHabilesXMes = 0;
            int faltasXMes = 0;
            int feriadosXMes = 0;
            int cantEventosXMes = 0;
            int cumple = 0;
            int cantLicencias = 0;

            //Lectura de MESES anteriores
            for (int j = 1; j < usuLic.IdMes; j++)
            {
                totalCantMes = 0;
                cantIngresoXMes = 0;
                cantDiasHabilesXMes = 0;
                feriadosXMes = 0;
                cantEventosXMes = 0;
                cumple = 0;
                cantLicencias = 0;

                totalCantMes = DateTime.DaysInMonth(anioActual, j);

                cantDiasHabilesXMes = obtenerDiasHabiles(j, anioActual);

                cantIngresoXMes = (from u in dc.Usuarios
                                   join i in dc.Ingresos
                                   on u.IdUsuario equals i.IdUsuario
                                   where i.FechaActual.Day >= 1
                                    && i.FechaActual.Day <= totalCantMes
                                    && i.FechaActual.Month == j
                                    && i.FechaActual.Year == anioActual
                                    && u.IdArea == wa_user.IdArea
                                    && u.IdUsuario == wa_user.IdUsuario
                                    && u.IdEntidad == IdEntidad
                                   select u).Count();
                //Eventos
                var tablaEventos = (from e in dc.Eventos
                                    join r in dc.Respuestas
                                    on e.IdEventos equals r.IdEvento
                                    where e.Fecha.Day >= 1
                                       && e.Fecha.Day <= totalCantMes
                                       && e.Fecha.Month.Equals(j)
                                       && e.Fecha.Year.Equals(anioActual)
                                       && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                       && r.Respuesta > 3
                                       && r.Usuarios.IdUsuario == wa_user.IdUsuario
                                       && e.Entidades.IdEntidad.Equals(IdEntidad)
                                    select e).ToList();

                foreach (var item in tablaEventos)
                {
                    if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                    {
                        cantEventosXMes = cantEventosXMes + 1;
                    }

                }


                cantLicencias = (from u in dc.Usuarios
                                 join l in dc.Licencias
                                 on u.IdUsuario equals l.IdUsuario
                                 where l.Fecha.Day >= 1
                                  && l.Fecha.Day <= totalCantMes
                                  && l.Fecha.Month == j
                                  && l.Fecha.Year == anioActual
                                  && l.Estado == 1              //Estado aprobado
                                  && u.IdArea == wa_user.IdArea
                                  && u.IdUsuario == wa_user.IdUsuario
                                  && u.IdEntidad == IdEntidad
                                 select u).Count();


                //Cumple
                if (wa_user.FechaNac.Month == j)
                {
                    cumple = 1;
                }

                feriadosXMes = FeriadosHabilMesAnterior(j, dc, anioActual, feriadosXMes);

                //Falta injustificada = Asistencias
                faltasXMes = faltasXMes + cantDiasHabilesXMes - cantIngresoXMes - feriadosXMes - cantEventosXMes - cumple - cantLicencias;

            }

            cantEventosPre = (int)faltasXMes / mesActual;
            return cantEventosPre;
        }

        private int EventosMensualXCumplePos(UsuarioLicencia usuLic, int cantEventosPos, int diaActual, int mesActual, Usuarios wa_user)
        {
            if (usuLic.IdMes == mesActual)  // Mes Seleccionado == Mes Actual
            {
                if (wa_user.FechaNac.Month == usuLic.IdMes && wa_user.FechaNac.Day > diaActual)
                {
                    cantEventosPos = cantEventosPos + 1;
                }
            }
            else if (usuLic.IdMes == wa_user.FechaNac.Month)   // Mes Seleccionado > Mes Actual 
            {
                cantEventosPos = cantEventosPos + 1;
            }
            return cantEventosPos;
        }

        private int EventoCumpleaniosPre(UsuarioLicencia usuLic, int cantEventosPre, int diaActual, int mesActual, Usuarios wa_user)
        {
            if (usuLic.IdMes == mesActual)  // Mes Seleccionado == Mes Actual
            {
                if (wa_user.FechaNac.Month == usuLic.IdMes && wa_user.FechaNac.Day < diaActual)
                {
                    cantEventosPre = cantEventosPre + 1;
                }
            }
            else if (usuLic.IdMes == wa_user.FechaNac.Month)   // Mes Seleccionado < Mes Actual 
            {
                cantEventosPre = cantEventosPre + 1;
            }
            return cantEventosPre;
        }

        private int EventosHabilMensualXGremioPos(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaInicial, int cantEventosPos, int diasTotalDelMes, Usuarios wa_user, int IdEntidad)
        {

            var tablaEventos = (from e in dc.Eventos
                                join r in dc.Respuestas
                                on e.IdEventos equals r.IdEvento
                                where e.Fecha.Day > diaInicial
                                   && e.Fecha.Day < diasTotalDelMes
                                   && e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Year.Equals(anioActual)
                                   && (e.Titulo.Contains("Paro") || e.Titulo.Contains("Colectivo") || e.Titulo.Contains("Gremio"))
                                   && r.Respuesta > 3
                                   && r.Usuarios.IdUsuario == wa_user.IdUsuario
                                   && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                   && e.Entidades.IdEntidad.Equals(IdEntidad)
                                select e).ToList();

            //Cantida de eventos de lun a vier
            foreach (var item in tablaEventos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    cantEventosPos = cantEventosPos + 1;
                }

            }
            return cantEventosPos;
        }



        private int EventosHabilMensulXDeportePos(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaInicial, int cantEventosPos, int diasTotalDelMes, Usuarios wa_user, int IdEntidad)
        {
            var tablaEventos = (from e in dc.Eventos
                                join r in dc.Respuestas
                                on e.IdEventos equals r.IdEvento
                                where e.Fecha.Day > diaInicial
                                   && e.Fecha.Day <= diasTotalDelMes
                                   && e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Year.Equals(anioActual)
                                   && (e.Titulo.Contains("Deporte") || e.Titulo.Contains("Tenis") || e.Titulo.Contains("Futbol"))
                                   && r.Respuesta > 3
                                   && r.Usuarios.IdUsuario == wa_user.IdUsuario
                                   && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                   && e.Entidades.IdEntidad.Equals(IdEntidad)
                                select e).ToList();

            //Cantida de eventos de lun a vier
            foreach (var item in tablaEventos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    cantEventosPos = cantEventosPos + 1;
                }

            }
            return cantEventosPos;
        }
        private int EventosHabilMensualPos(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaInicial, int cantEventosPos, int diasTotalDelMes, Usuarios wa_user, int IdEntidad)
        {
            var tablaEventos = (from e in dc.Eventos
                                join r in dc.Respuestas
                                on e.IdEventos equals r.IdEvento
                                where e.Fecha.Day > diaInicial
                                   && e.Fecha.Day <= diasTotalDelMes
                                   && e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Year.Equals(anioActual)
                                   && r.Respuesta > 3
                                   && r.Usuarios.IdUsuario == wa_user.IdUsuario
                                   && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                   && e.Entidades.IdEntidad.Equals(IdEntidad)
                                select e).ToList();

            //Cantida de eventos de lun a vier
            foreach (var item in tablaEventos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    cantEventosPos = cantEventosPos + 1;
                }

            }

            //Su cumpleaños es EL mes
            var usu_cumple = (from u in dc.Usuarios
                              where u.IdUsuario == wa_user.IdUsuario
                              select u.FechaNac).First();

            if (usu_cumple.Month == usuLic.IdMes)
            {
                cantEventosPos = cantEventosPos + 1;
            }
            return cantEventosPos;

        }
        private int EventosHabilMensualXGremioPre(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaFinal, int cantEventosPre, Usuarios wa_user, int IdEntidad)
        {
            var tablaEventos = (from e in dc.Eventos
                                join r in dc.Respuestas
                                on e.IdEventos equals r.IdEvento
                                where e.Fecha.Day >= 1
                                   && e.Fecha.Day <= diaFinal
                                   && e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Year.Equals(anioActual)
                                   && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                   && (e.Titulo.Contains("Paro") || e.Titulo.Contains("Colectivo") || e.Titulo.Contains("Gremio"))
                                   && r.Respuesta > 3
                                   && r.Usuarios.IdUsuario == wa_user.IdUsuario
                                   && e.Entidades.IdEntidad.Equals(IdEntidad)
                                select e).ToList();

            foreach (var item in tablaEventos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    cantEventosPre = cantEventosPre + 1;
                }

            }
            return cantEventosPre;
        }

        private int EventosHabilMensualXDeportePre(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaFinal, int cantEventosPre, Usuarios wa_user, int IdEntidad)
        {
            var tablaEventos = (from e in dc.Eventos
                                join r in dc.Respuestas
                                on e.IdEventos equals r.IdEvento
                                where e.Fecha.Day >= 1
                                   && e.Fecha.Day <= diaFinal
                                   && e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Year.Equals(anioActual)
                                   && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                   && (e.Titulo.Contains("Deporte") || e.Titulo.Contains("Futbol") || e.Titulo.Contains("Tenis"))
                                   && r.Respuesta > 3
                                   && r.Usuarios.IdUsuario == wa_user.IdUsuario
                                   && e.Entidades.IdEntidad.Equals(IdEntidad)
                                select e).ToList();

            foreach (var item in tablaEventos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    cantEventosPre = cantEventosPre + 1;
                }

            }
            return cantEventosPre;
        }




        private int FeriadosHabilMesPosterior(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int feriadosPos)
        {
            var tablaferiadosPos = (from f in dc.Feriados
                                    where f.Fecha.Month.Equals(usuLic.IdMes)
                                    && f.Fecha.Year.Equals(anioActual)
                                    select f).ToList();

            //Cantida de feriados de lun a vier
            foreach (var item in tablaferiadosPos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    feriadosPos = feriadosPos + 1;
                }

            }
            return feriadosPos;
        }


        private int FeriadosHabilMensualPos(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaActual, int feriadosPos, int diasTotalDelMes)
        {
            var tablaferiadosPos = (from f in dc.Feriados
                                    where f.Fecha.Day > diaActual
                                    && f.Fecha.Day <= diasTotalDelMes
                                    && f.Fecha.Month.Equals(usuLic.IdMes)
                                    && f.Fecha.Year.Equals(anioActual)
                                    select f).ToList();

            foreach (var item in tablaferiadosPos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    feriadosPos = feriadosPos + 1;
                }
            }
            return feriadosPos;
        }

        private int CantidadHabilMensualPos(UsuarioLicencia usuLic, int anioActual, int diaActual, int cantDiasHabilesPos, int diasTotalDelMes)
        {
            int diaPos = diaActual + 1;

            for (int i = diaPos; i <= diasTotalDelMes; i++)
            {
                if (diaHabil(anioActual, usuLic.IdMes, i) == true)
                {
                    cantDiasHabilesPos = cantDiasHabilesPos + 1;
                }

            }
            return cantDiasHabilesPos;
        }

        private int FeriadosHabilMesAnterior(int mesSelect, PremptyDb dc, int anioActual, int feriadosPre)
        {

            var tablaferiadosPre = (from f in dc.Feriados
                                    where f.Fecha.Month.Equals(mesSelect)
                                    && f.Fecha.Year.Equals(anioActual)
                                    select f).ToList();


            //Cantida de feriados de lun a vier
            foreach (var item in tablaferiadosPre)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    feriadosPre = feriadosPre + 1;
                }

            }
            return feriadosPre;
        }

        private int CantidadHabillesMensualPre(UsuarioLicencia usuLic, int anioActual, int diaActual, int cantDiasHabilesPre)
        {
            for (int i = 1; i <= diaActual; i++)
            {
                if (diaHabil(anioActual, usuLic.IdMes, i) == true)
                {
                    cantDiasHabilesPre = cantDiasHabilesPre + 1;
                }

            }
            return cantDiasHabilesPre;
        }


        private int EventosHabilesMensualPre(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaFinal, int cantEventosPre, int idUsuario, int mesNac, int IdEntidad)
        {
            //Todos los eventos
            var tablaEventos = (from e in dc.Eventos
                                join r in dc.Respuestas
                                on e.IdEventos equals r.IdEvento
                                where e.Fecha.Day >= 1
                                   && e.Fecha.Day <= diaFinal
                                   && e.Fecha.Month.Equals(usuLic.IdMes)
                                   && e.Fecha.Year.Equals(anioActual)
                                   && (e.IdArea == usuLic.IdArea || e.IdArea == null)
                                   && e.Entidades.IdEntidad.Equals(IdEntidad)
                                   && r.Respuesta > 3
                                   && r.Usuarios.IdUsuario == idUsuario
                                select e).ToList();

            //Cantida de eventos de lun a vier
            foreach (var item in tablaEventos)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    cantEventosPre = cantEventosPre + 1;
                }

            }

            //Su cumpleaños es este mes
            if (mesNac == usuLic.IdMes)
            {
                cantEventosPre = cantEventosPre + 1;
            }

            return cantEventosPre;
        }

        private int FeriadosHabilesMensualPre(UsuarioLicencia usuLic, PremptyDb dc, int anioActual, int diaActual, int feriadosPre)
        {
            var tablaferiadosPre = (from f in dc.Feriados
                                    where f.Fecha.Day >= 1
                                    && f.Fecha.Day < diaActual
                                    && f.Fecha.Month.Equals(usuLic.IdMes)
                                    && f.Fecha.Year.Equals(anioActual)
                                    select f).ToList();

            //Cantidad de feriados de lun a vier
            foreach (var item in tablaferiadosPre)
            {
                if (diaHabil(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day) == true)
                {
                    feriadosPre = feriadosPre + 1;
                }

            }
            return feriadosPre;
        }


        private void Graficar(int cantAusencias, int cantPresencias, int cantAusFutura, int cantPreFutura)
        {
            //Se completa la grafica de Ausencias Reales
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("item"));
            dt.Columns.Add(new DataColumn("cantidad"));

            DataRow row1 = dt.NewRow();
            row1[0] = "Inasistencias Reales";
            row1[1] = cantAusencias;

            DataRow row2 = dt.NewRow();
            row2[0] = "Asistencias Reales";
            row2[1] = cantPresencias;

            dt.Rows.Add(row1);
            dt.Rows.Add(row2);

            ViewBag.data = dt;

            //Se completa la grafica de Ausencias futuras
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("item"));
            dt2.Columns.Add(new DataColumn("cantidad"));

            DataRow row3 = dt2.NewRow();
            row3[0] = "Inasistencia Futura";
            row3[1] = cantAusFutura;

            DataRow row4 = dt2.NewRow();
            row4[0] = "Asistencias Futuras";
            row4[1] = cantPreFutura;

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


        public ActionResult VerDetalleReal()
        {
            List<UsuarioListado> usuarioListReal = (List<UsuarioListado>)Session["InasReal"];

            //Se comple el dropdown
            ObtenerListaDeMeses();
            ObtenerListaDeAreas();
            ObtenerListaDeMotivos();

            return View("Index", usuarioListReal);

        }// fin de la rutina

        public ActionResult VerDetalleFut()
        {
            List<UsuarioListado> usuarioListFut = (List<UsuarioListado>)Session["InasFut"];

            //Se comple el dropdown
            ObtenerListaDeMeses();
            ObtenerListaDeAreas();
            ObtenerListaDeMotivos();

            return View("Index", usuarioListFut);

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
            List<MotivoLicencia> motivo = new List<MotivoLicencia>();


            motivo.Add(new MotivoLicencia() { IdMotivo = 1, Descripcion = "Deportes" });
            motivo.Add(new MotivoLicencia() { IdMotivo = 2, Descripcion = "Cumpleaños" });
            motivo.Add(new MotivoLicencia() { IdMotivo = 3, Descripcion = "Cuestiones Gremiales" });
            motivo.Add(new MotivoLicencia() { IdMotivo = 4, Descripcion = "Faltas injustificadas" }); //Ausencia sin motivo

            ViewBag.IdMotivo = new SelectList(motivo, "IdMotivo", "Descripcion");

        }
    }

}
