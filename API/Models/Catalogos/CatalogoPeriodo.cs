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
                    Descripcion = item.Descripcion,//
                    Estado = item.Estado,
                    FechaInicio = item.FechaInicio,
                    FechaFin = item.FechaFin,
                    Utilizado = item.UtilizadoPeriodo
                });
            }
            return _lista;
        }

        public int InsertarPeriodo(Periodo objPeriodo)
        {
            try
            {
                return int.Parse(db.Sp_PeriodoInsertar(
                        objPeriodo.Descripcion,
                        objPeriodo.FechaInicio,
                        objPeriodo.FechaFin,
                        objPeriodo.Estado
                    ).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarPeriodo(Periodo objPeriodo)
        {
            try
            {
                db.Sp_PeriodoModificar(
                        objPeriodo.IdPeriodo,
                        objPeriodo.Descripcion,
                        objPeriodo.FechaInicio,
                        objPeriodo.FechaFin,
                        objPeriodo.Estado
                 );
                return objPeriodo.IdPeriodo;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public void EliminarPeriodo(int _idPeriodo)
        {
            db.Sp_PeriodoEliminar(_idPeriodo);
        }
    }
}