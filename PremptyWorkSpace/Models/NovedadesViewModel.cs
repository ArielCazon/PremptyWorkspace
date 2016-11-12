using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class NovedadesViewModel
    {
        public int IdEventos { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        [DisplayName("Area")]
        public string Areas { get; set; }

    }
}