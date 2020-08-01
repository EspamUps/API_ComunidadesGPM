using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class RespuestasPregunta
    {
        public string IdRespuestaLogica { get; set; }
        public string IdAsignarEncuestado { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdRespuesta { get; set; }
        public string IdPregunta { get; set; }
      
    }
}