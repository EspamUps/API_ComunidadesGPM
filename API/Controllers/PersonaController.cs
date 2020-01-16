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
        CatalogoPersona _objCatalogoPersona = new CatalogoPersona();
        CatalogoSexo _objCatalogoSexo = new CatalogoSexo();
        CatalogoTipoIdentificacion _objCatalogoTipoIdentificacion = new CatalogoTipoIdentificacion();

        Seguridad _seguridad = new Seguridad();

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

                if (string.IsNullOrEmpty(_objPersona.Sexo.IdSexoEncriptado.Trim()) && string.IsNullOrEmpty(_objPersona.TipoIdentificacion.IdTipoIdentificacionEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                }
                //else if (string.IsNullOrEmpty(_objPersona.Correo.Trim())) //|| string.IsNullOrEmpty(_objPersona.Clave.Trim())
                //{
                //    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                //}
                else if (_objCatalogoPersona.ConsultarPersona().Where(x => x.NumeroIdentificacion == _objPersona.NumeroIdentificacion).ToList().Count > 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                    _http.mensaje = "El número de Identificacion ya ha sido utilizado por otra persona.";
                }
                else
                {

                    int _idSexoDesencriptado = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.Sexo.IdSexoEncriptado));
                    int _idTipoIdentificacionDesencriptado = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.TipoIdentificacion.IdTipoIdentificacionEncriptado));

                    var _objSexo = _objCatalogoSexo.ConsultarSexos().Where(c => c.IdSexo == _idSexoDesencriptado && c.Estado == true).FirstOrDefault();
                    var _objTipoIdentificacion = _objCatalogoTipoIdentificacion.ConsultarTipoIdentificacion().Where(c => c.IdTipoIdentificacion == _idTipoIdentificacionDesencriptado && c.Estado == true).FirstOrDefault();

                    bool _validarPersona = true;
                    if (_objPersona == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _validarPersona = false;
                    }
                    if (_validarPersona == true)
                    {
                        _objPersona.Estado = true;
                        _objPersona.Sexo.IdSexo = _idSexoDesencriptado;
                        _objPersona.TipoIdentificacion.IdTipoIdentificacion = _idTipoIdentificacionDesencriptado;
                        

                        int _idPersonaIngresado = _objCatalogoPersona.InsertarPersona(_objPersona);
                        if (_idPersonaIngresado == 0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Ocurrió un error al intentar ingresar al usuario, intente nuevamente.";
                        }
                        else
                        {
                            _respuesta = _objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersonaIngresado && c.Estado == true).FirstOrDefault();
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                        }
                    }

                }
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
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();

            try
            {
                var listaPersona = _objCatalogoPersona.ConsultarPersona().Where(x => x.Estado == true).ToList();
                foreach (var item in listaPersona)
                {
                    item.IdPersona                                  = 0;
                    item.Sexo.IdSexo                                = 0;
                    item.TipoIdentificacion.IdTipoIdentificacion    = 0;
                }
                _respuesta = listaPersona;
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
        
    }
}
