using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Entidades
{
    public class CuestionariosAsignadosTecnicos
    {

        public string IdAsignarEncuestado { get; set; }
        public string IdVersionCuestionario{ get; set; }
        public string IdCuestionarioGenerico { get; set; }
        public string nombreCuestionario { get; set; }
        public string detalleCuestionario { get; set; }
        public string nombreProvincia { get; set; }
        public string nombreCanton { get; set; }
        public string nombreParroquia { get; set; }
        public string nombreComunidad { get; set; }
        public DateTime FechaInicioCuestionario { get; set; }
        public DateTime FechaFinCuestionario { get; set; }
        public DateTime PeriodoFechaInicioCuestionario { get; set; }
        public DateTime PeriodoFechaFinCuestionario { get; set; }
        public DateTime FechaPublicacionCuestionario { get; set; }
        public CuestionariosAsignadosTecnicos(
                string IdAsignarEncuestado,
                string IdCuestionarioGenerico,
                string nombreCuestionario,
                string detalleCuestionario,
                string nombreProvincia,
                string nombreCanton,
                string nombreParroquia,
                string nombreComunidad,
                DateTime FechaInicioCuestionario,
                DateTime FechaFinCuestionario, 
                DateTime PeriodoFechaInicioCuestionario, 
                DateTime PeriodoFechaFinCuestionario, 
                DateTime FechaPublicacionCuestionario,
                string IdVersionCuestionario
            )

        {
            this.IdAsignarEncuestado = IdAsignarEncuestado;
            this.IdCuestionarioGenerico = IdCuestionarioGenerico;
            this.nombreCuestionario = nombreCuestionario;
            this.detalleCuestionario = detalleCuestionario;
            this.nombreProvincia = nombreProvincia;
            this.nombreCanton = nombreCanton;
            this.nombreParroquia = nombreParroquia;
            this.nombreComunidad = nombreComunidad;
            this.FechaInicioCuestionario = FechaInicioCuestionario;
            this.FechaFinCuestionario = FechaFinCuestionario;
            this.PeriodoFechaInicioCuestionario = PeriodoFechaInicioCuestionario;
            this.PeriodoFechaFinCuestionario = PeriodoFechaFinCuestionario;
            this.FechaPublicacionCuestionario = FechaPublicacionCuestionario;
            this.IdVersionCuestionario = IdVersionCuestionario;
        }

    }
}