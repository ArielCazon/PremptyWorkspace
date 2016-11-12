using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremptyWorkSpace.Models
{
    public class UsuarioBuscar
    {
        PremptyDb db = new PremptyDb();

        public List<Usuarios> UserBuscar(string text)
        {
            var result = from c in db.Usuarios
                         where
                             c.Legajo.ToString().Contains(text)                                                   
                         select c;
            return result.ToList();
        }

    }
}