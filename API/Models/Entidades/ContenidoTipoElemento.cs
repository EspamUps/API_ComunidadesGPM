using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ContenidoTipoElemento
    {
        public int IdContenidoTipoElemento { get; set; }
        public string IdContenidoTipoElementoEncriptado { get; set; }
        public CabeceraCaracterizacion CabeceraCaracterizacion { get; set; }
        public AsignarDescripcionComponenteTipoElemento AsignarDescripcionComponenteTipoElemento { get; set; }
        public string Contenido { get; set; }
        public string UrlRutaContenido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuario { get; set; }
        public bool Estado { get; set; }
    }
}