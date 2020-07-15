using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class AsignarComponenteGenerico
    {
        public int IdAsignarComponenteGenerico { get; set; }
        public string IdAsignarComponenteGenericoEncriptado { get; set; }
        public string IdAsignarCuestionarioModelo { get; set; }
        public string IdComponente { get; set; }
        public int Orden { get; set; }
        public string Utilizado { get; set; }
        public bool Estado { get; set; }
        public Componente Componente { get; set; }
        public AsignarCuestionarioModelo AsignarCuestionarioModelo { get; set; }
        public List<DescripcionComponente> DescripcionComponente { get; set; }
    }
}