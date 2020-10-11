using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoReporteEjecutivo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<ReporteEjecutivo> ConsultarReporteEjecutivo(string idcomunidad)
        {
            List<ReporteEjecutivo> _lista = new List<ReporteEjecutivo>();
            foreach (var item in db.Sp_ReporteEjecutivo(Convert.ToInt32(idcomunidad)))
            {
                _lista.Add(new ReporteEjecutivo(Convert.ToString(item.IdPregunta), item.Descripcion, item.DescripcionRespuestaAbierta, Convert.ToString(item.IdComunidad), item.NombreComunidad, Convert.ToString(item.Identificador)));

            }
            return _lista;
        }
    }
}