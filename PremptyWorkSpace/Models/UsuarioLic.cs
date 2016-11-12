using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class UsuarioLic
    {
        public string Nombre;
        public string Apellido;
        public string NombreUsuario;
        public string AreaDescripcion;
        public int IdArea { get; set; }
        public int IdMes { get; set; }
        public int IdMotivo { get; set; }
        public DateTime FechaInicio;
        public DateTime FechaFin;
    }
}