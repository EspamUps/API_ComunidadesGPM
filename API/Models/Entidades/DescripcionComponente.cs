using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class DescripcionComponente
    {
        public int IdDescripcionComponente { get; set; }
        public string IdDescripcionComponenteEncriptado { get; set; }
        public string IdAsignarComponenteGenerico { get; set; }
        public bool Obligatorio { get; set; }
        public int Orden { get; set; }
        public string Utilizado { get; set; }
        public AsignarDescripcionComponenteTipoElemento AsignarDescripcionComponenteTipoElemento { get; set; }
    }
}