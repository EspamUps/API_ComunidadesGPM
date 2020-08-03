using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ConfigurarMatriz
    {
        public int IdConfigurarMatriz { get; set; }
        public string IdConfigurarMatrizEncriptado { get; set; }
        public OpcionUnoMatriz OpcionUnoMatriz { get; set; }
        public OpcionDosMatriz OpcionDosMatriz { get; set; }
        public bool Estado { get; set; }

        public  string IdRespuestaLogica { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdAsignarEncuestado { get; set; }
    }
}