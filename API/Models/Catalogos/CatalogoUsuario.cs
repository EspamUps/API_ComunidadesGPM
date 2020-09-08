using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
namespace API.Models.Catalogos
{

    public class CatalogoUsuario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        
        List<Sp_UsuarioConsultar_Result> consulta = new List<Sp_UsuarioConsultar_Result>();
        Seguridad _seguridad = new Seguridad();
        string _llave = "GobiernoProvincialManabi";

     
        public List<Usuario> ValidarCorreo(Usuario _item)
        {
            List<Usuario> _listaUsuario = new List<Usuario>();
            foreach (var item in db.Sp_UsuarioValidar(_item.Correo))
            {
                _listaUsuario.Add(new Usuario()
                {
                    IdUsuario = item.IdUsuario,
                    Persona = new Persona() { IdPersona = item.IdPersona },
                    Correo = item.Correo,
                    Clave = item.Clave,
                    Estado = item.Estado
                });
            }
            return _listaUsuario;                   
        }

        //ingresar Usuario
        public int InsertarUsuario(Usuario _objUsuario) {
            try
            {
                return int.Parse( db.Sp_UsuarioInsertar(
                    _objUsuario.Persona.IdPersona,
                    _objUsuario.Correo,
                    _objUsuario.Clave,
                    _objUsuario.Estado
                ).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //modificar usuario
        public int ModificarUsuario(Usuario _objUsuario) {
            try
            {
                var clave = db.Sp_UsuarioConsultar()
                    .Where(a => a.USUARIO_IdUsuario == _objUsuario.IdUsuario)
                    .FirstOrDefault();
                if (_seguridad.Encriptar(clave.USUARIO_Clave)== _objUsuario.Clave) {
                    _objUsuario.Clave = _seguridad.DesEncriptar(_objUsuario.Clave);
                }
                db.Sp_UsuarioModificar(_objUsuario.IdUsuario, _objUsuario.Persona.IdPersona, _objUsuario.Correo, _objUsuario.Clave, _objUsuario.Estado);
                return _objUsuario.IdUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
                
        }
        //eliminar usuario
        public int EliminarUsuario(int _idUsuario)
        {
            try
            {
                db.Sp_UsuarioEliminar(_idUsuario);
                return _idUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Usuario> ConsultarUsuario() {
            List<Usuario> lista = new List<Usuario>();
            foreach (var item in db.Sp_UsuarioConsultar())
            {
                lista.Add(new Usuario() {
                    IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                    IdUsuario           = item.USUARIO_IdUsuario,
                    Correo              = item.USUARIO_Correo,
                    ClaveEncriptada     = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                    Estado              = item.USUARIO_Estado,
                    Utilizado           = item.USUARIO_Utilizado,
                    Persona = new Persona()
                    {
                        IdPersonaEncriptado     = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                        IdPersona               = item.PERSONA_IdPersona,
                        PrimerNombre            = item.PERSONA_PrimerNombre,
                        SegundoNombre           = item.PERSONA_SegundoNombre,
                        PrimerApellido          = item.PERSONA_PrimerApellido,
                        SegundoApellido         = item.PERSONA_SegundoApellido,
                        NumeroIdentificacion    = item.PERSONA_NumeroIdentificacion,
                        Telefono                = item.PERSONA_Telefono,
                        Direccion               = item.PERSONA_Direccion,
                        Estado                  = item.PERSONA_Estado,
                        Sexo = new Sexo()
                        {
                            IdSexoEncriptado    = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                            IdSexo              = item.SEXO_IdSexo,
                            Identificador       = item.SEXO_Identificador,
                            Descripcion         = item.SEXO_Descripcion,
                            Estado              = item.SEXO_Estado,
                        },
                        TipoIdentificacion = new TipoIdentificacion()
                        {
                            IdTipoIdentificacionEncriptado  = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                            IdTipoIdentificacion            = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                            Identificador                   = item.TIPOIDENTIFICACION_Identificador,
                            Descripcion                     = item.TIPOIDENTIFICACION_Descripcion,
                            Estado                          = item.TIPOIDENTIFICACION_Estado,
                        }

                    }
                });
            }
            return lista;
        }


        public List<Usuario> ConsultarUsuarioPorId(int _idUsuario)
        {
            List<Usuario> lista = new List<Usuario>();
            foreach (var item in db.Sp_UsuarioConsultar().Where(c=>c.USUARIO_IdUsuario==_idUsuario).ToList())
            {
                lista.Add(new Usuario()
                {
                    IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                    IdUsuario = item.USUARIO_IdUsuario,
                    Correo = item.USUARIO_Correo,
                    ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                    Estado = item.USUARIO_Estado,
                    Utilizado = item.USUARIO_Utilizado,
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
                });
            }
            return lista;
        }

        public string DesenciptarClaveUsuario(string _clave)
        {
            string clave = _seguridad.DecryptStringAES(_clave, _llave);
            return clave;
        }
    }
}