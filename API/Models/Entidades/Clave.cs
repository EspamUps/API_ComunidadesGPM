using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Clave
    {
        public int IdClave { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}