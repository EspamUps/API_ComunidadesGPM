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
            string mensaje = "Ocurrió un error insperado";
            string codigo = "500";

            // valida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 1
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 1).FirstOrDefault();
            if (_token == null)
            {
               mensaje = "No tiene los permisos adecuados para realizar esta acción";
               codigo = "403";
            }
            string _clave_desencriptada = _seguridad.DecryptStringAES(_objUsuario.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                if (catUsuarios.ValidarCorreo(_objUsuario).Clave == null)
                {
                    respuesta = catUsuarios.InsertarUsuario(_objUsuario);
                    if ((int)respuesta != 0)
                    {
                        respuesta = _objUsuario;
                        return new { respuesta, mensaje = "OK", codigo = "200" };
                    }
                    else
                    {
                        return new { respuesta, mensaje = "Bad Request", codigo = "400" };
                    }
                }
               
            }

            
            return new { respuesta, mensaje = "Forbidden", codigo = "403" };
           
            

        }

        [HttpPost]
        [Route("api/usuario_modificar")]
        public object usuario_modificar(Usuario _item) {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 2
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 2).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catUsuarios.ModificarUsuario(_item);
                if ((int)respuesta != 0)
                {
                    respuesta = _item;
                    return new { respuesta, mensaje = "OK", codigo = "200" };
                }
                else
                {
                    return new { respuesta, mensaje = "Bad Request", codigo = "400" };
                }
                
            }

            return new { respuesta, mensaje = "Forbidden", codigo = "403" };

        }

        [HttpPost]
        [Route("api/usuario_eliminar")]
        public object usuario_eliminar(Usuario _item)
        {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 3
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 3).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catUsuarios.EliminarUsuario(_item);
                if ((int)respuesta != 0)
                {
                    respuesta = _item;
                    return new { respuesta, mensaje = "OK", codigo = "200" };
                }
                else
                {
                    return new { respuesta, mensaje = "Bad Request", codigo = "400" };
                }

            }

            return new { respuesta, mensaje = "Forbidden", codigo = "403" };

        }

        [HttpPost]
        [Route("api/usuario_consultar")]
        public object usuario_consultar(Usuario _item)
        {
            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();
            // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                //respuesta = catUsuarios.Consultar();
                if (respuesta != null)
                {
                    return new { respuesta, mensaje = "OK", codigo = "200" };
                }
                else
                {
                    return new { respuesta, mensaje = "Bad Request", codigo = "400" };
                }
                
            }

            return new { respuesta, mensaje = "Forbidden", codigo = "403" };

        }


        [HttpPost]
        [Route("api/ValidarCorreo")]
        public object ValidarCorreo(Usuario _item)
        {
            //string hola = "hola";
            //object respuesta = new { hola };
            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            try
            {
                // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion)
                {

                    Usuario validar = catUsuarios.ValidarCorreo(_item);
                    if (validar != null)
                    {
                        return new { respuesta = validar.Correo, mensaje = "OK", codigo = "200" };
                    }
                    else
                    {
                        return new { respuesta, mensaje = "No Content", codigo = "204" };
                    }

                }
                else
                {
                    return new { respuesta, mensaje = "Forbidden", codigo = "404" };
                }

            }
            catch (Exception)
            {

                return new { respuesta, mensaje = "No Content", codigo = "204" };
            }

            //return new { id = 1234 };
        }

        [HttpPost]
        [Route("api/Login")]
        public object Login(Usuario _item)
        {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                //AsignarUsuarioTipoUsuario validar = catAsignarUsuarioTipoUsuario.ConsultarUsuarios().Where(x => x.Usuario.Correo == _item.Correo).FirstOrDefault(); //&& catUsuarios.DesenciptarClaveUsuario(x.Usuario.Clave) ==_item.Clave
                //return _item;
                //return catUsuarios.ValidarCorreo(_item);
                Usuario validar = catUsuarios.ValidarCorreo(_item);

                if (validar.Correo != null)
                {
                    string desencriptar_clave_usuario = catUsuarios.DesenciptarClaveUsuario(validar.Clave);
                    if (_item.Clave == desencriptar_clave_usuario)
                    {
                        respuesta =  catAsignarUsuarioTipoUsuario.ConsultarUsuarios().Where(x => x.Usuario.IdUsuario == validar.IdUsuario);
                        return new { respuesta, mensaje = "OK", codigo = "200" };
                    }
                    else
                    {
                        return new { respuesta, mensaje = "clave incorrecta", codigo = "418" };
                    }
                }


            }

            return new { respuesta, mensaje = "Forbidden", codigo = "404" };
        }



    }
}
