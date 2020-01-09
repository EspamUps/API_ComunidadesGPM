using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Token
    {
        public int IdToken { get; set; }
        public int IdClave { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public Clave objClave { get; set; }
    }
}