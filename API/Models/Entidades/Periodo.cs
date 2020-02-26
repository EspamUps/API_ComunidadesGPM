using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }
        public string IdPeriodoEncriptado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }
        public string  Utilizado { get; set; }
    }
}