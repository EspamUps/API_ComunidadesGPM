using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using API.Conexion;
using API.Models.Entidades;
using API.Models.Catalogos;
using API.Models;

namespace API.Controllers
{
    public class UsuarioController : ApiController
    {
        //ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        // GET: api/Usuario
        CatalogoUsuarios catUsuarios = new CatalogoUsuarios();
        CatalogoTokens catTokens = new CatalogoTokens();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/ValidarCorreo")]
        public object ValidarCorreo(Usuario _item) {
            //string hola = "hola";
            //object respuesta = new { hola };
            object objeto       = new object();
            object respuesta    = new object();
            object mensaje      = new object();
            object codigo       = new object();

            try
            {
                // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
                Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
                string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

                if (_clave_desencriptada == _token.Descripcion) {

                    Usuario validar = catUsuarios.ConsultarIndividual().Where(x => x.Correo == _item.Correo).FirstOrDefault();
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
                    return new { respuesta, mensaje = "Bad Request", codigo = "400" };
                }

            }
            catch (Exception)
            {

                return new { respuesta, mensaje= "No Content", codigo= "204" };
            }
            
            //return new { id = 1234 };
        }

        [HttpPost]
        [Route("api/Login")]
        public object Login(Usuario _item) {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            // calida el token de la peticion, este es una ruta para consultar asi que el identificador del token debe ser 4
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catUsuarios.Consultar().Where(x => x.Correo == _item.Correo).FirstOrDefault();
                return new { respuesta , mensaje = "OK", codigo = "200" };
            }

            return new { respuesta, mensaje = "Forbidden", codigo = "404" };
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
                respuesta = catUsuarios.Consultar();
                return new { respuesta, mensaje = "OK", codigo = "200" };
            }

            return new { respuesta, mensaje = "Forbidden", codigo = "403" };

        }

        [HttpPost]
        [Route("api/usuario_insertar")]
        public object usuario_insertar(Usuario _item)
        {
            /*
               1	INSERTAR
               2	MODIFICAR
               3	ELIMINAR
               4	CONSULTAR
            */
            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();
            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 1
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 1).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catUsuarios.Ingresar(_item);
                if ((int)respuesta !=0)
                {
                    return new { respuesta, mensaje = "OK", codigo = "200" };
                }
                else
                {
                    return new { respuesta, mensaje = "Bad Request", codigo = "400" };
                }
            }
            
            return new { respuesta, mensaje = "Forbidden", codigo = "403" };
           

            //return new { respuesta, mensaje = "Bad Request", codigo = "400" };

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
                respuesta = catUsuarios.Modificar(_item);
                if ((int)respuesta != 0)
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
                respuesta = catUsuarios.Eliminar(_item);
                if ((int)respuesta != 0)
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

    }
}
