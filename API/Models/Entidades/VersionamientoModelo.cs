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
        public CabeceraVersionModelo CabeceraVersionModelo { get; set; }
        public AsignarDescripcionComponenteTipoElemento AsignarDescripcionComponenteTipoElemento { get; set; }
        public bool Estado { get; set; }
    }
}