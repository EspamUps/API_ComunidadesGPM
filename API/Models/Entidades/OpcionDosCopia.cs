using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class OpcionDosCopia
    {
        public int IdOpcionDosMatriz { get; set; }
        public string IdOpcionDosMatrizEncriptado { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}