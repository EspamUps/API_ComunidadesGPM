using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class TipoElemento
    {
        public int IdTipoElemento { get; set; }
        public string IdTipoElementoEncriptado { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
    }
}