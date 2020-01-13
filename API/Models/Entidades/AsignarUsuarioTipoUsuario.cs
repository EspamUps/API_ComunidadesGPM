using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarUsuarioTipoUsuario
    {
        public int IdAsignarUsuarioTipoUsuario { get; set; }
        public bool Estado { get; set; }

        public Usuario Usuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}