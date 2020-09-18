using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Comunidad
    {
        public int IdComunidad { get; set; }
        public string IdComunidadEncriptado { get; set; }
        public string CodigoComunidad { get; set; }
        public string NombreComunidad { get; set; }
        public string DescripcionComunidad { get; set; }

        public string RutaLogoComunidad { get; set; }
        public bool EstadoComunidad { get; set; }
        public Parroquia Parroquia { get; set; }
        public string Utilizado { get; set; }
    }
}