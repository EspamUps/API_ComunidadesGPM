using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public string IdRespuestaEncriptado { get; set; }
        public CabeceraRespuesta CabeceraRespuesta { get; set; }
        public Pregunta Pregunta { get; set; }
        public int IdRespuestaLogica { get; set; }
        public string IdRespuestaLogicaEncriptado { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        //public Respuesta(Pregunta _Pregunta, CabeceraRespuesta _cabeceraRespuesta, int _IdRespuestaLogica, string _DescripcionRespuestaAbierta, DateTime _FechaRegistro, CabeceraRespuesta _IdAsignarEncuestado, CabeceraRespuesta _FechaRegistroCabecera) {
        //    this.Pregunta.IdPregunta = _Pregunta.IdPregunta;
        //    this.CabeceraRespuesta.IdCabeceraRespuesta = _cabeceraRespuesta.IdCabeceraRespuesta;
        //    this.IdRespuestaLogica = _IdRespuestaLogica;
        //    this.DescripcionRespuestaAbierta = _DescripcionRespuestaAbierta;
        //    this.FechaRegistro = _FechaRegistro;
        //    this.CabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestado = _IdAsignarEncuestado.AsignarEncuestado.IdAsignarEncuestado;
        //    this.CabeceraRespuesta.FechaRegistro = _FechaRegistroCabecera.FechaRegistro;
        //}
    }
}