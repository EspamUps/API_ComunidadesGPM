using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class LiderComunitario
    {
        public int IdLiderComunitario { get; set; }
        public string IdLiderComunitarioEncriptado { get; set; }
        public Comunidad Comunidad { get; set; }
        public string Representante { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
    }
}