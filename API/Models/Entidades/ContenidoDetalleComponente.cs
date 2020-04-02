using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ContenidoDetalleComponente
    {
        public int IdContenidoDetalleComponenteCaracterizacion { get; set; }
        public string IdContenidoDetalleComponenteCaracterizacionEncriptado { get; set; }
        public CabeceraCaracterizacion CabeceraCaracterizacion { get; set; }
        public string Componente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DescripcionComponente DescripcionComponente { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuarioAutor { get; set; }
        public bool EstadoDecision { get; set; }
        public AsignarUsuarioTipoUsuario AsignarUsuarioTipoUsuarioDecision { get; set; }
        public DateTime FechaDecision { get; set; }
        public string ObservacionDecision { get; set; }
        public bool Estado { get; set; }
    }
}