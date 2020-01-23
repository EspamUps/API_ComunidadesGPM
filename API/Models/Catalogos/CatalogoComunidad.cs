using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoComunidad
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Comunidad> ConsultarComunidad()
        {
            List<Comunidad> _lista = new List<Comunidad>();
            foreach (var item in db.Sp_ComunidadConsultar())
            {
                _lista.Add(new Comunidad()
                {
                    IdComunidad = item.IdComunidad,
                    IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                    CodigoComunidad = item.CodigoComunidad,
                    DescripcionComunidad = item.DescripcionComunidad,
                    EstadoComunidad = item.EstadoComunidad,
                    NombreComunidad = item.NombreComunidad,
                    RutaLogoComunidad = item.RutaLogoComunidad,
                    Utilizado = item.UtilizadoComunidad,
                    Parroquia = new Parroquia()
                    {
                        IdParroquia = item.IdParroquia,
                        IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                        DescripcionParroquia = item.DescripcionParroquia,
                        CodigoParroquia = item.CodigoParroquia,
                        EstadoParroquia = item.EstadoParroquia,
                        NombreParroquia = item.NombreParroquia,
                        RutaLogoParroquia = item.RutaLogoParroquia,
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
                    }
                });
            }
            return _lista;
        }
    }
}