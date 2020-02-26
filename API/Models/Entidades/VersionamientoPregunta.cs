using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class VersionamientoPregunta
    {
        public int IdVersionamientoPregunta { get; set; }
        public string IdVersionamientoPreguntaEncriptado { get; set; }
        public CabeceraVersionCuestionario CabeceraVersionCuestionario { get; set; }
        public Pregunta Pregunta { get; set; }
        public bool Estado { get; set; }
    }
}