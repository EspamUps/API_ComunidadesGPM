using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string IdUsuarioEncriptado { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string ClaveEncriptada { get; set; }
        public bool Estado { get; set; }

        public Persona Persona { get; set; }
        public string Token { get; set; }
    }
}