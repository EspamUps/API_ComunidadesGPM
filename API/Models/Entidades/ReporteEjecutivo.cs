using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ReporteEjecutivo
    {

        public string IdPregunta { get; set; }
        public string identificadoPregunta { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionRespuestaAbierta { get; set; }
        public string IdComunidad { get; set; }
        public string NombreComunidad { get; set; }

        public ReporteEjecutivo(string idPregunta, string descripcion, string descripcionRespuestaAbierta, string idComunidad, string nombreComunidad, string IdentificadoPregunta)
        {
            IdPregunta = idPregunta;
            Descripcion = descripcion;
            DescripcionRespuestaAbierta = descripcionRespuestaAbierta;
            IdComunidad = idComunidad;
            NombreComunidad = nombreComunidad;
            identificadoPregunta = IdentificadoPregunta;
        }
        public ReporteEjecutivo(string descripcion, string idComunidad, string nombreComunidad)
        {
            Descripcion = descripcion;
            IdComunidad = idComunidad;
            NombreComunidad = nombreComunidad;
        }

    }
}