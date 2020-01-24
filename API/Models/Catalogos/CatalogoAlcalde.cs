using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoAlcalde
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public List<Alcalde> ConsultarAlcalde()
        {
            List<Alcalde> _lista = new List<Alcalde>();
            foreach (var item in db.Sp_AlcaldeConsultar())
            {
                _lista.Add(new Alcalde()
                {
                    IdAlcalde = item.IdAlcalde,
                    IdAlcaldeEncriptado = _seguridad.Encriptar(item.IdAlcalde.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoAlcalde,
                    Utilizado = item.UtilizadoAlcalde,
                    Canton =new Canton()
                    {
                        IdCanton = item.IdCanton,
                        IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                        CodigoCanton = item.CodigoCanton,
                        DescripcionCanton = item.DescripcionCanton,
                        NombreCanton = item.NombreCanton,
                        RutaLogoCanton = item.RutaLogoCanton,
                        EstadoCanton = item.EstadoCanton,
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
                    }
                });
            }
            return _lista;
        }


        public List<Alcalde> ConsultarAlcaldePorId(int _idAlcalde)
        {
            List<Alcalde> _lista = new List<Alcalde>();
            foreach (var item in db.Sp_AlcaldeConsultar().Where(c=>c.IdAlcalde==_idAlcalde))
            {
                _lista.Add(new Alcalde()
                {
                    IdAlcalde = item.IdAlcalde,
                    IdAlcaldeEncriptado = _seguridad.Encriptar(item.IdAlcalde.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoAlcalde,
                    Utilizado = item.UtilizadoAlcalde,
                    Canton = new Canton()
                    {
                        IdCanton = item.IdCanton,
                        IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                        CodigoCanton = item.CodigoCanton,
                        DescripcionCanton = item.DescripcionCanton,
                        NombreCanton = item.NombreCanton,
                        RutaLogoCanton = item.RutaLogoCanton,
                        EstadoCanton = item.EstadoCanton,
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
                    }
                });
            }
            return _lista;
        }
    }
}