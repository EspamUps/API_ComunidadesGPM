using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class RespuestaPreguntaSeleccion
    {

        public string IdOpcionPreguntaSeleccion { get; set; }
        public string DescripcionOpcionPreguntaSeleccion { get; set; }
        public string IdPreguntaHIja { get; set; }
        public string DescripcionPreguntaHIja { get; set; }
        public string IdPregunta { get; set; }
        public string DescripcionPregunta { get; set; }
        public string OrdenPregunta { get; set; }
        public string EncajonamientoOpcionPreguntaSeleccion { get; set; }
        public string IdRespuesta { get; set; }
        public string IdRespuestaLogica { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdAsignarEncuestado { get; set; }
        public int TotalOpciones { get; set; }
        


    }
}