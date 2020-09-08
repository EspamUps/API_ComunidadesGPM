using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class PreguntaRestante
    {
     
        public string IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public string Componente { get; set; }
        public int Orden { get; set; }
        public Boolean Obligatorio { get; set; }

        public PreguntaRestante(string idPregunta, string descripcion, string componente, int orden, bool obligatorio)
        {
            IdPregunta = idPregunta;
            Descripcion = descripcion;
            Componente = componente;
            Orden = orden;
            Obligatorio = obligatorio;
        }



    }
}