using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
namespace API.Models.Catalogos
{

    public class CatalogoUsuarios
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        List<Usuario> listaUsuarios = new List<Usuario>();
        List<Usuario> listaUsuariosSinRepetir = new List<Usuario>();
        List<Sp_UsuarioConsultar_Result> consulta = new List<Sp_UsuarioConsultar_Result>();

        private void dbConsultar() {
            consulta = new List<Sp_UsuarioConsultar_Result>();

            foreach (var item in db.Sp_UsuarioConsultar())
            {
                consulta.Add(item);
            }

            //foreach (var item in consulta)
            //{
            //    listaUsuariosSinRepetir.Add(new Usuario()
            //    {
            //        IdUsuario = item.USUARIO_IdUsuario,
            //        IdPersona = item.USUARIO_IdPersona,
            //        Correo = item.USUARIO_Correo,
            //        Estado = item.USUARIO_Estado,
            //    });
            //}
            //listaUsuariosSinRepetir.Distinct().ToList();
            //return consulta;
        }
        public List<Usuario> Consultar() {
            dbConsultar();
            foreach (var item in consulta)
            {
                int existemcias = consulta.Where(x => x.USUARIO_IdUsuario == item.USUARIO_IdUsuario).Count();
                try
                {
                    listaUsuarios.Remove(listaUsuarios.Find(x => x.IdUsuario == item.USUARIO_IdUsuario));
                }
                catch (Exception)
                {

                }
                listaUsuarios.Add(new Usuario()

                {
                    IdUsuario = item.USUARIO_IdUsuario,
                    IdPersona = item.USUARIO_IdPersona,
                    Correo = item.USUARIO_Correo,
                    Clave = item.USUARIO_Clave,
                    Estado = item.USUARIO_Estado,

                    objPersona = new Persona()
                    {
                        IdPersona = item.PERSONA_IdPersona,
                        PrimerNombre = item.PERSONA_PrimerNombre,
                        SegundoNombre = item.PERSONA_SegundoNombre,
                        PrimerApellido = item.PERSONA_PrimerApellido,
                        SegundoApellido = item.PERSONA_SegundoApellido,
                        NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                        IdTipoIdentificacion = item.PERSONA_IdTipoIdentificacion,
                        Telefono = item.PERSONA_Telefono,
                        IdSexo = item.PERSONA_IdSexo,
                        IdParroquia = item.PERSONA_IdParroquia,
                        Direccion = item.PERSONA_Direccion,
                        Estado = item.PERSONA_Estado,

                        objSexo = new Sexo()
                        {
                            IdSexo = item.SEXO_IdSexo,
                            Identificador = item.SEXO_Identificador,
                            Descripcion = item.SEXO_Descripcion,
                            Estado = item.SEXO_Estado,
                        },

                        objTipoIdentificacion = new TipoIdentificacion()
                        {
                            IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                            Identificador = item.TIPOIDENTIFICACION_Identificador,
                            Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                            Estado = item.TIPOIDENTIFICACION_Estado,

                        }

                    },

                    List_AsignarUsuarioTipoUsuario = get_AsignarUsuarioTipoUsuario(item.USUARIO_IdUsuario)

                });
                
               
            }
            return listaUsuarios;
        }

        private List<AsignarUsuarioTipoUsuario> get_AsignarUsuarioTipoUsuario(int _idUsuario) {
            List<AsignarUsuarioTipoUsuario> listita = new List<AsignarUsuarioTipoUsuario>();
            foreach (var item in consulta.Where(x=>x.USUARIO_IdUsuario == _idUsuario))
            {
                listita.Add(new AsignarUsuarioTipoUsuario() {
                    IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                    IdUsuario                   = item.ASIGNARUSUARIOTIPOUSUARIO_IdUsuario,
                    IdTipoUsuario               = item.ASIGNARUSUARIOTIPOUSUARIO_IdTipoUsuario,
                    Estado                      = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,

                    objTipoUsuario = new TipoUsuario() {
                        IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                        Identificador = item.TIPOUSUARIO_Identificador,
                        Descripcion = item.TIPOUSUARIO_Descripcion,
                        Estado = item.TIPOUSUARIO_Estado,

                        List_AsignarTipoUsuarioModuloPrivilegio = get_AsignarTipoUsuarioModuloPrivilegio(_idUsuario,item.TIPOUSUARIO_IdTipoUsuario),
                    }

                });
            }
            return listita;
        }

