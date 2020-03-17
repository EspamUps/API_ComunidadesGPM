using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarDescripcionComponenteTipoElemento
    {
        public int IdAsignarDescripcionComponenteTipoElemento { get; set; }
        public string IdAsignarDescripcionComponenteTipoElementoEncriptado { get; set; }
        public string IdDescripcionComponente { get; set; }
        public string IdTipoElemento { get; set; }
        public int Orden { get; set; }
        public bool Obligatorio { get; set; }
        public TipoElemento TipoElemento { get; set; }
    }
}