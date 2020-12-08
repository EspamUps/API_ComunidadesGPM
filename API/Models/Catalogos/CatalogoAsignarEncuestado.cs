using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
namespace API.Models.Catalogos
{
    public class CatalogoAsignarEncuestado
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int InsertarAsignarEncuestado(AsignarEncuestado _objAsignarEncuestado)
        {
            try
            {
                return int.Parse(db.Sp_AsignarEncuestadoInsertar(_objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado,_objAsignarEncuestado.Comunidad.IdComunidad,_objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario,_objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario,_objAsignarEncuestado.Obligatorio,_objAsignarEncuestado.FechaInicio,_objAsignarEncuestado.FechaFin,_objAsignarEncuestado.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<CuestionariosAsignadosTecnicos> cuestionariosNuevoPorTecnico(int _idAsignarUsuarioTipoUsuario)
        {
            ; List<CuestionariosAsignadosTecnicos> _lista = new List<CuestionariosAsignadosTecnicos>();
            foreach (var item in db.Sp_VerEncuestaAsignadasNueva(_idAsignarUsuarioTipoUsuario))
            {
                _lista.Add(new CuestionariosAsignadosTecnicos(
                     _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                     _seguridad.Encriptar(item.IdCuestionarioGenerico.ToString()),
                      item.Nombre,
                      item.Descripcion,
                      item.NombreParroquia,
                      item.NombreCanton,
                      item.NombreParroquia,
                      item.NombreComunidad,
                      item.FechaInicioEncuesta,
                      item.FechaFinEncuesta,
                      item.PeriodoInicioCuestionario,
                      item.PeriodoFinCuestionario,
                      item.FechaPublicacionCuestionario,
                      _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                      Convert.ToInt32(item.CuestionarioFinalizado)
                ));
            }
            return _lista;
        }
        public int EditarAsignarEncuestado(AsignarEncuestado _objAsignarEncuestado)
        {
            try
            {
                db.Sp_AsignarEncuestadoModificar(int.Parse(_objAsignarEncuestado.IdEncuestadoEncriptado),_objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado, _objAsignarEncuestado.Comunidad.IdComunidad, _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario, _objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario, _objAsignarEncuestado.Obligatorio, _objAsignarEncuestado.FechaInicio, _objAsignarEncuestado.FechaFin, _objAsignarEncuestado.Estado).Select(x => x.Value.ToString()).FirstOrDefault();
                return (int.Parse(_objAsignarEncuestado.IdEncuestadoEncriptado));
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public void EliminarAsignarEncuestado(int _idAsignarEncuestado)
        {
            db.Sp_AsignarEncuestadoEliminar(_idAsignarEncuestado);
        }

        public List<AsignarEncuestado> ConsultarAsignarEncuestado()
        {
            List<AsignarEncuestado> _lista = new List<AsignarEncuestado>();
            foreach (var item in db.Sp_AsignarEncuestadoConsultar())
            {
                _lista.Add(new AsignarEncuestado()
                {
                    IdAsignarEncuestado=item.IdAsignarEncuestado,
                    IdAsignarEncuestadoEncriptado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                    FechaInicio = item.FechaInicioAsignarEncuestado,
                    FechaFin=item.FechaFinAsignarEncuestado,
                    Estado=item.EstadoAsignarEncuestado,
                    Obligatorio=item.ObligatorioAsignarEncuestado,
                    Utilizado=item.UtilizadoAsignarEncuestado,
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIORESPONSABLE_IdUsuario.ToString()),
                            IdUsuario = item.USUARIORESPONSABLE_IdUsuario,
                            Correo = item.USUARIORESPONSABLE_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIORESPONSABLE_Clave.ToString()),
                            Estado = item.USUARIORESPONSABLE_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONARESPONSABLE_IdPersona.ToString()),
                                IdPersona = item.PERSONARESPONSABLE_IdPersona,
                                PrimerNombre = item.PERSONARESPONSABLE_PrimerNombre,
                                SegundoNombre = item.PERSONARESPONSABLE_SegundoNombre,
                                PrimerApellido = item.PERSONARESPONSABLE_PrimerApellido,
                                SegundoApellido = item.PERSONARESPONSABLE_SegundoApellido,
                                NumeroIdentificacion = item.PERSONARESPONSABLE_NumeroIdentificacion,
                                Telefono = item.PERSONARESPONSABLE_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONARESPONSABLE_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXORESPONSABLE_IdSexo.ToString()),
                                    IdSexo = item.SEXORESPONSABLE_IdSexo,
                                    Identificador = item.SEXORESPONSABLE_Identificador,
                                    Descripcion = item.SEXORESPONSABLE_Descripcion,
                                    Estado = item.SEXORESPONSABLE_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONRESPONSABLE_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIORESPONSABLEN_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONRESPONSABLE_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIORESPONSABLE_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIORESPONSABLE_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIORESPONSABLE_Descripcion,
                            Estado = item.TIPOUSUARIORESPONSABLE_Estado,
                            Identificador = item.TIPOUSUARIORESPONSABLE_Identificador
                        }
                    },
                    AsignarUsuarioTipoUsuarioTecnico =new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOTECNICO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIOTECNICO_IdUsuario,
                            Correo = item.USUARIOTECNICO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIOTECNICO_Clave.ToString()),
                            Estado = item.USUARIOTECNICO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONATECNICO_IdPersona.ToString()),
                                IdPersona = item.PERSONATECNICO_IdPersona,
                                PrimerNombre = item.PERSONATECNICO_PrimerNombre,
                                SegundoNombre = item.PERSONATECNICO_SegundoNombre,
                                PrimerApellido = item.PERSONATECNICO_PrimerApellido,
                                SegundoApellido = item.PERSONATECNICO_SegundoApellido,
                                NumeroIdentificacion = item.PERSONATECNICO_NumeroIdentificacion,
                                Telefono = item.PERSONATECNICO_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONATECNICO_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXOTECNICO_IdSexo.ToString()),
                                    IdSexo = item.SEXOTECNICO_IdSexo,
                                    Identificador = item.SEXOTECNICO_Identificador,
                                    Descripcion = item.SEXOTECNICO_Descripcion,
                                    Estado = item.SEXOTECNICO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONTECNICO_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIOTECNICON_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONTECNICO_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIOTECNICO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOTECNICO_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIOTECNICO_Descripcion,
                            Estado = item.TIPOUSUARIOTECNICO_Estado,
                            Identificador = item.TIPOUSUARIOTECNICO_Identificador
                        }
                    },
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
                    },
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                        IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                        Estado = item.EstadoCuestionarioPublicado,
                        FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,
                        AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                        {
                            IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario,
                            IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario.ToString()),
                            Estado = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_Estado,
                            Usuario = new Usuario()
                            {
                                IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOPUBLICADO_IdUsuario.ToString()),
                                IdUsuario = item.USUARIOPUBLICADO_IdUsuario,
                                Correo = item.USUARIOPUBLICADO_Correo,
                                ClaveEncriptada = _seguridad.Encriptar(item.USUARIOPUBLICADO_Clave.ToString()),
                                Estado = item.USUARIOPUBLICADO_Estado,
                                Persona = new Persona()
                                {
                                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONAPUBLICADO_IdPersona.ToString()),
                                    IdPersona = item.PERSONAPUBLICADO_IdPersona,
                                    PrimerNombre = item.PERSONAPUBLICADO_PrimerNombre,
                                    SegundoNombre = item.PERSONAPUBLICADO_SegundoNombre,
                                    PrimerApellido = item.PERSONAPUBLICADO_PrimerApellido,
                                    SegundoApellido = item.PERSONAPUBLICADO_SegundoApellido,
                                    NumeroIdentificacion = item.PERSONAPUBLICADO_NumeroIdentificacion,
                                    Telefono = item.PERSONAPUBLICADO_Telefono,
                                    Direccion = item.PERSONA_Direccion,
                                    Estado = item.PERSONAPUBLICADO_Estado,
                                    Sexo = new Sexo()
                                    {
                                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXOPUBLICADO_IdSexo.ToString()),
                                        IdSexo = item.SEXOPUBLICADO_IdSexo,
                                        Identificador = item.SEXOPUBLICADO_Identificador,
                                        Descripcion = item.SEXOPUBLICADO_Descripcion,
                                        Estado = item.SEXOPUBLICADO_Estado,
                                    },
                                    TipoIdentificacion = new TipoIdentificacion()
                                    {
                                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONPUBLICADO_IdTipoIdentificacion.ToString()),
                                        IdTipoIdentificacion = item.TIPOIDENTIFICACIONPUBLICADO_IdTipoIdentificacion,
                                        Identificador = item.TIPOIDENTIFICACIONPUBLICADO_Identificador,
                                        Descripcion = item.TIPOIDENTIFICACIOPUBLICADON_Descripcion,
                                        Estado = item.TIPOIDENTIFICACIONPUBLICADO_Estado,
                                    }
                                }
                            },
                            TipoUsuario = new TipoUsuario()
                            {
                                IdTipoUsuario = item.TIPOUSUARIOPUBLICADO_IdTipoUsuario,
                                IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOPUBLICADO_IdTipoUsuario.ToString()),
                                Descripcion = item.TIPOUSUARIOPUBLICADO_Descripcion,
                                Estado = item.TIPOUSUARIOPUBLICADO_Estado,
                                Identificador = item.TIPOUSUARIOPUBLICADO_Identificador
                            }
                        },
                        Periodo = new Periodo()
                        {
                            IdPeriodo = item.IdPeriodo,
                            IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                            Estado = item.EstadoPeriodo,
                            FechaInicio = item.FechaInicioPeriodo,
                            FechaFin = item.FechaFinPeriodo
                        },
                        CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                        {
                            IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                            IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                            Caracteristica = item.CaracteristicaCabeceraVersionCuestionario,
                            Version = item.VersionCabeceraVersionCuestionario,
                            Estado = item.EstadoCabeceraVersionCuestionario,
                            AsignarResponsable = new AsignarResponsable()
                            {
                                IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                                IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                                Estado = item.ASIGNARRESPONSABLE_Estado,
                                FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                                CuestionarioGenerico = new CuestionarioGenerico()
                                {
                                    IdCuestionarioGenerico = item.CUESTIONARIOGENERICO_IdCuestionarioGenerico,
                                    IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.CUESTIONARIOGENERICO_IdCuestionarioGenerico.ToString()),
                                    Descripcion = item.CUESTIONARIOGENERICO_Descripcion,
                                    Estado = item.CUESTIONARIOGENERICO_Estado,
                                    Nombre = item.CUESTIONARIOGENERICO_Nombre,
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
                                        Descripcion = item.TIPOUSUARIO_Descripcion,
                                        Estado = item.TIPOUSUARIO_Estado,
                                        Identificador = item.TIPOUSUARIO_Identificador
                                    }
                                }
                            },
                            FechaCreacion = item.FechaCreacionCabeceraVersionCuestionario
                        }
                    }
                });
            }
            return _lista;
        }

        public List<AsignarEncuestado> ConsultarAsignarEncuestadoPorId(int _idAsignarEncuestado)
        {
            List<AsignarEncuestado> _lista = new List<AsignarEncuestado>();
            foreach (var item in db.Sp_AsignarEncuestadoConsultarPorId(_idAsignarEncuestado))
            {
                _lista.Add(new AsignarEncuestado()
                {
                    IdAsignarEncuestado = item.IdAsignarEncuestado,
                    IdAsignarEncuestadoEncriptado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                    FechaInicio = item.FechaInicioAsignarEncuestado,
                    FechaFin = item.FechaFinAsignarEncuestado,
                    Estado = item.EstadoAsignarEncuestado,
                    Obligatorio = item.ObligatorioAsignarEncuestado,
                    Utilizado = item.UtilizadoAsignarEncuestado,
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIORESPONSABLE_IdUsuario.ToString()),
                            IdUsuario = item.USUARIORESPONSABLE_IdUsuario,
                            Correo = item.USUARIORESPONSABLE_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIORESPONSABLE_Clave.ToString()),
                            Estado = item.USUARIORESPONSABLE_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONARESPONSABLE_IdPersona.ToString()),
                                IdPersona = item.PERSONARESPONSABLE_IdPersona,
                                PrimerNombre = item.PERSONARESPONSABLE_PrimerNombre,
                                SegundoNombre = item.PERSONARESPONSABLE_SegundoNombre,
                                PrimerApellido = item.PERSONARESPONSABLE_PrimerApellido,
                                SegundoApellido = item.PERSONARESPONSABLE_SegundoApellido,
                                NumeroIdentificacion = item.PERSONARESPONSABLE_NumeroIdentificacion,
                                Telefono = item.PERSONARESPONSABLE_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONARESPONSABLE_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXORESPONSABLE_IdSexo.ToString()),
                                    IdSexo = item.SEXORESPONSABLE_IdSexo,
                                    Identificador = item.SEXORESPONSABLE_Identificador,
                                    Descripcion = item.SEXORESPONSABLE_Descripcion,
                                    Estado = item.SEXORESPONSABLE_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONRESPONSABLE_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIORESPONSABLEN_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONRESPONSABLE_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIORESPONSABLE_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIORESPONSABLE_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIORESPONSABLE_Descripcion,
                            Estado = item.TIPOUSUARIORESPONSABLE_Estado,
                            Identificador = item.TIPOUSUARIORESPONSABLE_Identificador
                        }
                    },
                    AsignarUsuarioTipoUsuarioTecnico = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOTECNICO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIOTECNICO_IdUsuario,
                            Correo = item.USUARIOTECNICO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIOTECNICO_Clave.ToString()),
                            Estado = item.USUARIOTECNICO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONATECNICO_IdPersona.ToString()),
                                IdPersona = item.PERSONATECNICO_IdPersona,
                                PrimerNombre = item.PERSONATECNICO_PrimerNombre,
                                SegundoNombre = item.PERSONATECNICO_SegundoNombre,
                                PrimerApellido = item.PERSONATECNICO_PrimerApellido,
                                SegundoApellido = item.PERSONATECNICO_SegundoApellido,
                                NumeroIdentificacion = item.PERSONATECNICO_NumeroIdentificacion,
                                Telefono = item.PERSONATECNICO_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONATECNICO_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXOTECNICO_IdSexo.ToString()),
                                    IdSexo = item.SEXOTECNICO_IdSexo,
                                    Identificador = item.SEXOTECNICO_Identificador,
                                    Descripcion = item.SEXOTECNICO_Descripcion,
                                    Estado = item.SEXOTECNICO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONTECNICO_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIOTECNICON_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONTECNICO_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIOTECNICO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOTECNICO_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIOTECNICO_Descripcion,
                            Estado = item.TIPOUSUARIOTECNICO_Estado,
                            Identificador = item.TIPOUSUARIOTECNICO_Identificador
                        }
                    },
                    Comunidad = new Comunidad()
                    {
                        IdComunidad = item.IdComunidad,
                        IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                        CodigoComunidad = item.CodigoComunidad,
                        DescripcionComunidad = item.DescripcionComunidad,
                        EstadoComunidad = item.EstadoComunidad,
                        NombreComunidad = item.NombreComunidad,
                        RutaLogoComunidad = item.RutaLogoComunidad,
                        latitud= item.latitud,
                        longitud= item.longitud,
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
                    },
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                        IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                        Estado = item.EstadoCuestionarioPublicado,
                        FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,
                        AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                        {
                            IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario,
                            IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario.ToString()),
                            Estado = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_Estado,
                            Usuario = new Usuario()
                            {
                                IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOPUBLICADO_IdUsuario.ToString()),
                                IdUsuario = item.USUARIOPUBLICADO_IdUsuario,
                                Correo = item.USUARIOPUBLICADO_Correo,
                                ClaveEncriptada = _seguridad.Encriptar(item.USUARIOPUBLICADO_Clave.ToString()),
                                Estado = item.USUARIOPUBLICADO_Estado,
                                Persona = new Persona()
                                {
                                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONAPUBLICADO_IdPersona.ToString()),
                                    IdPersona = item.PERSONAPUBLICADO_IdPersona,
                                    PrimerNombre = item.PERSONAPUBLICADO_PrimerNombre,
                                    SegundoNombre = item.PERSONAPUBLICADO_SegundoNombre,
                                    PrimerApellido = item.PERSONAPUBLICADO_PrimerApellido,
                                    SegundoApellido = item.PERSONAPUBLICADO_SegundoApellido,
                                    NumeroIdentificacion = item.PERSONAPUBLICADO_NumeroIdentificacion,
                                    Telefono = item.PERSONAPUBLICADO_Telefono,
                                    Direccion = item.PERSONA_Direccion,
                                    Estado = item.PERSONAPUBLICADO_Estado,
                                    Sexo = new Sexo()
                                    {
                                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXOPUBLICADO_IdSexo.ToString()),
                                        IdSexo = item.SEXOPUBLICADO_IdSexo,
                                        Identificador = item.SEXOPUBLICADO_Identificador,
                                        Descripcion = item.SEXOPUBLICADO_Descripcion,
                                        Estado = item.SEXOPUBLICADO_Estado,
                                    },
                                    TipoIdentificacion = new TipoIdentificacion()
                                    {
                                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONPUBLICADO_IdTipoIdentificacion.ToString()),
                                        IdTipoIdentificacion = item.TIPOIDENTIFICACIONPUBLICADO_IdTipoIdentificacion,
                                        Identificador = item.TIPOIDENTIFICACIONPUBLICADO_Identificador,
                                        Descripcion = item.TIPOIDENTIFICACIOPUBLICADON_Descripcion,
                                        Estado = item.TIPOIDENTIFICACIONPUBLICADO_Estado,
                                    }
                                }
                            },
                            TipoUsuario = new TipoUsuario()
                            {
                                IdTipoUsuario = item.TIPOUSUARIOPUBLICADO_IdTipoUsuario,
                                IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOPUBLICADO_IdTipoUsuario.ToString()),
                                Descripcion = item.TIPOUSUARIOPUBLICADO_Descripcion,
                                Estado = item.TIPOUSUARIOPUBLICADO_Estado,
                                Identificador = item.TIPOUSUARIOPUBLICADO_Identificador
                            }
                        },
                        Periodo = new Periodo()
                        {
                            IdPeriodo = item.IdPeriodo,
                            IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                            Estado = item.EstadoPeriodo,
                            FechaInicio = item.FechaInicioPeriodo,
                            FechaFin = item.FechaFinPeriodo
                        },
                        CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                        {
                            IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                            IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                            Caracteristica = item.CaracteristicaCabeceraVersionCuestionario,
                            Version = item.VersionCabeceraVersionCuestionario,
                            Estado = item.EstadoCabeceraVersionCuestionario,
                            AsignarResponsable = new AsignarResponsable()
                            {
                                IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                                IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                                Estado = item.ASIGNARRESPONSABLE_Estado,
                                FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                                CuestionarioGenerico = new CuestionarioGenerico()
                                {
                                    IdCuestionarioGenerico = item.CUESTIONARIOGENERICO_IdCuestionarioGenerico,
                                    IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.CUESTIONARIOGENERICO_IdCuestionarioGenerico.ToString()),
                                    Descripcion = item.CUESTIONARIOGENERICO_Descripcion,
                                    Estado = item.CUESTIONARIOGENERICO_Estado,
                                    Nombre = item.CUESTIONARIOGENERICO_Nombre,
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
                                        Descripcion = item.TIPOUSUARIO_Descripcion,
                                        Estado = item.TIPOUSUARIO_Estado,
                                        Identificador = item.TIPOUSUARIO_Identificador
                                    }
                                }
                            },
                            FechaCreacion = item.FechaCreacionCabeceraVersionCuestionario
                        }
                    }
                });
            }
            return _lista;
        }

        public List<AsignarEncuestado> ConsultarAsignarEncuestadPorIdCuestionarioPublicado(int _idCuestionarioPublicado)
        {
            List<AsignarEncuestado> _lista = new List<AsignarEncuestado>();
            foreach (var item in db.Sp_AsignarEncuestadoConsultarPorCuestionarioPublicado(_idCuestionarioPublicado))
            {
                _lista.Add(new AsignarEncuestado()
                {
                    IdAsignarEncuestado = item.IdAsignarEncuestado,
                    IdAsignarEncuestadoEncriptado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                    FechaInicio = item.FechaInicioAsignarEncuestado,
                    FechaFin = item.FechaFinAsignarEncuestado,
                    Estado = item.EstadoAsignarEncuestado,
                    Obligatorio = item.ObligatorioAsignarEncuestado,
                    Utilizado = item.UtilizadoAsignarEncuestado,
                    FinalizadaCabeceraRespuestas= Convert.ToString(item.FinalizadaCabeceraRespuestas),
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIORESPONSABLE_IdUsuario.ToString()),
                            IdUsuario = item.USUARIORESPONSABLE_IdUsuario,
                            Correo = item.USUARIORESPONSABLE_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIORESPONSABLE_Clave.ToString()),
                            Estado = item.USUARIORESPONSABLE_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONARESPONSABLE_IdPersona.ToString()),
                                IdPersona = item.PERSONARESPONSABLE_IdPersona,
                                PrimerNombre = item.PERSONARESPONSABLE_PrimerNombre,
                                SegundoNombre = item.PERSONARESPONSABLE_SegundoNombre,
                                PrimerApellido = item.PERSONARESPONSABLE_PrimerApellido,
                                SegundoApellido = item.PERSONARESPONSABLE_SegundoApellido,
                                NumeroIdentificacion = item.PERSONARESPONSABLE_NumeroIdentificacion,
                                Telefono = item.PERSONARESPONSABLE_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONARESPONSABLE_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXORESPONSABLE_IdSexo.ToString()),
                                    IdSexo = item.SEXORESPONSABLE_IdSexo,
                                    Identificador = item.SEXORESPONSABLE_Identificador,
                                    Descripcion = item.SEXORESPONSABLE_Descripcion,
                                    Estado = item.SEXORESPONSABLE_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONRESPONSABLE_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIORESPONSABLEN_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONRESPONSABLE_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIORESPONSABLE_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIORESPONSABLE_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIORESPONSABLE_Descripcion,
                            Estado = item.TIPOUSUARIORESPONSABLE_Estado,
                            Identificador = item.TIPOUSUARIORESPONSABLE_Identificador
                        }
                    },
                    AsignarUsuarioTipoUsuarioTecnico = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOTECNICO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIOTECNICO_IdUsuario,
                            Correo = item.USUARIOTECNICO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIOTECNICO_Clave.ToString()),
                            Estado = item.USUARIOTECNICO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONATECNICO_IdPersona.ToString()),
                                IdPersona = item.PERSONATECNICO_IdPersona,
                                PrimerNombre = item.PERSONATECNICO_PrimerNombre,
                                SegundoNombre = item.PERSONATECNICO_SegundoNombre,
                                PrimerApellido = item.PERSONATECNICO_PrimerApellido,
                                SegundoApellido = item.PERSONATECNICO_SegundoApellido,
                                NumeroIdentificacion = item.PERSONATECNICO_NumeroIdentificacion,
                                Telefono = item.PERSONATECNICO_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONATECNICO_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXOTECNICO_IdSexo.ToString()),
                                    IdSexo = item.SEXOTECNICO_IdSexo,
                                    Identificador = item.SEXOTECNICO_Identificador,
                                    Descripcion = item.SEXOTECNICO_Descripcion,
                                    Estado = item.SEXOTECNICO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONTECNICO_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIOTECNICON_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONTECNICO_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIOTECNICO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOTECNICO_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIOTECNICO_Descripcion,
                            Estado = item.TIPOUSUARIOTECNICO_Estado,
                            Identificador = item.TIPOUSUARIOTECNICO_Identificador
                        }
                    },
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
                    },
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                        IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                        Estado = item.EstadoCuestionarioPublicado,
                        FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,
                        AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                        {
                            IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario,
                            IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario.ToString()),
                            Estado = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_Estado,
                            Usuario = new Usuario()
                            {
                                IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOPUBLICADO_IdUsuario.ToString()),
                                IdUsuario = item.USUARIOPUBLICADO_IdUsuario,
                                Correo = item.USUARIOPUBLICADO_Correo,
                                ClaveEncriptada = _seguridad.Encriptar(item.USUARIOPUBLICADO_Clave.ToString()),
                                Estado = item.USUARIOPUBLICADO_Estado,
                                Persona = new Persona()
                                {
                                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONAPUBLICADO_IdPersona.ToString()),
                                    IdPersona = item.PERSONAPUBLICADO_IdPersona,
                                    PrimerNombre = item.PERSONAPUBLICADO_PrimerNombre,
                                    SegundoNombre = item.PERSONAPUBLICADO_SegundoNombre,
                                    PrimerApellido = item.PERSONAPUBLICADO_PrimerApellido,
                                    SegundoApellido = item.PERSONAPUBLICADO_SegundoApellido,
                                    NumeroIdentificacion = item.PERSONAPUBLICADO_NumeroIdentificacion,
                                    Telefono = item.PERSONAPUBLICADO_Telefono,
                                    Direccion = item.PERSONA_Direccion,
                                    Estado = item.PERSONAPUBLICADO_Estado,
                                    Sexo = new Sexo()
                                    {
                                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXOPUBLICADO_IdSexo.ToString()),
                                        IdSexo = item.SEXOPUBLICADO_IdSexo,
                                        Identificador = item.SEXOPUBLICADO_Identificador,
                                        Descripcion = item.SEXOPUBLICADO_Descripcion,
                                        Estado = item.SEXOPUBLICADO_Estado,
                                    },
                                    TipoIdentificacion = new TipoIdentificacion()
                                    {
                                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONPUBLICADO_IdTipoIdentificacion.ToString()),
                                        IdTipoIdentificacion = item.TIPOIDENTIFICACIONPUBLICADO_IdTipoIdentificacion,
                                        Identificador = item.TIPOIDENTIFICACIONPUBLICADO_Identificador,
                                        Descripcion = item.TIPOIDENTIFICACIOPUBLICADON_Descripcion,
                                        Estado = item.TIPOIDENTIFICACIONPUBLICADO_Estado,
                                    }
                                }
                            },
                            TipoUsuario = new TipoUsuario()
                            {
                                IdTipoUsuario = item.TIPOUSUARIOPUBLICADO_IdTipoUsuario,
                                IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOPUBLICADO_IdTipoUsuario.ToString()),
                                Descripcion = item.TIPOUSUARIOPUBLICADO_Descripcion,
                                Estado = item.TIPOUSUARIOPUBLICADO_Estado,
                                Identificador = item.TIPOUSUARIOPUBLICADO_Identificador
                            }
                        },
                        Periodo = new Periodo()
                        {
                            IdPeriodo = item.IdPeriodo,
                            IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                            Estado = item.EstadoPeriodo,
                            FechaInicio = item.FechaInicioPeriodo,
                            FechaFin = item.FechaFinPeriodo
                        },
                        CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                        {
                            IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                            IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                            Caracteristica = item.CaracteristicaCabeceraVersionCuestionario,
                            Version = item.VersionCabeceraVersionCuestionario,
                            Estado = item.EstadoCabeceraVersionCuestionario,
                            AsignarResponsable = new AsignarResponsable()
                            {
                                IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                                IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                                Estado = item.ASIGNARRESPONSABLE_Estado,
                                FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                                CuestionarioGenerico = new CuestionarioGenerico()
                                {
                                    IdCuestionarioGenerico = item.CUESTIONARIOGENERICO_IdCuestionarioGenerico,
                                    IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.CUESTIONARIOGENERICO_IdCuestionarioGenerico.ToString()),
                                    Descripcion = item.CUESTIONARIOGENERICO_Descripcion,
                                    Estado = item.CUESTIONARIOGENERICO_Estado,
                                    Nombre = item.CUESTIONARIOGENERICO_Nombre,
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
                                        Descripcion = item.TIPOUSUARIO_Descripcion,
                                        Estado = item.TIPOUSUARIO_Estado,
                                        Identificador = item.TIPOUSUARIO_Identificador
                                    }
                                }
                            },
                            FechaCreacion = item.FechaCreacionCabeceraVersionCuestionario
                        }
                    }
                });
            }
            return _lista;
        }

        public List<AsignarEncuestado> ConsultarAsignarEncuestadoPorIdAsignarUsuarioTipoUsuario(int _idAsignarUsuarioTipoUsuario)
        {
            List<AsignarEncuestado> _lista = new List<AsignarEncuestado>();
            foreach (var item in db.Sp_AsignarEncuestadoConsultarPorTecnico(_idAsignarUsuarioTipoUsuario))
            {
                _lista.Add(new AsignarEncuestado()
                {
                    IdAsignarEncuestado = item.IdAsignarEncuestado,
                    IdAsignarEncuestadoEncriptado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                    FechaInicio = item.FechaInicioAsignarEncuestado,
                    FechaFin = item.FechaFinAsignarEncuestado,
                    Estado = item.EstadoAsignarEncuestado,
                    Obligatorio = item.ObligatorioAsignarEncuestado,
                    Utilizado = item.UtilizadoAsignarEncuestado,
                    FinalizadaCabeceraRespuestas=item.CabeceraRespuestaFinalizada,
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIORESPONSABLE_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIORESPONSABLE_IdUsuario.ToString()),
                            IdUsuario = item.USUARIORESPONSABLE_IdUsuario,
                            Correo = item.USUARIORESPONSABLE_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIORESPONSABLE_Clave.ToString()),
                            Estado = item.USUARIORESPONSABLE_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONARESPONSABLE_IdPersona.ToString()),
                                IdPersona = item.PERSONARESPONSABLE_IdPersona,
                                PrimerNombre = item.PERSONARESPONSABLE_PrimerNombre,
                                SegundoNombre = item.PERSONARESPONSABLE_SegundoNombre,
                                PrimerApellido = item.PERSONARESPONSABLE_PrimerApellido,
                                SegundoApellido = item.PERSONARESPONSABLE_SegundoApellido,
                                NumeroIdentificacion = item.PERSONARESPONSABLE_NumeroIdentificacion,
                                Telefono = item.PERSONARESPONSABLE_Telefono,
                                Estado = item.PERSONARESPONSABLE_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXORESPONSABLE_IdSexo.ToString()),
                                    IdSexo = item.SEXORESPONSABLE_IdSexo,
                                    Identificador = item.SEXORESPONSABLE_Identificador,
                                    Descripcion = item.SEXORESPONSABLE_Descripcion,
                                    Estado = item.SEXORESPONSABLE_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONRESPONSABLE_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONRESPONSABLE_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIORESPONSABLEN_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONRESPONSABLE_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIORESPONSABLE_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIORESPONSABLE_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIORESPONSABLE_Descripcion,
                            Estado = item.TIPOUSUARIORESPONSABLE_Estado,
                            Identificador = item.TIPOUSUARIORESPONSABLE_Identificador
                        }
                    },
                    AsignarUsuarioTipoUsuarioTecnico = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIOTECNICO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIOTECNICO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIOTECNICO_IdUsuario,
                            Correo = item.USUARIOTECNICO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIOTECNICO_Clave.ToString()),
                            Estado = item.USUARIOTECNICO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONATECNICO_IdPersona.ToString()),
                                IdPersona = item.PERSONATECNICO_IdPersona,
                                PrimerNombre = item.PERSONATECNICO_PrimerNombre,
                                SegundoNombre = item.PERSONATECNICO_SegundoNombre,
                                PrimerApellido = item.PERSONATECNICO_PrimerApellido,
                                SegundoApellido = item.PERSONATECNICO_SegundoApellido,
                                NumeroIdentificacion = item.PERSONATECNICO_NumeroIdentificacion,
                                Telefono = item.PERSONATECNICO_Telefono,
                                Estado = item.PERSONATECNICO_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXOTECNICO_IdSexo.ToString()),
                                    IdSexo = item.SEXOTECNICO_IdSexo,
                                    Identificador = item.SEXOTECNICO_Identificador,
                                    Descripcion = item.SEXOTECNICO_Descripcion,
                                    Estado = item.SEXOTECNICO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACIONTECNICO_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACIONTECNICO_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACIOTECNICON_Descripcion,
                                    Estado = item.TIPOIDENTIFICACIONTECNICO_Estado,
                                }
                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIOTECNICO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIOTECNICO_IdTipoUsuario.ToString()),
                            Descripcion = item.TIPOUSUARIOTECNICO_Descripcion,
                            Estado = item.TIPOUSUARIOTECNICO_Estado,
                            Identificador = item.TIPOUSUARIOTECNICO_Identificador
                        }
                    },
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
                    },
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                        IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                        Estado = item.EstadoCuestionarioPublicado,
                        FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,                      
                        Periodo = new Periodo()
                        {
                            IdPeriodo = item.IdPeriodo,
                            IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                            Estado = item.EstadoPeriodo,
                            FechaInicio = item.FechaInicioPeriodo,
                            FechaFin = item.FechaFinPeriodo
                        }
                    }
                });
            }
            return _lista;
        }

    }
}