using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class Componente
    {
        public int IdComponente { get; set; }
        public string IdComponenteEncriptado { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
        public CuestionarioGenerico CuestionarioGenerico { get; set; }

        public List<Seccion> listaSeccion { get; set; }
        public Seccion Seccion { get; set; }
    }
}