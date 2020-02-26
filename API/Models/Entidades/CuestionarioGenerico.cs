using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CuestionarioGenerico
    {
        public int IdCuestionarioGenerico { get; set; }
        public string IdCuestionarioGenericoEncriptado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }

        public List <Componente> listaComponente { get; set; }
        public Componente Componente { get; set; }
    }
}