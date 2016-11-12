using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class LicenciaViewModel
    {
        public int IdLicencia { get; set; }
        [DisplayName("Empleado")]
        public string Usuario { get; set; }
        [DisplayName("Fecha Inicio")]
        public string FechaInicio { get; set; }
        [DisplayName("Fecha final")]
        public string FechaFin { get; set; }
        [DisplayName("Motivo")]
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}