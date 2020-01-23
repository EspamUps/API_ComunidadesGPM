using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoCanton
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Canton> ConsultarCanton()
        {
            List<Canton> _lista = new List<Canton>();
            foreach (var item in db.Sp_CantonConsultar())
            {
                _lista.Add(new Canton()
                {
                    IdCanton = item.IdCanton,
                    IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                    CodigoCanton = item.CodigoCanton,
                    DescripcionCanton = item.DescripcionCanton,
                    NombreCanton = item.NombreCanton,
                    RutaLogoCanton = item.RutaLogoCanton,
                    EstadoCanton = item.EstadoCanton,
                    Utilizado = item.UtilizadoCanton,
                    Provincia = new Provincia()
                    {
                        IdProvincia = item.IdProvincia,
                        IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                        CodigoProvincia = item.CodigoProvincia,
                        DescripcionProvincia = item.DescripcionProvincia,
                        NombreProvincia = item.NombreProvincia,
                        RutaLogoProvincia = item.RutaLogoProvincia,
                        EstadoProvincia = item.EstadoProvincia
                    }
                });
            }
            return _lista;
        }

        public List<Canton> ConsultarCantonPorId(int _idCanton)
        {
            List<Canton> _lista = new List<Canton>();
            foreach (var item in db.Sp_CantonConsultar().Where(c => c.IdCanton == _idCanton).ToList())
            {
                _lista.Add(new Canton()
                {
                    IdCanton = item.IdCanton,
                    IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                    CodigoCanton = item.CodigoCanton,
                    DescripcionCanton = item.DescripcionCanton,
                    NombreCanton = item.NombreCanton,
                    RutaLogoCanton = item.RutaLogoCanton,
                    EstadoCanton = item.EstadoCanton,
                    Utilizado = item.UtilizadoCanton,
                    Provincia = new Provincia()
                    {
                        IdProvincia = item.IdProvincia,
                        IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                        CodigoProvincia = item.CodigoProvincia,
                        DescripcionProvincia = item.DescripcionProvincia,
                        NombreProvincia = item.NombreProvincia,
                        RutaLogoProvincia = item.RutaLogoProvincia,
                        EstadoProvincia = item.EstadoProvincia
                    }
                });
            }
            return _lista;
        }

        public int InsertarCanton(Canton _objCanton)
        {
            try
            {
                return int.Parse(db.Sp_CantonInsertar(_objCanton.Provincia.IdProvincia,_objCanton.CodigoCanton, _objCanton.NombreCanton, _objCanton.DescripcionCanton, _objCanton.RutaLogoCanton, _objCanton.EstadoCanton).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int ModificarCanton(Canton _objCanton)
        {
            try
            {
                db.Sp_CantonModificar(_objCanton.IdCanton,_objCanton.Provincia.IdProvincia,_objCanton.CodigoCanton, _objCanton.NombreCanton, _objCanton.DescripcionCanton, _objCanton.RutaLogoCanton, _objCanton.EstadoCanton);
                return _objCanton.IdCanton;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarCanton(int _idCanton)
        {
            db.Sp_CantonEliminar(_idCanton);
        }
    }
}