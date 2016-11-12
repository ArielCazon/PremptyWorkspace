using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PremptyWorkSpace.Models;

namespace PremptyWorkSpace.Models
{
    public class Login
    {

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}