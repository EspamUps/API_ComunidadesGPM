using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarTipoUsuarioModuloPrivilegio
    {
        public int IdAsignarTipoUsuarioModuloPrivilegio { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdAsignarModuloPrivilegio { get; set; }
        public bool Estado { get; set; }

        public TipoUsuario objTipoUsuario { get; set; }
        public AsignarModuloPrivilegio objAsignarModuloPrivilegio { get; set; }
    }
}