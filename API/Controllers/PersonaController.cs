using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Entidades;
using API.Models.Catalogos;
using API.Models.Metodos;

namespace API.Controllers
{
    public class PersonaController : ApiController
    {

        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();

        [HttpPost]
        [Route("api/persona_insertar")]
        public object persona_insertar(Persona _objPersona)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();

            // valida el token de la peticion, este es una ruta para insertar asi que el identificador del token debe ser 1
            try
            {
                // Token _token = catTokens.Consultar().Where(x => x.Identificador == 1).FirstOrDefault();
                // string _clave_desencriptada = _seguridad.DecryptStringAES(_objPersona.Token, _token.objClave.Descripcion);

                //if (string.IsNullOrEmpty(_objPersona.Persona.IdPersonaEncriptado.Trim()))
                //{
                //    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                //}
                //else if (string.IsNullOrEmpty(_objPersona.Correo.Trim())) //|| string.IsNullOrEmpty(_objPersona.Clave.Trim())
                //{
                //    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                //}
                //else if (_objCatalogoUsuarios.ValidarCorreo(_objPersona).Count > 0)
                //{
                //    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                //    _http.mensaje = "El correo electrónico ha sido utilizado por otro usuario.";
                //}
                //else
                //{
                //    int _idPersona = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.Persona.IdPersonaEncriptado));
                //    var _objPersona = _objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersona && c.Estado == true).FirstOrDefault();
                //    bool _validarPersona = true;
                //    if (_objPersona == null)
                //    {
                //        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                //        _validarPersona = false;
                //    }
                //    if (_validarPersona == true)
                //    {
                //        _objPersona.Estado = true;
                //        int _idUsuarioIngresado = _objCatalogoUsuarios.InsertarUsuario(_objUsuario);
                //        if (_idUsuarioIngresado == 0)
                //        {
                //            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                //            _http.mensaje = "Ocurrió un error al intentar ingresar al usuario, intente nuevamente.";
                //        }
                //        else
                //        {
                //            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                //            _respuesta = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.Usuario.IdUsuario == _idUsuarioIngresado && c.Estado == true).FirstOrDefault();
                //        }
                //    }

                //}
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new
                {
                    respuesta = _respuesta,
                    http = _http
                };
            }
            return new
            {
                respuesta = _respuesta,
                http = _http
            };
        }
        [HttpPost]
        [Route("api/persona_modificar")]
        public object persona_modificar(Persona _objPersona)
        {
            return new object();
        }
        [HttpPost]
        [Route("api/persona_eliminar")]
        public object persona_eliminar(Persona _objPersona)
        {
            return new object();
        }
        // GET: api/Persona
        [HttpPost]
        [Route("api/persona_consultar")]
        public object persona_consultar(Persona _objPersona)
        {
            return new object();
        }
        
    }
}
