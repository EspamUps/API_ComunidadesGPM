using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Parroquia
    {
        public int IdParroquia { get; set; }
        public string IdParroquiaEncriptado { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public  Canton Canton { get; set; }

    }
}