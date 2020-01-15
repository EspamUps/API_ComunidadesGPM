using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Catalogos;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Controllers
{
    public class TipoUsuarioController : ApiController
    {
        CatalogoTipoUsuarios catTipoUsuarios = new CatalogoTipoUsuarios();
        CatalogoTokens catTokens = new CatalogoTokens();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/tipousuario_insertar")]
        public object tipousuario_insertar(TipoUsuario _item) {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            /*
              1	INSERTAR
              2	MODIFICAR
              3	ELIMINAR
              4	CONSULTAR
           */

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 1
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 1).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catTipoUsuarios.Insertar(_item);
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
        [Route("api/tipousuario_modificar")]
        public object tipousuario_modificar(TipoUsuario _item)
        {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            /*
              1	INSERTAR
              2	MODIFICAR
              3	ELIMINAR
              4	CONSULTAR
           */

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 2
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 2).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catTipoUsuarios.Modificar(_item);
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
        [Route("api/tipousuario_eliminar")]
        public object tipousuario_elimanar(TipoUsuario _item)
        {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            /*
              1	INSERTAR
              2	MODIFICAR
              3	ELIMINAR
              4	CONSULTAR
           */

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 3
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 3).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catTipoUsuarios.Eliminar(_item);
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
        [Route("api/tipousuario_consultar")]
        public object tipousuario_consultar(TipoUsuario _item)
        {

            object objeto = new object();
            object respuesta = new object();
            object mensaje = new object();
            object codigo = new object();

            /*
              1	INSERTAR
              2	MODIFICAR
              3	ELIMINAR
              4	CONSULTAR
           */

            // calida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 3
            Token _token = catTokens.Consultar().Where(x => x.Identificador == 4).FirstOrDefault();
            string _clave_desencriptada = _seguridad.DecryptStringAES(_item.Token, _token.objClave.Descripcion);

            if (_clave_desencriptada == _token.Descripcion)
            {
                respuesta = catTipoUsuarios.Consultar();
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

    }
}
