using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public string Token { get; set; }
        //public AsignarTipoUsuarioModuloPrivilegio AsignarTipoUsuarioModuloPrivilegio { get; set; }

    }
}