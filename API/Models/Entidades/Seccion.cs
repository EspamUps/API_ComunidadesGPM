using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Seccion
    {
        public int IdSeccion { get; set; }
        public string IdSeccionEncriptado { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
        public Componente Componente { get; set; }

        public List<Pregunta> listaPregunta { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}