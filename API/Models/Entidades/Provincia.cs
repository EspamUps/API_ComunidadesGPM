using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string IdProvinciaEncriptado { get; set; }
        public string CodigoProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public string DescripcionProvincia { get; set; }
        public string RutaLogoProvincia { get; set; }
        public bool EstadoProvincia { get; set; }
        //otros campos
        public string  Utilizado { get; set; }
    }
}