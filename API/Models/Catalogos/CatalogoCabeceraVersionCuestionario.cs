using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoCabeceraVersionCuestionario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarCabeceraVersionCuestionario(CabeceraVersionCuestionario _objCabeceraVersionCuestionario)
        {
            try
            {
                return int.Parse(db.Sp_CabeceraVersionCuestionarioInsertar(_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable,_objCabeceraVersionCuestionario.Caracteristica,_objCabeceraVersionCuestionario.Version,_objCabeceraVersionCuestionario.FechaCreacion, _objCabeceraVersionCuestionario.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarCabeceraVersionCuestionario(CabeceraVersionCuestionario _objCabeceraVersionCuestionario)
        {
            try
            {
                db.Sp_CabeceraVersionCuestionarioModificar(_objCabeceraVersionCuestionario.IdCabeceraVersionCuestionario,_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable, _objCabeceraVersionCuestionario.Caracteristica, _objCabeceraVersionCuestionario.Version, _objCabeceraVersionCuestionario.FechaCreacion, _objCabeceraVersionCuestionario.Estado);
                return _objCabeceraVersionCuestionario.IdCabeceraVersionCuestionario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarCabeceraVersionCuestionario(int _idCabeceraVersionCuestionario)
        {
            db.Sp_CabeceraVersionCuestionarioEliminar(_idCabeceraVersionCuestionario);
        }

        public List<CabeceraVersionCuestionario> ConsultarCabeceraVersionCuestionario()
        {
            List<CabeceraVersionCuestionario> _lista = new List<CabeceraVersionCuestionario>();
            foreach (var item in db.Sp_CabeceraVersionCuestionarioConsultar())
            {
                _lista.Add(new CabeceraVersionCuestionario()
                {
                    IdCabeceraVersionCuestionario=item.IdCabeceraVersionCuestionario,
                    IdCabeceraVersionCuestionarioEncriptado=_seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                    Caracteristica=item.CaracteristicaCabeceraVersionCuestionario,
                    Version=item.VersionCabeceraVersionCuestionario,
                    Estado=item.EstadoCabeceraVersionCuestionario,
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
                    FechaCreacion=item.FechaCreacionCabeceraVersionCuestionario,
                    Utilizado=item.UtilizadoCabeceraVersionCuestionario
                });
            }
            return _lista;
        }

          public List<CabeceraVersionCuestionario> ConsultarCabeceraVersionCuestionarioPorId(int _idCabeceraVersionCuestionario)
        {
            List<CabeceraVersionCuestionario> _lista = new List<CabeceraVersionCuestionario>();
            foreach (var item in db.Sp_CabeceraVersionCuestionarioConsultar().Where(c=>c.IdCabeceraVersionCuestionario==_idCabeceraVersionCuestionario).ToList())
            {
                _lista.Add(new CabeceraVersionCuestionario()
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
                });
            }
            return _lista;
        }
    }
}