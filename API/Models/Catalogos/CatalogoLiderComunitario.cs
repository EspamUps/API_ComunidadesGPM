using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoLiderComunitario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public List<LiderComunitario> ConsultarLiderComunitario()
        {
            List<LiderComunitario> _lista = new List<LiderComunitario>();
            foreach (var item in db.Sp_LiderComunitarioConsultar())
            {
                _lista.Add(new LiderComunitario()
                {
                    IdLiderComunitario = item.IdLiderComunitario,
                    IdLiderComunitarioEncriptado = _seguridad.Encriptar(item.IdLiderComunitario.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoLiderComunitario,
                    Utilizado=item.UtilizadoLiderComunitario,
                    Comunidad= new Comunidad()
                    {
                        IdComunidad = item.IdComunidad,
                        IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                        CodigoComunidad = item.CodigoComunidad,
                        DescripcionComunidad = item.DescripcionComunidad,
                        EstadoComunidad = item.EstadoComunidad,
                        NombreComunidad = item.NombreComunidad,
                        RutaLogoComunidad = item.RutaLogoComunidad,
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
                    }
                });
            }
            return _lista;
        }


        public List<LiderComunitario> ConsultarLiderComunitarioPorId(int _idLiderComunitario)
        {
            List<LiderComunitario> _lista = new List<LiderComunitario>();
            foreach (var item in db.Sp_LiderComunitarioConsultar().Where(c=>c.IdLiderComunitario==_idLiderComunitario))
            {
                _lista.Add(new LiderComunitario()
                {
                    IdLiderComunitario = item.IdLiderComunitario,
                    IdLiderComunitarioEncriptado = _seguridad.Encriptar(item.IdLiderComunitario.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoLiderComunitario,
                    Utilizado = item.UtilizadoLiderComunitario,
                    Comunidad = new Comunidad()
                    {
                        IdComunidad = item.IdComunidad,
                        IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                        CodigoComunidad = item.CodigoComunidad,
                        DescripcionComunidad = item.DescripcionComunidad,
                        EstadoComunidad = item.EstadoComunidad,
                        NombreComunidad = item.NombreComunidad,
                        RutaLogoComunidad = item.RutaLogoComunidad,
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
                    }
                });
            }
            return _lista;
        }
        public List<LiderComunitario> ConsultarLiderComunitarioPorIdComunidad(int _idComunidad)
        {
            List<LiderComunitario> _lista = new List<LiderComunitario>();
            foreach (var item in db.Sp_LiderComunitarioConsultar().Where(c => c.IdComunidad == _idComunidad))
            {
                _lista.Add(new LiderComunitario()
                {
                    IdLiderComunitario = item.IdLiderComunitario,
                    IdLiderComunitarioEncriptado = _seguridad.Encriptar(item.IdLiderComunitario.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoLiderComunitario,
                    Utilizado = item.UtilizadoLiderComunitario,
                    Comunidad = new Comunidad()
                    {
                        IdComunidad = item.IdComunidad,
                        IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                        CodigoComunidad = item.CodigoComunidad,
                        DescripcionComunidad = item.DescripcionComunidad,
                        EstadoComunidad = item.EstadoComunidad,
                        NombreComunidad = item.NombreComunidad,
                        RutaLogoComunidad = item.RutaLogoComunidad,
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
                    }
                });
            }
            return _lista;
        }
        public int InsertarLiderComunitario(LiderComunitario _objLiderComunitario)
        {
            try
            {
                return int.Parse(db.Sp_LiderComunitarioInsertar(_objLiderComunitario.Comunidad.IdComunidad, _objLiderComunitario.Representante, _objLiderComunitario.FechaIngreso, _objLiderComunitario.FechaSalida, _objLiderComunitario.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int ModificarLiderComunitario(LiderComunitario _objLiderComunitario)
        {
            try
            {
                db.Sp_LiderComunitarioModificar(_objLiderComunitario.IdLiderComunitario, _objLiderComunitario.Comunidad.IdComunidad, _objLiderComunitario.Representante, _objLiderComunitario.FechaIngreso, _objLiderComunitario.FechaSalida, _objLiderComunitario.Estado);
                return _objLiderComunitario.IdLiderComunitario;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void EliminarLiderComunitario(int _idLiderComunitario)
        {
            db.Sp_LiderComunitarioEliminar(_idLiderComunitario);
        }

    }
}