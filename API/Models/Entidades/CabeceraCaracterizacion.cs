using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CabeceraCaracterizacion
    {
        public int IdCabeceraCaracterizacion { get; set; }
        public string IdCabeceraCaracterizacionEncriptar { get; set; }
        public DateTime FechaRegistro { get; set; }
        public AsignarResponsableModeloPublicado AsignarResponsableModeloPublicado { get; set; }
        public DateTime? FechaFinalizado { get; set; }
        public bool Finalizado { get; set; }
        public bool Estado { get; set; }
    }
}