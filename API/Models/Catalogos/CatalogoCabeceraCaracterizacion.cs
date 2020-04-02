using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoCabeceraCaracterizacion
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int InsertarCabeceraCaracterizacion(CabeceraCaracterizacion _objCabeceraCaracterizacion)
        {
            try
            {
                return int.Parse(db.Sp_CabeceraCaracterizacionInsertar(_objCabeceraCaracterizacion.FechaRegistro,_objCabeceraCaracterizacion.AsignarResponsableModeloPublicado.IdAsignarResponsableModeloPublicado,_objCabeceraCaracterizacion.FechaFinalizado,_objCabeceraCaracterizacion.Finalizado,_objCabeceraCaracterizacion.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarCabeceraCaracterizacion(CabeceraCaracterizacion _objCabeceraCaracterizacion)
        {
            try
            {
                db.Sp_CabeceraCaracterizacionModificar(_objCabeceraCaracterizacion.IdCabeceraCaracterizacion,_objCabeceraCaracterizacion.FechaRegistro, _objCabeceraCaracterizacion.AsignarResponsableModeloPublicado.IdAsignarResponsableModeloPublicado, _objCabeceraCaracterizacion.FechaFinalizado, _objCabeceraCaracterizacion.Finalizado, _objCabeceraCaracterizacion.Estado);
                return _objCabeceraCaracterizacion.IdCabeceraCaracterizacion;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<CabeceraCaracterizacion> ConsultarCabeceraCaracterizacion()
        {
            List<CabeceraCaracterizacion> _lista = new List<CabeceraCaracterizacion>();
            foreach (var item in db.Sp_CabeceraCaracterizacionConsultar())
            {
                _lista.Add(new CabeceraCaracterizacion()
                {
                    IdCabeceraCaracterizacion = item.IdCabeceraCaracterizacion,
                    IdCabeceraCaracterizacionEncriptar = _seguridad.Encriptar(item.IdCabeceraCaracterizacion.ToString()),
                    Estado = item.EstadoCabeceraCaracterizacion,
                    FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraCaracterizacion),
                    FechaRegistro = item.FechaRegistroCabeceraCaracterizacion,
                    Finalizado = item.FinalizadoCabeceraCaracterizacion,
                    AsignarResponsableModeloPublicado = new AsignarResponsableModeloPublicado()
                    {
                        IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                        IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                        Estado = item.EstadoAsignarResponsableModeloPublicado,
                        FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                        FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                        FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
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
                            },
                        AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                        {
                            IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                            IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                            Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                            Usuario = new Usuario()
                            {
                                IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                                IdUsuario = item.USUARIO_IdUsuario,
                                Correo = item.USUARIO_Correo,
                                ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                                Estado = item.USUARIO_Estado,
                                Persona = new Persona()
                                {
                                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                    IdPersona = item.PERSONA_IdPersona,
                                    PrimerNombre = item.PERSONA_PrimerNombre,
                                    SegundoNombre = item.PERSONA_SegundoNombre,
                                    PrimerApellido = item.PERSONA_PrimerApellido,
                                    SegundoApellido = item.PERSONA_SegundoApellido,
                                    NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                    Telefono = item.PERSONA_Telefono,
                                    Direccion = item.PERSONA_Direccion,
                                    Estado = item.PERSONA_Estado,
                                    Sexo = new Sexo()
                                    {
                                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                        IdSexo = item.SEXO_IdSexo,
                                        Identificador = item.SEXO_Identificador,
                                        Descripcion = item.SEXO_Descripcion,
                                        Estado = item.SEXO_Estado,
                                    },
                                    TipoIdentificacion = new TipoIdentificacion()
                                    {
                                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                        IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                        Identificador = item.TIPOIDENTIFICACION_Identificador,
                                        Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                        Estado = item.TIPOIDENTIFICACION_Estado,
                                    }

                                }
                            },
                            TipoUsuario = new TipoUsuario()
                            {
                                IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                                IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                                Identificador = item.TIPOUSUARIO_Identificador,
                                Descripcion = item.TIPOUSUARIO_Descripcion,
                                Estado = item.TIPOUSUARIO_Estado
                            },
                        },
                        ModeloPublicado = new ModeloPublicado()
                        {
                            IdModeloPublicado = item.IdModeloPublicado,
                            IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                            Estado = item.EstadoModeloPublicado,
                            FechaPublicacion = item.FechaPublicacionModeloPublicado,
                            CabeceraVersionModelo = new CabeceraVersionModelo()
                            {
                                IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                                IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                                Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                                Estado = item.EstadoCabeceraVersionModelo,
                                FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                                Version = item.VersionCabeceraVersionModelo,
                                ModeloGenerico = new ModeloGenerico()
                                {
                                    IdModeloGenerico = item.IdModeloGenerico,
                                    IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                    Descripcion = item.DescripcionModeloGenerico,
                                    Estado = item.EstadoModeloGenerico,
                                    Nombre = item.NombreModeloGenerico
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }

        public List<CabeceraCaracterizacion> ConsultarCabeceraCaracterizacionPorId(int _idCabeceraCaracterizacion)
        {
            List<CabeceraCaracterizacion> _lista = new List<CabeceraCaracterizacion>();
            foreach (var item in db.Sp_CabeceraCaracterizacionConsultarPorId(_idCabeceraCaracterizacion))
            {
                _lista.Add(new CabeceraCaracterizacion()
                {
                    IdCabeceraCaracterizacion = item.IdCabeceraCaracterizacion,
                    IdCabeceraCaracterizacionEncriptar = _seguridad.Encriptar(item.IdCabeceraCaracterizacion.ToString()),
                    Estado = item.EstadoCabeceraCaracterizacion,
                    FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraCaracterizacion),
                    FechaRegistro = item.FechaRegistroCabeceraCaracterizacion,
                    Finalizado = item.FinalizadoCabeceraCaracterizacion,
                    AsignarResponsableModeloPublicado = new AsignarResponsableModeloPublicado()
                    {
                        IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                        IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                        Estado = item.EstadoAsignarResponsableModeloPublicado,
                        FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                        FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                        FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
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
                        },
                        AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                        {
                            IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                            IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                            Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                            Usuario = new Usuario()
                            {
                                IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                                IdUsuario = item.USUARIO_IdUsuario,
                                Correo = item.USUARIO_Correo,
                                ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                                Estado = item.USUARIO_Estado,
                                Persona = new Persona()
                                {
                                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                    IdPersona = item.PERSONA_IdPersona,
                                    PrimerNombre = item.PERSONA_PrimerNombre,
                                    SegundoNombre = item.PERSONA_SegundoNombre,
                                    PrimerApellido = item.PERSONA_PrimerApellido,
                                    SegundoApellido = item.PERSONA_SegundoApellido,
                                    NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                    Telefono = item.PERSONA_Telefono,
                                    Direccion = item.PERSONA_Direccion,
                                    Estado = item.PERSONA_Estado,
                                    Sexo = new Sexo()
                                    {
                                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                        IdSexo = item.SEXO_IdSexo,
                                        Identificador = item.SEXO_Identificador,
                                        Descripcion = item.SEXO_Descripcion,
                                        Estado = item.SEXO_Estado,
                                    },
                                    TipoIdentificacion = new TipoIdentificacion()
                                    {
                                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                        IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                        Identificador = item.TIPOIDENTIFICACION_Identificador,
                                        Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                        Estado = item.TIPOIDENTIFICACION_Estado,
                                    }

                                }
                            },
                            TipoUsuario = new TipoUsuario()
                            {
                                IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                                IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                                Identificador = item.TIPOUSUARIO_Identificador,
                                Descripcion = item.TIPOUSUARIO_Descripcion,
                                Estado = item.TIPOUSUARIO_Estado
                            },
                        },
                        ModeloPublicado = new ModeloPublicado()
                        {
                            IdModeloPublicado = item.IdModeloPublicado,
                            IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                            Estado = item.EstadoModeloPublicado,
                            FechaPublicacion = item.FechaPublicacionModeloPublicado,
                            CabeceraVersionModelo = new CabeceraVersionModelo()
                            {
                                IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                                IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                                Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                                Estado = item.EstadoCabeceraVersionModelo,
                                FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                                Version = item.VersionCabeceraVersionModelo,
                                ModeloGenerico = new ModeloGenerico()
                                {
                                    IdModeloGenerico = item.IdModeloGenerico,
                                    IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                    Descripcion = item.DescripcionModeloGenerico,
                                    Estado = item.EstadoModeloGenerico,
                                    Nombre = item.NombreModeloGenerico
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }
        public List<CabeceraCaracterizacion> ConsultarCabeceraCaracterizacionPorIdAsignarResponsableModeloPublicado(int _idAsignarResponsableModeloPublicado)
        {
            List<CabeceraCaracterizacion> _lista = new List<CabeceraCaracterizacion>();
            foreach (var item in db.Sp_CabeceraCaracterizacionConsultarPorAsignarResponsableModeloPublicado(_idAsignarResponsableModeloPublicado))
            {
                _lista.Add(new CabeceraCaracterizacion()
                {
                    IdCabeceraCaracterizacion = item.IdCabeceraCaracterizacion,
                    IdCabeceraCaracterizacionEncriptar = _seguridad.Encriptar(item.IdCabeceraCaracterizacion.ToString()),
                    Estado = item.EstadoCabeceraCaracterizacion,
                    FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraCaracterizacion),
                    FechaRegistro = item.FechaRegistroCabeceraCaracterizacion,
                    Finalizado = item.FinalizadoCabeceraCaracterizacion,
                    AsignarResponsableModeloPublicado = new AsignarResponsableModeloPublicado()
                    {
                        IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                        IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                        Estado = item.EstadoAsignarResponsableModeloPublicado,
                        FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                        FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                        FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
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
                        },
                        AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                        {
                            IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                            IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                            Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                            Usuario = new Usuario()
                            {
                                IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                                IdUsuario = item.USUARIO_IdUsuario,
                                Correo = item.USUARIO_Correo,
                                ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                                Estado = item.USUARIO_Estado,
                                Persona = new Persona()
                                {
                                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                    IdPersona = item.PERSONA_IdPersona,
                                    PrimerNombre = item.PERSONA_PrimerNombre,
                                    SegundoNombre = item.PERSONA_SegundoNombre,
                                    PrimerApellido = item.PERSONA_PrimerApellido,
                                    SegundoApellido = item.PERSONA_SegundoApellido,
                                    NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                    Telefono = item.PERSONA_Telefono,
                                    Direccion = item.PERSONA_Direccion,
                                    Estado = item.PERSONA_Estado,
                                    Sexo = new Sexo()
                                    {
                                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                        IdSexo = item.SEXO_IdSexo,
                                        Identificador = item.SEXO_Identificador,
                                        Descripcion = item.SEXO_Descripcion,
                                        Estado = item.SEXO_Estado,
                                    },
                                    TipoIdentificacion = new TipoIdentificacion()
                                    {
                                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                        IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                        Identificador = item.TIPOIDENTIFICACION_Identificador,
                                        Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                        Estado = item.TIPOIDENTIFICACION_Estado,
                                    }

                                }
                            },
                            TipoUsuario = new TipoUsuario()
                            {
                                IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                                IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                                Identificador = item.TIPOUSUARIO_Identificador,
                                Descripcion = item.TIPOUSUARIO_Descripcion,
                                Estado = item.TIPOUSUARIO_Estado
                            },
                        },
                        ModeloPublicado = new ModeloPublicado()
                        {
                            IdModeloPublicado = item.IdModeloPublicado,
                            IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                            Estado = item.EstadoModeloPublicado,
                            FechaPublicacion = item.FechaPublicacionModeloPublicado,
                            CabeceraVersionModelo = new CabeceraVersionModelo()
                            {
                                IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                                IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                                Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                                Estado = item.EstadoCabeceraVersionModelo,
                                FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                                Version = item.VersionCabeceraVersionModelo,
                                ModeloGenerico = new ModeloGenerico()
                                {
                                    IdModeloGenerico = item.IdModeloGenerico,
                                    IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                    Descripcion = item.DescripcionModeloGenerico,
                                    Estado = item.EstadoModeloGenerico,
                                    Nombre = item.NombreModeloGenerico
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }

    }
}