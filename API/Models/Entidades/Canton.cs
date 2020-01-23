using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Canton
    {
        public int IdCanton { get; set; }
        public string IdCantonEncriptado { get; set; }
        public string CodigoCanton { get; set; }
        public string NombreCanton { get; set; }
        public string DescripcionCanton { get; set; }
        public string RutaLogoCanton { get; set; }
        public bool EstadoCanton { get; set; }
        public  Provincia Provincia { get; set; }
        //otros campos
        public string Utilizado { get; set; }
    }
}