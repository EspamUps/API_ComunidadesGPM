using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CuestionarioPublicado
    {
        public int IdCuestionarioPublicado { get; set; }
        public string IdCuestionarioPublicadoEncriptado { get; set; }
        public DateTime FechaPublicacion{ get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public CabeceraVersionCuestionario CabeceraVersionCuestionario { get; set; }
        public Periodo Periodo { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
    }
}