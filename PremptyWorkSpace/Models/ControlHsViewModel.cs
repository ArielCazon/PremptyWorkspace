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
using System.ComponentModel;

namespace PremptyWorkSpace.Models
{
    public class ControlHsViewModel
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        
        [DisplayName ("Hora Ingreso")]
        public string HoraIngreso { get; set; }

        [DisplayName("Hora Egreso")]
        public string HoraEgreso { get; set; }

        public int IdArea { get; set; }

        public int IdMes { get; set; }
    }
}