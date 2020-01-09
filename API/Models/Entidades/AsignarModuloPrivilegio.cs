using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarModuloPrivilegio
    {
        public int IdAsignarModuloPrivilegio { get; set; }
        public int IdModulo { get; set; }
        public int IdPrivilegio { get; set; }
        public bool Estado { get; set; }

        public Modulo objModulo { get; set; }
        public Privilegio objPrivilegio { get; set; }
    }
}