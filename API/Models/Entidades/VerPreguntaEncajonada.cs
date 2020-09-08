using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class VerPreguntaEncajonada
    {
      
        public string IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public string TipoHTML { get; set; }
        public string IdPreguntaPadre { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdRespuesta { get; set; }
        public string IdRespuestaLogica { get; set; }
     

    }
}