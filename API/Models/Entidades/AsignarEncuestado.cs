using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarEncuestado
    {
        public int IdAsignarEncuestado { get; set; }
        public string IdAsignarEncuestadoEncriptado { get; set; }
        public CuestionarioPublicado CuestionarioPublicado { get; set; }
        public Comunidad Comunidad { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuarioTecnico { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public bool Obligatorio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }
    }
}