using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ModeloPublicado
    {
        public int IdModeloPublicado { get; set; }
        public string IdModeloPublicadoEncriptado { get; set; }
        public DateTime FechaPublicacion{ get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public string IdAsignarUsuarioTipoUsuario { get; set; }
        public CabeceraVersionModelo CabeceraVersionModelo { get; set; }
        public string IdCabeceraVersionModelo { get; set; }
        public Periodo Periodo { get; set; }
        public string IdPeriodo { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
        public List<AsignarModeloGenericoParroquia> AsignarModeloGenericoParroquia { get; set; }
    }
}