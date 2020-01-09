using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Telefono { get; set; }
        public int IdSexo { get; set; }
        public int IdParroquia { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public Sexo objSexo { get; set; }
        public TipoIdentificacion objTipoIdentificacion { get; set; }
    }
}