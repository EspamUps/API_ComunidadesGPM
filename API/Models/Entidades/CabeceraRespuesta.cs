using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CabeceraRespuesta
    {
        public int IdCabeceraRespuesta { get; set; }
        public string IdCabeceraRespuestaEncriptado { get; set; }
        public AsignarEncuestado AsignarEncuestado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaFinalizado { get; set; }
        public bool Finalizado { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
    }
}