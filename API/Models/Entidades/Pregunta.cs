using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }
        public string IdPreguntaEncriptado { get; set; }
        public string IdPreguntaEncajonada { get; set; }
        public string IdOpcionPreguntaSeleccion { get; set; }
        public string IdComponente { get; set; }
      
        public TipoPregunta TipoPregunta { get; set; }
        public Componente Componente { get; set; }
        public PreguntaEncajonada PreguntaEncajonada { get; set; }
        public CabeceraVersionCuestionario CabeceraVersionCuestionario { get; set; }
        public Seccion Seccion { get; set; }
        public PreguntaAbierta PreguntaAbierta { get; set; }
        public string Descripcion { get; set; }
        public bool Obligatorio { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
        public bool Reporte { get; set; }
        public string leyendaSuperior { get; set; }
        public string leyendaLateral { get; set; }
        public bool Observacion { get; set; }
        public string campo_observacion { get; set; }
        public string Utilizado { get; set; }
        public string Encajonamiento { get; set; }
        public string opcionSeleccion { get; set; }
        public string opcionMatriz { get; set; }
        public List<RespuestasCaracterizacion> ListaRespuestasCaracterizacion { get; set; }

    }
}