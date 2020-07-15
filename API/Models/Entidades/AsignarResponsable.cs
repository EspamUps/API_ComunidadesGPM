using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarResponsable
    {
        public int IdAsignarResponsable { get; set; }
        public string IdAsignarResponsableEncriptado { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Estado { get; set; }
        public CuestionarioGenerico CuestionarioGenerico { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public string Utilizado { get; set; }
    }
}