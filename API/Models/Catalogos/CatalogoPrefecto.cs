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
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
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
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
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
    }
}