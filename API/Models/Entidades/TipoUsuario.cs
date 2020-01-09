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

        public List<AsignarUsuarioTipoUsuario> List_AsignarUsuarioTipoUsuario { get; set; }
        public List<AsignarTipoUsuarioModuloPrivilegio> List_AsignarTipoUsuarioModuloPrivilegio { get; set; }

    }
}