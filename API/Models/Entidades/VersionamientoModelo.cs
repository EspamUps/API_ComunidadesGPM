using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class VersionamientoModelo
    {
        public int IdVersionamientoModelo { get; set; }
        public string IdVersionamientoModeloEncriptado { get; set; }
        public string IdCabeceraVersionModelo { get; set; }
        public string IdAsignarComponenteGenerico { get; set; }
        public string Contenido { get; set; }
        public bool Estado { get; set; }
        public int Imagen { get; set; }
    }
}