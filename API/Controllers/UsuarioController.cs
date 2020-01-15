using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using API.Conexion;
using API.Models.Entidades;
using API.Models.Catalogos;


namespace API.Controllers
{
    public class UsuarioController : ApiController
    {
        //ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        // GET: api/Usuario
        CatalogoUsuario catUsuarios = new CatalogoUsuario();
        CatalogoRespuestasHTTP catRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarUsuarioTipoUsuario catAsignarUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();

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
           
            object respuesta = new object();
            RespuestaHTTP _http = catRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault()

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 1
            try
            {
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 1).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {
                    if (catUsuarios.ValidarCorreo(_objUsuario).Clave == null)
                    {
                        respuesta = catUsuarios.InsertarUsuario(_objUsuario);
                        if ((int)respuesta != 0)
                        {
                            respuesta = _objUsuario;
                            return new {
                                respuesta,
                                http = catRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                            };
                        }
                        
                        return new {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                        };
                        
                    }

                }
                return new {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }
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
                    respuesta = catUsuarios.ModificarUsuario(_objUsuario);
                    if ((int)respuesta != 0)
                    {
                        respuesta = _objUsuario;
                        return new
                        {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }

                    return new
                    {
                        respuesta,
                        http = catRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                    };


                }
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
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
                    respuesta = catUsuarios.EliminarUsuario(_objUsuario);
                    if ((int)respuesta != 0)
                    {
                        respuesta = _objUsuario;
                        return new
                        {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }
                    else
                    {
                        return new
                        {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                        };
                    }

                }
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
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
                    respuesta = catAsignarUsuarioTipoUsuario.ConsultarUsuarios();
                    if (respuesta != null)
                    {
                        return new
                        {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }
                    return new
                    {
                        respuesta,
                        http = catRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                    };

                }
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
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

                    Usuario validar = catUsuarios.ValidarCorreo(_objUsuario);
                    if (validar.Correo != null)
                    {
                        respuesta = validar.Correo;
                        return new
                        {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                        };
                    }
                    return new
                    {
                        respuesta,
                        http = catRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                    };

                }
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };

            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
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
                    Usuario validar = catUsuarios.ValidarCorreo(_objUsuario);

                    if (validar.Correo != null)
                    {
                        string desencriptar_clave_usuario = catUsuarios.DesenciptarClaveUsuario(validar.Clave);
                        if (_objUsuario.Clave == desencriptar_clave_usuario)
                        {
                             respuesta = catAsignarUsuarioTipoUsuario.ConsultarUsuarios().Where(x => x.Usuario.IdUsuario == validar.IdUsuario);
                            if (respuesta !=null)
                            {
                                return new
                                {
                                    respuesta,
                                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault()
                                };
                            }
                            return new
                            {
                                respuesta,
                                http = catRespuestasHTTP.consultar().Where(x => x.codigo == "204").FirstOrDefault()
                            };

                        }
                        return new
                        {
                            respuesta,
                            http = catRespuestasHTTP.consultar().Where(x => x.codigo == "002").FirstOrDefault()
                        };
                    }
                    return new
                    {
                        respuesta,
                        http = catRespuestasHTTP.consultar().Where(x => x.codigo == "002").FirstOrDefault()
                    };

                }
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "403").FirstOrDefault()
                };
            }
            catch (Exception)
            {
                return new
                {
                    respuesta,
                    http = catRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault()
                };
            }

        }



    }
}
