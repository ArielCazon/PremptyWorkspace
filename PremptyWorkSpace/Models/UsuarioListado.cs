using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PremptyWorkSpace.Models
{
    public class UsuarioListado
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("Descripcion de Area")]
        public string DescrArea { get; set; }
        [DisplayName("Cantidad de Inasistencia")]
        public int CantInas { get; set; }
    }
}
