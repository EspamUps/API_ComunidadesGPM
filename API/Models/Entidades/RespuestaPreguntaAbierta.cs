using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class RespuestaPreguntaAbierta
    {
    
        public string IdPregunta { get; set; }
        public string DescripcionPregunta { get; set; }
        public string IdPreguntaAbierta { get; set; }
        public string TipoHTML { get; set; }
        public string IdRespuesta { get; set; }
        public string IdRespuestaLogica { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdAsignarEncuestado { get; set; }

        public RespuestaPreguntaAbierta(string idPregunta, string descripcionPregunta, string idPreguntaAbierta, string tipoHTML, string idRespuesta, string idRespuestaLogica, string descripcionRespuestaAbierta, string idAsignarEncuestado)
        {
            IdPregunta = idPregunta;
            DescripcionPregunta = descripcionPregunta;
            IdPreguntaAbierta = idPreguntaAbierta;
            TipoHTML = tipoHTML;
            IdRespuesta = idRespuesta;
            IdRespuestaLogica = idRespuestaLogica;
            DescripcionRespuestaAbierta = descripcionRespuestaAbierta;
            IdAsignarEncuestado = idAsignarEncuestado;
        }


    }
}