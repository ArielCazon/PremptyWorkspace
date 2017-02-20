using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class UsuariosViewModel
    {

        public int IdUsuario { get; set; }
        public int Rol { get; set; }
        [Required]
        public string Legajo { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        [DisplayName("Fecha de nacimiento")]
        public string FechaNac { get; set; }
        [Required]
        [DisplayName("Fecha de Ingreso")]
        public string FechaIngreso { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Domicilio { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        
        public int IdEntidad { get; set; }

    }
}