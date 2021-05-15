using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CabeceraVersionCuestionario
    {
        public int IdCabeceraVersionCuestionario { get; set; }
        public string IdCabeceraVersionCuestionarioEncriptado { get; set; }
        public AsignarResponsable AsignarResponsable { get; set; }
        public string Caracteristica { get; set; }
        public int Version { get; set; }
        public string idVersionEncriptado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
    }
}