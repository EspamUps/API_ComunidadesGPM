using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoParroquia
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Parroquia> ConsultarParroquia()
        {
            List<Parroquia> _lista = new List<Parroquia>();
            foreach (var item in db.Sp_ParroquiaConsultar())
            {
                _lista.Add(new Parroquia()
                {
                    IdParroquia = item.IdParroquia,
                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    DescripcionParroquia = item.DescripcionParroquia,
                    CodigoParroquia = item.CodigoParroquia,
                    EstadoParroquia = item.EstadoParroquia,
                    NombreParroquia = item.NombreParroquia,
                    RutaLogoParroquia = item.RutaLogoParroquia,
                    Utilizado = item.UtilizadoParroquia,
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


        public List<Parroquia> ConsultarParroquiaPorId(int _idParroquia)
        {
            List<Parroquia> _lista = new List<Parroquia>();
            foreach (var item in db.Sp_ParroquiaConsultar().Where(c=>c.IdParroquia==_idParroquia).ToList())
            {
                _lista.Add(new Parroquia()
                {
                    IdParroquia = item.IdParroquia,
                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    DescripcionParroquia = item.DescripcionParroquia,
                    CodigoParroquia = item.CodigoParroquia,
                    EstadoParroquia = item.EstadoParroquia,
                    NombreParroquia = item.NombreParroquia,
                    RutaLogoParroquia = item.RutaLogoParroquia,
                    Utilizado = item.UtilizadoParroquia,
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

        public List<Parroquia> ConsultarParroquiaPorIdCanton(int _idCanton)
        {
            List<Parroquia> _lista = new List<Parroquia>();
            foreach (var item in db.Sp_ParroquiaConsultar().Where(c => c.IdCanton == _idCanton).ToList())
            {
                _lista.Add(new Parroquia()
                {
                    IdParroquia = item.IdParroquia,
                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    DescripcionParroquia = item.DescripcionParroquia,
                    CodigoParroquia = item.CodigoParroquia,
                    EstadoParroquia = item.EstadoParroquia,
                    NombreParroquia = item.NombreParroquia,
                    RutaLogoParroquia = item.RutaLogoParroquia,
                    Utilizado = item.UtilizadoParroquia,
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


        public int InsertarParroquia(Parroquia _objParroquia)
        {
            try
            {
                return int.Parse(db.Sp_ParroquiaInsertar(_objParroquia.Canton.IdCanton, _objParroquia.CodigoParroquia, _objParroquia.NombreParroquia, _objParroquia.DescripcionParroquia, _objParroquia.RutaLogoParroquia, _objParroquia.EstadoParroquia).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarParroquia(Parroquia _objParroquia)
        {
            try
            {
               db.Sp_ParroquiaModificar(_objParroquia.IdParroquia, _objParroquia.Canton.IdCanton, _objParroquia.CodigoParroquia, _objParroquia.NombreParroquia, _objParroquia.DescripcionParroquia, _objParroquia.RutaLogoParroquia, _objParroquia.EstadoParroquia);
                return _objParroquia.IdParroquia;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarParroquia(int _idParroquia)
        {
            db.Sp_ParroquiaEliminar(_idParroquia);
        }

    }
}