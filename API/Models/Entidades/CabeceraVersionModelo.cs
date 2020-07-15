using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CabeceraVersionModelo
    {
        public int IdCabeceraVersionModelo { get; set; }
        public string IdCabeceraVersionModeloEncriptado { get; set; }
        public string IdModeloGenerico { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public string Caracteristica { get; set; }
        public int Version { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
        public List<AsignarComponenteGenerico> AsignarComponenteGenerico { get; set; }
        public ModeloGenerico ModeloGenerico { get; set; }
        //public List<ModeloGenerico> ModeloGenericoLista { get; set; 
        public ModeloPublicado ModeloPublicado { get; set; }
    }
}