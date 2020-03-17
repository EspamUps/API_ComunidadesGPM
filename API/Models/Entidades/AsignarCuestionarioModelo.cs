using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarCuestionarioModelo
    {
        public int IdAsignarCuestionarioModelo { get; set; }
        public string IdAsignarCuestionarioModeloEncriptado { get; set; }
        public string IdCuestionarioGenerico { get; set; }
        public string IdModeloGenerico { get; set; }
        public string IdAsignarUsuarioTipoUsuario { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string Utilizado { get; set; }
        public List<CuestionarioGenerico> CuestionarioGenerico { get; set; }
    }
}