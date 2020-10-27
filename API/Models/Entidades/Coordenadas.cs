using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Coordenadas
    {
    

        public  string id{ get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string NombreCanton { get; set; }
        public string NombreParroquia { get; set; }
        public string NombreComunidad { get; set; }
        public string idComunidad { get; set; }
        public Coordenadas(string latitud, string longitud, string nombreCanton, string nombreParroquia, string nombreComunidad, string idComunidad)
        {
            this.latitud = latitud;
            this.longitud = longitud;
            this.NombreCanton = nombreCanton;
            this.NombreParroquia = nombreParroquia;
            this.NombreComunidad = nombreComunidad;
            this.idComunidad = idComunidad;
        }

    }
}