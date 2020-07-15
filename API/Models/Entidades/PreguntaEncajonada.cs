using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class PreguntaEncajonada
    {
        public int IdPreguntaEncajonada { get; set; }
        public string IdPreguntaEncajonadaEncriptado { get; set; }
        public Pregunta Pregunta { get; set; }
        public OpcionPreguntaSeleccion OpcionPreguntaSeleccion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
    }
}