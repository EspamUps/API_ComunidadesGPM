using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using API.Conexion;
using API.Models.Entidades;
using API.Models.Catalogos;
using API.Models.Metodos;



namespace API.Controllers
{
    public class UsuarioController : ApiController
    {
        //ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        // GET: api/Usuario
        CatalogoPersona _objCatalogoPersona = new CatalogoPersona();
        CatalogoUsuario _objCatalogoUsuarios = new CatalogoUsuario();
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarUsuarioTipoUsuario _objCatalogoAsignarUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();

        CatalogoTokens catTokens = new CatalogoTokens();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/usuario_insertar")]
        public object usuario_insertar(Usuario _objUsuario)
        {
           
            /*
               1	INSERTAR
               2	MODIFICAR
               3	ELIMINAR
               4	CONSULTAR
            */
           
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();

            // valida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 1
            try
            {
                // Token _token = catTokens.Consultar().Where(x => x.Identificador == 1).FirstOrDefault();
                // string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if(string.IsNullOrEmpty(_objUsuario.Persona.IdPersonaEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                }
                else if(string.IsNullOrEmpty(_objUsuario.Correo.Trim()) || string.IsNullOrEmpty(_objUsuario.Clave.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                }
                else if(_objCatalogoUsuarios.ValidarCorreo(_objUsuario).Count > 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                    _http.mensaje = "El correo electrónico ha sido utilizado por otro usuario.";
                }
                else
                {
                    int _idPersona = Convert.ToInt32(_seguridad.DesEncriptar(_objUsuario.Persona.IdPersonaEncriptado));
                    var _objPersona = _objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersona && c.Estado == true).FirstOrDefault();
                    bool _validarPersona = true;
                    if(_objPersona == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _validarPersona = false;
                    }
                    if(_validarPersona == true)
                    {
                        _objUsuario.Estado = true;
                        int _idUsuarioIngresado = _objCatalogoUsuarios.InsertarUsuario(_objUsuario);
                        if(_idUsuarioIngresado == 0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Ocurrió un error al intentar ingresar al usuario, intente nuevamente.";
                        }
                        else
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                            _respuesta = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.Usuario.IdUsuario == _idUsuarioIngresado && c.Estado == true).FirstOrDefault();
                        }
                    }
                   
                }
            }
            catch (Exception)
            {
                return new
                {
                   respuesta = _respuesta, http = _http
                };
            }
            return new
            {
                respuesta = _respuesta, http = _http
            };
        }

        [HttpPost]
        [Route("api/usuario_modificar")]
        public object usuario_modificar(Usuario _objUsuario) {

           
            object respuesta = new object();


            try
            {
                // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 2
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 2).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {
                    respuesta = _objCatalogoUsuarios.ModificarUsuario(_objUsuario);
                    if ((int)respuesta != 0)
                    {
                        respuesta = _objUsuario;
                        return new
                        {
                            respuesta,
                            http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }

                    return new
                    {
                        respuesta,
                        http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                    };


                }
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }
            

            

        }

        [HttpPost]
        [Route("api/usuario_eliminar")]
        public object usuario_eliminar(Usuario _objUsuario)
        {

           
            object respuesta = new object();

            try
            {
                // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 3
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 3).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {
                    respuesta = _objCatalogoUsuarios.EliminarUsuario(_objUsuario);
                    if ((int)respuesta != 0)
                    {
                        respuesta = _objUsuario;
                        return new
                        {
                            respuesta,
                            http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }
                    else
                    {
                        return new
                        {
                            respuesta,
                            http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                        };
                    }

                }
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }

        }

        [HttpPost]
        [Route("api/usuario_consultar")]
        public object usuario_consultar(Usuario _objUsuario)
        {
           
            object respuesta = new object();

            try
            {
                // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {
                    respuesta = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
                    if (respuesta != null)
                    {
                        return new
                        {
                            respuesta,
                            http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }
                    return new
                    {
                        respuesta,
                        http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                    };

                }
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }
            

        }


        [HttpPost]
        [Route("api/ValidarCorreo")]
        public object ValidarCorreo(Usuario _objUsuario)
        {
            //string hola = "hola";
            //object respuesta = new { hola };
           
            object respuesta = new object();
           
            

            try
            {
                // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {

                    Usuario validar = _objCatalogoUsuarios.ValidarCorreo(_objUsuario).FirstOrDefault();
                    if (validar.Correo != null)
                    {
                        respuesta = validar.Correo;
                        return new
                        {
                            respuesta,
                            http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }
                    return new
                    {
                        respuesta,
                        http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                    };

                }
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };

            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }

            //return new { id = 1234 };
        }

        [HttpPost]
        [Route("api/Login")]
        public object Login(Usuario _objUsuario)
        {

           
            object respuesta = new object();

            try
            {
                // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {
                    //AsignarUsuarioTipoUsuario validar = catAsignarUsuarioTipoUsuario.ConsultarUsuarios().Where(x => x.Usuario.Correo == _item.Correo).FirstOrDefault(); //&& catUsuarios.DesenciptarClaveUsuario(x.Usuario.Clave) ==_item.Clave
                    //return _item;
                    //return catUsuarios.ValidarCorreo(_item);
                    Usuario validar = _objCatalogoUsuarios.ValidarCorreo(_objUsuario).FirstOrDefault();

                    if (validar.Correo != null)
                    {
                        string desencriptar_clave_usuario = _objCatalogoUsuarios.DesenciptarClaveUsuario(validar.Clave);
                        if (_objUsuario.Clave == desencriptar_clave_usuario)
                        {
                             respuesta = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(x => x.Usuario.IdUsuario == validar.IdUsuario);
                            if (respuesta !=null)
                            {
                                return new
                                {
                                    respuesta,
                                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                                };
                            }
                            return new
                            {
                                respuesta,
                                http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                            };

                        }
                        return new
                        {
                            respuesta,
                            http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "002").FirstOrDefault()
                        };
                    }
                    return new
                    {
                        respuesta,
                        http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "002").FirstOrDefault()
                    };

                }
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }

        }



    }
}