        private List<AsignarTipoUsuarioModuloPrivilegio> get_AsignarTipoUsuarioModuloPrivilegio(int _IdUsuario,int _IdTipoUsuario) {
            List<AsignarTipoUsuarioModuloPrivilegio> listita = new List<AsignarTipoUsuarioModuloPrivilegio>();
            foreach (var item in consulta.Where(x => x.USUARIO_IdUsuario == _IdUsuario && x.TIPOUSUARIO_IdTipoUsuario==_IdTipoUsuario))
            {
                listita.Add(new AsignarTipoUsuarioModuloPrivilegio() {
                    IdAsignarTipoUsuarioModuloPrivilegio    = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_IdAsignarTipoUsuarioModuloPrivilegio,
                    IdTipoUsuario                           = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_IdTipoUsuario,
                    IdAsignarModuloPrivilegio               = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_IdAsignarModuloPrivilegio,
                    Estado                                  = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_Estado,

                    objAsignarModuloPrivilegio    = new AsignarModuloPrivilegio() {
                        IdAsignarModuloPrivilegio   = item.ASIGNARMODULOPRIVILEGIO_IdAsignarModuloPrivilegio,
                        IdModulo                    = item.ASIGNARMODULOPRIVILEGIO_IdModulo,
                        IdPrivilegio                = item.ASIGNARMODULOPRIVILEGIO_IdPrivilegio,
                        Estado                      = item.ASIGNARMODULOPRIVILEGIO_Estado,

                        objModulo           = new Modulo() {
                            IdModulo        = item.MODULO_IdModulo,
                            Identificador   = item.MODULO_Identificador,
                            Descripcion     = item.MODULO_Descripcion,
                            Estado          = item.MODULO_Estado
                        }, 

                        objPrivilegio       = new Privilegio() {
                            IdPrivilegio    = item.PRIVILEGIO_IdPrivilegio,
                            Identificador   = item.PRIVILEGIO_Identificador,
                            Descripcion     = item.PRIVILEGIO_Descripcion,
                            Estado          = item.PRIVILEGIO_Estado
                        }

                    }
                });
            }
            return listita;
        }

        public List<Usuario> ConsultarIndividual() {
            dbConsultar();
            foreach (var item in consulta)
            {
                int existemcias = consulta.Where(x => x.USUARIO_IdUsuario == item.USUARIO_IdUsuario).Count();
                try
                {
                    listaUsuarios.Remove(listaUsuarios.Find(x => x.IdUsuario == item.USUARIO_IdUsuario));
                }
                catch (Exception)
                {

                }
                listaUsuarios.Add(new Usuario()

                {
                    IdUsuario = item.USUARIO_IdUsuario,
                    IdPersona = item.USUARIO_IdPersona,
                    Correo = item.USUARIO_Correo,
                    Estado = item.USUARIO_Estado,

                });


            }
            return listaUsuarios.Distinct().ToList();
        }

        //ingresar Usuario
        public int Ingresar(Usuario _item) {
            try
            {
                return int.Parse( db.Sp_UsuarioInsertar(
                    _item.IdPersona,
                    _item.Correo,
                    _item.Clave,
                    _item.Estado
                ).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {

                return 0;
            }
        }

        //modificar usuario
        public int Modificar(Usuario _item) {
            try
            {
                db.Sp_UsuarioModificar(_item.IdUsuario, _item.IdPersona, _item.Correo, _item.Clave);
                return _item.IdUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
                
        }
        //eliminar usuario
        public int Eliminar(Usuario _item)
        {
            try
            {
                db.Sp_UsuarioCambiarEstado(_item.IdUsuario, _item.Estado);
                return _item.IdUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
        }


    }
}