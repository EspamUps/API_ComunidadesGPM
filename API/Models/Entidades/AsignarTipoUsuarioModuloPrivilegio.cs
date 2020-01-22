using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarTipoUsuarioModuloPrivilegio
    {
        public int IdAsignarTipoUsuarioModuloPrivilegio { get; set; }
        public int IdAsignarTipoUsuarioModuloPrivilegioEncriptado { get; set; }
        public bool Estado { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public AsignarModuloPrivilegio AsignarModuloPrivilegio { get; set; }
    }
}
