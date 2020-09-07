using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ConfigurarComponente
    {
        public string IdConfigurarComponente { get; set; }
        public string Contenido { get; set; }
        public string IdAsignarComponenteGenerico { get; set; }
        public string IdAsignacionTU { get; set; }
        public int Imagen { get; set; }
    }
}