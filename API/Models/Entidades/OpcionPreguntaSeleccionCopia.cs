using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class OpcionPreguntaSeleccionCopia
    {
        public int IdOpcionPreguntaSeleccion { get; set; }
        public string IdOpcionPreguntaSeleccionEncriptado { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
        public string Encajonamiento { get; set; }
    }
}