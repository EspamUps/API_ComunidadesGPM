using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ConfigurarMatrizCopia
    {
        public int IdConfigurarMatriz { get; set; }
        public string IdConfigurarMatrizEncriptado { get; set; }
        public OpcionUnoCopia OpcionUnoMatriz { get; set; }
        public OpcionDosCopia OpcionDosMatriz { get; set; }
        public bool Estado { get; set; }

        public string IdRespuestaLogica { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdAsignarEncuestado { get; set; }
        public string datoRespuestaMatriz { get; set; }
    }
}