using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoCabeceraVersionCuestionario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarCabeceraVersionCuestionario(CabeceraVersionCuestionario _objCabeceraVersionCuestionario)
        {
            try
            {
                return int.Parse(db.Sp_CabeceraVersionCuestionarioInsertar(_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable,_objCabeceraVersionCuestionario.Caracteristica,_objCabeceraVersionCuestionario.Version,_objCabeceraVersionCuestionario.FechaCreacion, _objCabeceraVersionCuestionario.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarCabeceraVersionCuestionario(CabeceraVersionCuestionario _objCabeceraVersionCuestionario)
        {
            try
            {
                db.Sp_CabeceraVersionCuestionarioModificar(_objCabeceraVersionCuestionario.IdCabeceraVersionCuestionario,_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable, _objCabeceraVersionCuestionario.Caracteristica, _objCabeceraVersionCuestionario.Version, _objCabeceraVersionCuestionario.FechaCreacion, _objCabeceraVersionCuestionario.Estado);
                return _objCabeceraVersionCuestionario.IdCabeceraVersionCuestionario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarCabeceraVersionCuestionario(int _idCabeceraVersionCuestionario)
        {
            db.Sp_CabeceraVersionCuestionarioEliminar(_idCabeceraVersionCuestionario);
        }

        public List<CabeceraVersionCuestionario> ConsultarCabeceraVersionCuestionario()
        {
            List<CabeceraVersionCuestionario> _lista = new List<CabeceraVersionCuestionario>();
            foreach (var item in db.Sp_CabeceraVersionCuestionarioConsultar())
            {
                _lista.Add(new CabeceraVersionCuestionario()
                {
                    IdCabeceraVersionCuestionario=item.IdCabeceraVersionCuestionario,
                    IdCabeceraVersionCuestionarioEncriptado=_seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                    Caracteristica=item.Caracteristica,
                    Version=item.Version,
                    Estado=item.Estado,
                    AsignarResponsable =new AsignarResponsable() { IdAsignarResponsable=item.IdAsignarResponsable },
                    FechaCreacion=item.FechaCreacion,
                    Utilizado=item.UtilizadoCabeceraVersionCuestionario
                });
            }
            return _lista;
        }

          public List<CabeceraVersionCuestionario> ConsultarCabeceraVersionCuestionarioPorId(int _idCabeceraVersionCuestionario)
        {
            List<CabeceraVersionCuestionario> _lista = new List<CabeceraVersionCuestionario>();
            foreach (var item in db.Sp_CabeceraVersionCuestionarioConsultar().Where(c=>c.IdCabeceraVersionCuestionario==_idCabeceraVersionCuestionario).ToList())
            {
                _lista.Add(new CabeceraVersionCuestionario()
                {
                    IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                    IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                    Caracteristica = item.Caracteristica,
                    Version = item.Version,
                    Estado = item.Estado,
                    AsignarResponsable = new AsignarResponsable() { IdAsignarResponsable = item.IdAsignarResponsable, IdAsignarResponsableEncriptado=_seguridad.Encriptar(item.IdAsignarResponsable.ToString()) },
                    FechaCreacion = item.FechaCreacion,
                    Utilizado = item.UtilizadoCabeceraVersionCuestionario
                });
            }
            return _lista;
        }
    }
}