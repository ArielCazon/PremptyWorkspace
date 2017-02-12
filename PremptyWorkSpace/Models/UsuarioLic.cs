using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class UsuarioLicencia
    {
        public string Nombre;
        public string Apellido;
        public string NombreUsuario;
        public string AreaDescripcion;
        public int IdArea { get; set; }
        public int IdMes { get; set; }
        public int IdMotivo { get; set; }
        public DateTime Fecha;
    }
}