using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarUsuarioTipoUsuario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<AsignarUsuarioTipoUsuario> ConsultarAsignarUsuarioTipoUsuario()
        {
            List<AsignarUsuarioTipoUsuario> listaAsignarUsuarioTipoUsuario = new List<AsignarUsuarioTipoUsuario>();
            foreach (var item in db.Sp_AsignarUsuarioTipoUsuarioConsultar())
            {
                listaAsignarUsuarioTipoUsuario.Add(new AsignarUsuarioTipoUsuario()
                {
                    IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                    IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                    Usuario = new Usuario()
                    {
                        IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                        IdUsuario = item.USUARIO_IdUsuario,
                        Correo = item.USUARIO_Correo,
                        //Clave = item.USUARIO_Clave,
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
                    }
                });
            }
            return listaAsignarUsuarioTipoUsuario;
        }

        public List<AsignarUsuarioTipoUsuario> ConsultarAsignarUsuarioTipoUsuarioPorId(int _idAsignarUsuarioTipoUsuario)
        {
            List<AsignarUsuarioTipoUsuario> listaAsignarUsuarioTipoUsuario = new List<AsignarUsuarioTipoUsuario>();
            foreach (var item in db.Sp_AsignarUsuarioTipoUsuarioConsultar().Where(c => c.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario == _idAsignarUsuarioTipoUsuario).ToList())
            {
                listaAsignarUsuarioTipoUsuario.Add(new AsignarUsuarioTipoUsuario()
                {
                    IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                    IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                    Usuario = new Usuario()
                    {
                        IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                        IdUsuario = item.USUARIO_IdUsuario,
                        Correo = item.USUARIO_Correo,
                        //Clave = item.USUARIO_Clave,
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
                    }
                });
            }
            return listaAsignarUsuarioTipoUsuario;
        }

        public int InsertarAsignarUsuarioTipoUsuario(AsignarUsuarioTipoUsuario _objAsignarUsuarioTipoUsuario)
        {
            int _idAsignarUsuarioTipoUsuarioIngresado = 0;
            try
            {
                _idAsignarUsuarioTipoUsuarioIngresado = int.Parse(db.Sp_AsignarUsuarioTipoUsuarioInsertar(_objAsignarUsuarioTipoUsuario.Usuario.IdUsuario, _objAsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario, _objAsignarUsuarioTipoUsuario.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return _idAsignarUsuarioTipoUsuarioIngresado;
            }
            return _idAsignarUsuarioTipoUsuarioIngresado;
        }

        public int CambiarEstadoAsignarUsuarioTipoUsuario(int _idAsignarUsuarioTipoUsuario, bool _nuevoEstado)
        {
            try
            {
                db.Sp_AsignarUsuarioTipoUsuarioCambiarEstado(_idAsignarUsuarioTipoUsuario, _nuevoEstado);
                return _idAsignarUsuarioTipoUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<AsignarUsuarioTipoUsuario> ConsultarAsignarUsuarioTipoUsuarioNoAsignadosResponsablePorCuestionarioGenericoPorIdentificadorTipoUsuario(int _idCuestionarioGenerico, int _identificadorTipoUsuario)
        {
            List<AsignarUsuarioTipoUsuario> _lista = new List<AsignarUsuarioTipoUsuario>();
            foreach (var item in db.Sp_AsignarUsuarioTipoUsuarioConsultarNoAsignadosResponsablePorCuestionarioGenericoPorIdentificadorTipoUsuario(_idCuestionarioGenerico, _identificadorTipoUsuario))
            {
                _lista.Add(new AsignarUsuarioTipoUsuario()
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
                    }
                });
            }
            return _lista;
        }

        public List<AsignarUsuarioTipoUsuario> ConsultarAsignarUsuarioTipoUsuarioPorIdentificadorTipoUsuario(int _identificadorTipoUsuario)
        {
            List<AsignarUsuarioTipoUsuario> listaAsignarUsuarioTipoUsuario = new List<AsignarUsuarioTipoUsuario>();
            foreach (var item in db.Sp_AsignarUsuarioTipoUsuarioConsultarPorIdentificadorTipoUsuario(_identificadorTipoUsuario))
            {
                listaAsignarUsuarioTipoUsuario.Add(new AsignarUsuarioTipoUsuario()
                {
                    IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                    IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                    Usuario = new Usuario()
                    {
                        IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                        IdUsuario = item.USUARIO_IdUsuario,
                        Correo = item.USUARIO_Correo,
                        //Clave = item.USUARIO_Clave,
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
                    }
                });
            }
            return listaAsignarUsuarioTipoUsuario;
        }
    }
}