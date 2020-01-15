using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarUsuarioTipoUsuario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        public List<AsignarUsuarioTipoUsuario> ConsultarAsignarUsuarioTipoUsuario()
        {
            List<AsignarUsuarioTipoUsuario> listaAsignarUsuarioTipoUsuario = new List<AsignarUsuarioTipoUsuario>();
            foreach (var item in db.Sp_UsuarioConsultar())
            {
                listaAsignarUsuarioTipoUsuario.Add(new AsignarUsuarioTipoUsuario()
                {
                    IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                    Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                    Usuario = new Usuario()
                    {
                        IdUsuario = item.USUARIO_IdUsuario,
                        Correo = item.USUARIO_Correo,
                        Clave = item.USUARIO_Clave,
                        Estado = item.USUARIO_Estado,
                        Persona = new Persona()
                        {
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
                                IdSexo = item.SEXO_IdSexo,
                                Identificador = item.SEXO_Identificador,
                                Descripcion = item.SEXO_Descripcion,
                                Estado = item.SEXO_Estado,
                            },
                            TipoIdentificacion = new TipoIdentificacion()
                            {
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