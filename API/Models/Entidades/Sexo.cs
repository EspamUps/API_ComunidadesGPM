using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Sexo
    {
        public int IdSexo { get; set; }
        public string IdSexoEncriptado { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Token { get; set; }
    }
}