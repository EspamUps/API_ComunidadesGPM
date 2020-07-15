using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class TipoPregunta
    {
        public int IdTipoPregunta { get; set; }
        public string IdTipoPreguntaEncriptado { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}