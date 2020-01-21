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
        public string RutaLogoParroquia { get; set; }
        public bool EstadoParroquia { get; set; }
        public  Canton Canton { get; set; }

    }
}