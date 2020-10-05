using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Parroquia
    {
        public int IdParroquia { get; set; }
        public string IdParroquiaEncriptado { get; set; }
        public string CodigoParroquia { get; set; }
        public string NombreParroquia { get; set; }
        public string DescripcionParroquia { get; set; }
        public string PoblacionParroquia { get; set; }
        public string SuperficieParroquia { get; set; }
        public string TemperaturaParroquia { get; set; }
        public string ClimaParroquia { get; set; }
        public string RutaLogoParroquia { get; set; }
        public bool EstadoParroquia { get; set; }
        public Canton Canton { get; set; }
        public string Utilizado { get; set; }

    }
}