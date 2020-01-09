using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarUsuarioTipoUsuario
    {
        public int IdAsignarUsuarioTipoUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public bool Estado { get; set; }

        public Usuario objUsuario { get; set; }
        public TipoUsuario objTipoUsuario { get; set; }
    }
}