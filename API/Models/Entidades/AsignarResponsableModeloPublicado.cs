using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarResponsableModeloPublicado
    {
        public int IdAsignarResponsableModeloPublicado { get; set; }
        public string IdAsignarResponsableModeloPublicadoEncriptado { get; set; }
        public PresidenteJuntaParroquial PresidenteJuntaParroquial { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public ModeloPublicado ModeloPublicado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Utilizado { get; set; }
        public bool Estado { get; set; }
    }
}