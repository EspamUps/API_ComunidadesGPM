using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;
namespace API.Models.Catalogos
{
    public class CatalogoPeriodo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Periodo> ConsultarPeriodo()
        {
            List<Periodo> _lista = new List<Periodo>();
            foreach (var item in db.Sp_PeriodoConsultar())
            {
                _lista.Add(new Periodo()
                {
                    IdPeriodo = item.IdPeriodo,
                    IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                    Estado = item.Estado,
                    FechaInicio = item.FechaInicio,
                    FechaFin = item.FechaFin,
                    Utilizado = item.UtilizadoPeriodo
                });
            }
            return _lista;
        }
    }
}