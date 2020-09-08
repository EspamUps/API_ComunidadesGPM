using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class RespuestasCaracterizacion
    {
        public int IdRespuestasCaracterizacion { get; set; }
        public string IdRespuestasCaracterizacionEncriptado { get; set; }
        public string Descripcion { get; set; }
        public int Total { get; set; }
    }
}