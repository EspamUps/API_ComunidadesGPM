using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoCuestionarioPublicado
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        
        public int InsertarCuestionarioPublicado(CuestionarioPublicado _objCuestionarioPublicado)
        {
            try
            {
                return int.Parse(db.Sp_CuestionarioPublicadoInsertar(_objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario, _objCuestionarioPublicado.Periodo.IdPeriodo, _objCuestionarioPublicado.FechaPublicacion, _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario, _objCuestionarioPublicado.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarCuestionarioPublicado(int _idCuestionarioPublicado)
        {
            db.Sp_CuestionarioPublicadoEliminar(_idCuestionarioPublicado);
        }

        public void DeshabilitarCuestionarioPublicado(int _idCuestionarioPublicado)
        {
            db.Sp_CuestionarioPublicadoDeshabilitar(_idCuestionarioPublicado);
        }

        public void FinalizarCuestionarioAsignado(int _idCuestionarioAsignado)
        {
            db.Sp_CuestionarioAsignadoFinalizar(_idCuestionarioAsignado);
        }

        public void SeleccionarPregunta(int _idPregunta)
        {
            db.Sp_SeleccionarPregunta(_idPregunta);
        }

        public List<CuestionarioPublicado> ConsultarCuestionarioPublicado()
        {
            List<CuestionarioPublicado> _lista = new List<CuestionarioPublicado>();
            foreach (var item in db.Sp_CuestionarioPublicadoConsultar())
            {
                _lista.Add(new CuestionarioPublicado()
                {
                    IdCuestionarioPublicado=item.IdCuestionarioPublicado,
                    IdCuestionarioPublicadoEncriptado=_seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                    Estado=item.EstadoCuestionarioPublicado,
                    FechaPublicacion=item.FechaPublicacionCuestionarioPublicado, 
                    Utilizado=item.UtilizadoCuestionarioPublicado,
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
                    Periodo = new Periodo() {
                        IdPeriodo=item.IdPeriodo,
                        IdPeriodoEncriptado=_seguridad.Encriptar(item.IdPeriodo.ToString()),
                        Estado=item.EstadoPeriodo,
                        FechaInicio=item.FechaInicioPeriodo,
                        FechaFin=item.FechaFinPeriodo,
                        Descripcion = item.DescripcionPeriodo
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
                        FechaCreacion = item.FechaCreacionCabeceraVersionCuestionario,
                        Utilizado = item.UtilizadoCabeceraVersionCuestionario
                    }
                });
            }
            return _lista;
        }



        public List<CuestionarioPublicado> ConsultarCuestionarioPublicadoPorId(int _idCuestionarioPublicado)
        {
            List<CuestionarioPublicado> _lista = new List<CuestionarioPublicado>();
            foreach (var item in db.Sp_CuestionarioPublicadoConsultar().Where(c=>c.IdCuestionarioPublicado==_idCuestionarioPublicado).ToList())
            {
                _lista.Add(new CuestionarioPublicado()
                {
                    IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                    IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                    Estado = item.EstadoCuestionarioPublicado,
                    FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,
                    Utilizado = item.UtilizadoCuestionarioPublicado,
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
                        FechaCreacion = item.FechaCreacionCabeceraVersionCuestionario,
                        Utilizado = item.UtilizadoCabeceraVersionCuestionario
                    }
                });
            }
            return _lista;
        }
    }
}