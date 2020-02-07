using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class OpcionPreguntaSeleccion
    {
        public int IdOpcionPreguntaSeleccion { get; set; }
        public string IdOpcionPreguntaSeleccionEncriptado { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public Pregunta Pregunta { get; set; }
        public string Utilizado { get; set; }
    }
}