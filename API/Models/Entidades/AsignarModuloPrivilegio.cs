using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarModuloPrivilegio
    {
        public int IdAsignarModuloPrivilegio { get; set; }
        public string IdAsignarModuloPrivilegioEncriptado { get; set; }
        public bool Estado { get; set; }

        public Modulo Modulo { get; set; }
        public Privilegio Privilegio { get; set; }
    }
}