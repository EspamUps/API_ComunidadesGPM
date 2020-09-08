using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoVersionamientoPregunta
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarVersionamientoPregunta(VersionamientoPregunta _objVersionamientoPregunta )
        {
            try
            {
                return int.Parse(db.Sp_VersionamientoPreguntaInsertar(_objVersionamientoPregunta.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario,_objVersionamientoPregunta.Pregunta.IdPregunta, _objVersionamientoPregunta.Pregunta.Seccion.IdSeccion, _objVersionamientoPregunta.Pregunta.Seccion.Componente.IdComponente, _objVersionamientoPregunta.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarVersionamientoPregunta(int _idVersionamientoPregunta)
        {
            db.Sp_VersionamientoPreguntaEliminar(_idVersionamientoPregunta);
        }
        public List<VersionamientoPregunta> ConsultarVersionamientoPregunta()
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_VersionamientoPreguntaConsultar())
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.Estado,
                    CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                    {
                        IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                        IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString())
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString())
                    }
                });
            }
            return _lista;
        }
        public List<VersionamientoPregunta> ConsultarVersionamientoPreguntaPorIdCabeceraVersionCuestionario(int _idCabeceraVersionCuestionario)
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_VersionamientoPreguntaConsultar().Where(c => c.IdCabeceraVersionCuestionario == _idCabeceraVersionCuestionario).ToList())
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.Estado,
                    CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                    {
                        IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                        IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString())
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString())
                    }
                });
            }
            return _lista;
        }
        public List<VersionamientoPregunta> ConsultarVersionamientoPreguntaCompletoPorIdCabeceraVersion(int _idCabeceraVersion)
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_VersionamientoPreguntaCompletoConsultarPorCabeceraVersion(_idCabeceraVersion))
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.EstadoVersionamientoPregunta,
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Descripcion = item.DescripcionPregunta,
                        Estado = item.EstadoPregunta,
                        Obligatorio = item.ObligatorioPregunta,
                        Orden = item.OrdenPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta,
                            Identificador = item.IdentificadorTipoPregunta
                        },
                        Seccion = new Seccion()
                        {
                            IdSeccion = item.IdSeccion,
                            IdSeccionEncriptado = _seguridad.Encriptar(item.IdSeccion.ToString()),
                            Descripcion = item.DescripcionSeccion,
                            Estado = item.EstadoSeccion,
                            Orden = item.OrdenSeccion,
                            Componente = new Componente()
                            {
                                IdComponente = item.IdComponente,
                                IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString()),
                                Descripcion = item.DescripcionComponente,
                                Estado = item.EstadoComponente,
                                Orden = item.OrdenComponente,
                            }
                        }
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
                });
            }
            return _lista;
        }
        public List<VersionamientoPregunta> ConsultarVersionamientoPreguntaCompletoPorIdCabeceraVersionPorIdComponente(int _idCabeceraVersion, int _idComponente)
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_VersionamientoPreguntaCompletoConsultarPorCabeceraVersion(_idCabeceraVersion).Where(c => c.IdComponente == _idComponente))
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.EstadoVersionamientoPregunta,
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Descripcion = item.DescripcionPregunta,
                        Estado = item.EstadoPregunta,
                        Obligatorio = item.ObligatorioPregunta,
                        Orden = item.OrdenPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta,
                            Identificador = item.IdentificadorTipoPregunta
                        },
                        Seccion = new Seccion()
                        {
                            IdSeccion = item.IdSeccion,
                            IdSeccionEncriptado = _seguridad.Encriptar(item.IdSeccion.ToString()),
                            Descripcion = item.DescripcionSeccion,
                            Estado = item.EstadoSeccion,
                            Orden = item.OrdenSeccion,
                            Componente = new Componente()
                            {
                                IdComponente = item.IdComponente,
                                IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString()),
                                Descripcion = item.DescripcionComponente,
                                Estado = item.EstadoComponente,
                                Orden = item.OrdenComponente,
                            }
                        }
                    },
                    CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                    {
                        IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                        IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                    }
                });
            }
            return _lista;
        }
        public List<VersionamientoPregunta> ConsultarPreguntasPorCuestionarioPublicadoComponente(AsignarCuestionarioModelo _AsignarCuestionarioModelo)
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_ConsultarPreguntasPorCuestionarioPublicadoComponente(int.Parse(_AsignarCuestionarioModelo.IdCuestionarioPublicado), int.Parse(_AsignarCuestionarioModelo.AsignarComponenteGenerico[0].IdComponente)))
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.EstadoVersionamientoPregunta,
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Descripcion = item.DescripcionPregunta,
                        Estado = item.EstadoPregunta,
                        Obligatorio = item.ObligatorioPregunta,
                        Orden = item.OrdenPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta,
                            Identificador = item.IdentificadorTipoPregunta
                        },
                        Seccion = new Seccion()
                        {
                            IdSeccion = item.IdSeccion,
                            IdSeccionEncriptado = _seguridad.Encriptar(item.IdSeccion.ToString()),
                            Descripcion = item.DescripcionSeccion,
                            Estado = item.EstadoSeccion,
                            Orden = item.OrdenSeccion,
                            Componente = new Componente()
                            {
                                IdComponente = item.IdComponente,
                                IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString()),
                                Descripcion = item.DescripcionComponente,
                                Estado = item.EstadoComponente,
                                Orden = item.OrdenComponente,
                            }
                        }
                    },
                    CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                    {
                        IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                        IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                    }
                });
            }
            return _lista;
        }
    }
}