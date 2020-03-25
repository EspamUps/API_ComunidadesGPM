using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarModeloGenericoParroquia
    {
        public int IdAsignarModeloGenericoParroquia { get; set; }
        public string IdAsignarModeloGenericoParroquiaEncriptado { get; set; }
        public string IdModeloPublicado { get; set; }
        public string IdParroquia { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public Parroquia Parroquia { get; set; }
    }
}