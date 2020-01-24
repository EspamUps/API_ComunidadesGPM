using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Prefecto
    {
        public int IdPrefecto { get; set; }
        public string IdPrefectoEncriptado { get; set; }
        public Provincia Provincia { get; set; }
        public string Representante { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool Estado { get; set; }
    }
}