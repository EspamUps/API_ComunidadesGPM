using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarResponsable
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int InsertarAsignarResponsable(AsignarResponsable _objAsignarResponsable)
        {
            try
            {
                return int.Parse(db.Sp_AsignarResponsableInsertar(_objAsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario, _objAsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico, _objAsignarResponsable.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void CambiarEstadoAsignarResponsable (int _idAsignarResponsable, bool _nuevoEstado)
        {
            db.Sp_AsignarResponsableCambiarEstado(_idAsignarResponsable, _nuevoEstado);
        }
        public void EliminarAsignarResponsable(int _idAsignarResponsable)
        {
            db.Sp_AsignarResponsableEliminar(_idAsignarResponsable);
        }
        public List<AsignarResponsable> ConsultarAsignarResponsablePorId(int _idAsignarResponsable)
        {
            List<AsignarResponsable> _lista = new List<AsignarResponsable>();
            foreach (var item in db.Sp_AsignarResponsableConsultar().Where(c => c.ASIGNARRESPONSABLE_IdAsignarResponsable == _idAsignarResponsable).ToList())
            {
                _lista.Add(new AsignarResponsable()
                {
                    IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                    IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                    Estado = item.ASIGNARRESPONSABLE_Estado,
                    FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                    Utilizado = item.AsignarResponsable_Utilizado,
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
                });
            }
            return _lista;
        }
        public List<AsignarResponsable> ConsultarAsignarResponsablePorIdCuestionarioGenerico(int _idCuestionarioGenerico)
        {
            List<AsignarResponsable> _lista = new List<AsignarResponsable>();
            foreach (var item in db.Sp_AsignarResponsableConsultar().Where(c=>c.CUESTIONARIOGENERICO_IdCuestionarioGenerico== _idCuestionarioGenerico).ToList())
            {
                _lista.Add(new AsignarResponsable()
                {
                    IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                    IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                    Estado = item.ASIGNARRESPONSABLE_Estado,
                    FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                    Utilizado = item.AsignarResponsable_Utilizado,
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
                            Descripcion=item.TIPOUSUARIO_Descripcion,
                            Estado =item.TIPOUSUARIO_Estado,
                            Identificador=item.TIPOUSUARIO_Identificador
                        }
                    }
                });
            }
            return _lista;
        }


        public List<AsignarResponsable> ConsultarAsignarResponsablePorIdAsignarUsuarioTipoUsuario(int _idAsignarUsuarioTipoUsuario)
        {
            List<AsignarResponsable> _lista = new List<AsignarResponsable>();
            foreach (var item in db.Sp_AsignarResponsableConsultar().Where(c => c.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario == _idAsignarUsuarioTipoUsuario).ToList())
            {
                _lista.Add(new AsignarResponsable()
                {
                    IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                    IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                    Estado = item.ASIGNARRESPONSABLE_Estado,
                    FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                    Utilizado = item.AsignarResponsable_Utilizado,
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
                });
            }
            return _lista;
        }
    }
}