using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class OpcionUnoMatriz
    {
        public int IdOpcionUnoMatriz { get; set; }
        public string IdOpcionUnoMatrizEncriptado { get; set; }
        public Pregunta Pregunta { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
    }
}