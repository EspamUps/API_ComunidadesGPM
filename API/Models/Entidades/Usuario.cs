using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string Correo { get; set; }
        public stri Clave { get; set; }
        public bool Estado { get; set; }


        public Persona objPersona { get; set; }
        public List<AsignarUsuarioTipoUsuario> List_AsignarUsuarioTipoUsuario { get; set; }

        public string Token { get; set; }
    }
}