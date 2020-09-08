using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class PreguntaAbierta
    {
        public int IdPreguntaAbierta { get; set; }
        public string IdPreguntaAbiertaEncriptado { get; set; }
        public Pregunta Pregunta { get; set; }
        public TipoDato TipoDato { get; set; }
        public bool EspecificaRango { get; set; }
        public string ValorMinimo { get; set; }
        public string ValorMaximo { get; set; }
        public bool Estado { get; set; }
        public string  Utilizado { get; set; }
        public string  Encajonamiento { get; set; }
    }
}