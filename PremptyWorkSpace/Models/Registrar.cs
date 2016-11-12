using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PremptyWorkSpace.Models;

namespace PremptyWorkSpace.Models
{
    public class Registrar 
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

    }
}