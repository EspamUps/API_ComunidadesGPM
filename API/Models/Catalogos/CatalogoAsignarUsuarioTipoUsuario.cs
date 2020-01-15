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
            foreach (var item in db.Sp_UsuarioConsultar())
            {
                listaAsignarUsuarioTipoUsuario.Add(new AsignarUsuarioTipoUsuario()
                {
                    IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                    Usuario = new Usuario()
                    {
                        IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                        Correo = item.USUARIO_Correo,
                        //Clave = item.USUARIO_Clave,
                        ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                        Estado = item.USUARIO_Estado,
                        Persona = new Persona()
                        {
                            IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
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
                                Identificador = item.SEXO_Identificador,
                                Descripcion = item.SEXO_Descripcion,
                                Estado = item.SEXO_Estado,
                            },
                            TipoIdentificacion = new TipoIdentificacion()
                            {
                                IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                Identificador = item.TIPOIDENTIFICACION_Identificador,
                                Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                Estado = item.TIPOIDENTIFICACION_Estado,
                            }

                        }
                    },
                    TipoUsuario = new TipoUsuario()
                    {
                        IdTipoUsuarioEncriptado = _seguridad.Encriptar( item.TIPOUSUARIO_IdTipoUsuario.ToString()),
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