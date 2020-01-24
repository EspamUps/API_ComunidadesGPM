using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class PresidenteJuntaParroquial
    {
        public int IdPresidenteJuntaParroquial { get; set; }
        public string IdPresidenteJuntaParroquialEncriptado { get; set; }
        public Parroquia Parroquia { get; set; }
        public string Representante { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool Estado { get; set; }
    }
}