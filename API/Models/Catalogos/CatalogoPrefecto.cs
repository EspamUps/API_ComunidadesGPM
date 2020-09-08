using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Conexion;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoPrefecto
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public List<Prefecto> ConsultarPrefecto()
        {
            List<Prefecto> _lista = new List<Prefecto>();
            foreach (var item in db.Sp_PrefectoConsultar())
            {
                _lista.Add(new Prefecto()
                {
                    IdPrefecto=item.IdPrefecto,
                    IdPrefectoEncriptado = _seguridad.Encriptar(item.IdPrefecto.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = item.FechaSalida,
                    Estado = item.EstadoPrefecto,
                    Utilizado = item.UtilizadoPrefecto,
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

        public List<Prefecto> ConsultarPrefectoPorId(int _idPrefecto)
        {
            List<Prefecto> _lista = new List<Prefecto>();
            foreach (var item in db.Sp_PrefectoConsultar().Where(c=>c.IdPrefecto==_idPrefecto).ToList())
            {
                _lista.Add(new Prefecto()
                {
                    IdPrefecto = item.IdPrefecto,
                    IdPrefectoEncriptado = _seguridad.Encriptar(item.IdPrefecto.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = item.FechaSalida,
                    Estado = item.EstadoPrefecto,
                    Utilizado = item.UtilizadoPrefecto,
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

        public List<Prefecto> ConsultarPrefectoPorIdProvincia(int _idProvincia)
        {
            List<Prefecto> _lista = new List<Prefecto>();
            foreach (var item in db.Sp_PrefectoConsultar().Where(c => c.IdProvincia == _idProvincia).ToList())
            {
                _lista.Add(new Prefecto()
                {
                    IdPrefecto = item.IdPrefecto,
                    IdPrefectoEncriptado = _seguridad.Encriptar(item.IdPrefecto.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = item.FechaSalida,
                    Estado = item.EstadoPrefecto,
                    Utilizado = item.UtilizadoPrefecto,
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

        public int InsertarPrefecto(Prefecto _objPrefecto)
        {
            try
            {
                return int.Parse(db.Sp_PrefectoInsertar(_objPrefecto.Provincia.IdProvincia, _objPrefecto.Representante, _objPrefecto.FechaIngreso, _objPrefecto.FechaSalida, _objPrefecto.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarPrefecto(Prefecto _objPrefecto)
        {
            try
            {
                db.Sp_PrefectoModificar(_objPrefecto.IdPrefecto,_objPrefecto.Provincia.IdProvincia, _objPrefecto.Representante, _objPrefecto.FechaIngreso, _objPrefecto.FechaSalida, _objPrefecto.Estado);
                return _objPrefecto.IdPrefecto;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarPrefecto(int _idPrefecto)
        {
            db.Sp_PrefectoEliminar(_idPrefecto);
        }
    }
}