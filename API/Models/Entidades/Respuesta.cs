using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public string IdRespuestaEncriptado { get; set; }
        public CabeceraRespuesta CabeceraRespuesta { get; set; }
        public Pregunta Pregunta { get; set; }
        public int IdRespuestaLogica { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}