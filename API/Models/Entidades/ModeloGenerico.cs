using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class ModeloGenerico
    {
        public int IdModeloGenerico { get; set; }
        public string IdModeloGenericoEncriptado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Utilizado { get; set; }
        public List<AsignarCuestionarioModelo> AsignarCuestionarioModelo { get; set; }
    }
}