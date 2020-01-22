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
            try
            {
                if (string.IsNullOrEmpty(_objPersona.PrimerNombre.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el primer nombre de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.PrimerApellido.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el primer apellido de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.SegundoApellido.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el segundo apellido de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.NumeroIdentificacion.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el número de identificación de la persona.";
                }
                if (string.IsNullOrEmpty(_objPersona.Sexo.IdSexoEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Seleccione el sexo de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.TipoIdentificacion.IdTipoIdentificacionEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Seleccione el tipo de identificación de la persona.";
                }
                else if (_objCatalogoPersona.ConsultarPersona().Where(x => x.NumeroIdentificacion == _objPersona.NumeroIdentificacion).ToList().Count > 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                    _http.mensaje = "El número de Identificacion ya ha sido utilizado por otra persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.Telefono.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el teléfono de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.Direccion.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la dirección de la persona.";
                }
                else
                {

                    int _idSexoDesencriptado                = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.Sexo.IdSexoEncriptado));
                    int _idTipoIdentificacionDesencriptado  = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.TipoIdentificacion.IdTipoIdentificacionEncriptado));
                    int _idParroquiaDesencriptado           = Convert.ToInt32(_objPersona.Parroquia.IdParroquiaEncriptado); // aun no existe esta tabla por eso paso un valor string y lo convierto;

                    var _objSexo = _objCatalogoSexo.ConsultarSexos().Where(c => c.IdSexo == _idSexoDesencriptado && c.Estado == true).FirstOrDefault();
                    var _objTipoIdentificacion = _objCatalogoTipoIdentificacion.ConsultarTipoIdentificacion().Where(c => c.IdTipoIdentificacion == _idTipoIdentificacionDesencriptado && c.Estado == true).FirstOrDefault();

                    _objPersona.Estado = true;
                    _objPersona.Sexo.IdSexo = _idSexoDesencriptado;
                    _objPersona.TipoIdentificacion.IdTipoIdentificacion = _idTipoIdentificacionDesencriptado;

                    int _idPersonaIngresado = _objCatalogoPersona.InsertarPersona(_objPersona);
                    if (_idPersonaIngresado == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al intentar ingresar a la persona, intente nuevamente.";
                    }
                    else
                    {
                        var _personaIngresada = _objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersonaIngresado && c.Estado == true).FirstOrDefault();
                        _personaIngresada.IdPersona = 0;
                        _personaIngresada.Sexo.IdSexo = 0;
                        _personaIngresada.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _respuesta = _personaIngresada;
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
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
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                int _idPersona = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.IdPersonaEncriptado));
                if (_objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersona).FirstOrDefault() == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "La persona que intenta modificar no es válida.";
                }
                else if (string.IsNullOrEmpty(_objPersona.PrimerNombre.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el primer nombre de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.PrimerApellido.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el primer apellido de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.SegundoApellido.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el segundo apellido de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.NumeroIdentificacion.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el número de identificación de la persona.";
                }
                if (string.IsNullOrEmpty(_objPersona.Sexo.IdSexoEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Seleccione el sexo de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.TipoIdentificacion.IdTipoIdentificacionEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Seleccione el tipo de identificación de la persona.";
                }
                else if (_objCatalogoPersona.ConsultarPersona().Where(x => x.NumeroIdentificacion == _objPersona.NumeroIdentificacion && x.IdPersona != _idPersona).ToList().Count > 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                    _http.mensaje = "El número de identificación ya ha sido utilizado por otra persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.Telefono.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el teléfono de la persona.";
                }
                else if (string.IsNullOrEmpty(_objPersona.Direccion.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la dirección de la persona.";
                }
                else
                {
                    int _idSexoDesencriptado = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.Sexo.IdSexoEncriptado));
                    int _idTipoIdentificacionDesencriptado = Convert.ToInt32(_seguridad.DesEncriptar(_objPersona.TipoIdentificacion.IdTipoIdentificacionEncriptado));
                    int _idParroquiaDesencriptado = Convert.ToInt32(_objPersona.Parroquia.IdParroquiaEncriptado); // aun no existe esta tabla por eso paso un valor string y lo convierto;

                    var _objSexo = _objCatalogoSexo.ConsultarSexos().Where(c => c.IdSexo == _idSexoDesencriptado && c.Estado == true).FirstOrDefault();
                    var _objTipoIdentificacion = _objCatalogoTipoIdentificacion.ConsultarTipoIdentificacion().Where(c => c.IdTipoIdentificacion == _idTipoIdentificacionDesencriptado && c.Estado == true).FirstOrDefault();

                    _objPersona.Estado = true;
                    _objPersona.Sexo.IdSexo = _idSexoDesencriptado;
                    _objPersona.TipoIdentificacion.IdTipoIdentificacion = _idTipoIdentificacionDesencriptado;
                    _objPersona.IdPersona = _idParroquiaDesencriptado;

                    int _idPersonaModificada = _objCatalogoPersona.ModificarPersona(_objPersona);
                    if (_idPersonaModificada == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al intentar modificar a la persona, intente nuevamente.";
                    }
                    else
                    {
                        var _objPersonaModificada = _objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersona).FirstOrDefault();
                        _objPersonaModificada.IdPersona = 0;
                        _objPersonaModificada.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objPersonaModificada.Sexo.IdSexo = 0;
                        _respuesta = _objPersonaModificada;
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                    }

                }
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new { respuesta = _respuesta, http = _http };
            }
            return new { respuesta = _respuesta, http = _http};
        }
        [HttpPost]
        [Route("api/persona_eliminar")]
        public object persona_eliminar(string _idPersonaEncriptado)
        {
            CatalogoAsignarUsuarioTipoUsuario _objCatalogoAsignarUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();

            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrWhiteSpace(_idPersonaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la persona que intenta eliminar.";
                }
                else
                {
                    int _idPersona = Convert.ToInt32(_seguridad.DesEncriptar(_idPersonaEncriptado));
                    var _objPersona = _objCatalogoPersona.ConsultarPersona().Where(c => c.IdPersona == _idPersona).FirstOrDefault();

                    if (_objPersona == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró a la persona que intenta eliminar.";
                    }
                    else if (_objPersona.Utilizado == "1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "La persona ya tiene un usuario asignado, no se puede eliminar.";
                    }
                    else
                    {
                        _objCatalogoPersona.EliminarPersona(_idPersona);
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new { respuesta = _respuesta, http = _http };
            }
            return new { respuesta = _respuesta, http = _http };
        }

        // GET: api/Persona
        [HttpPost]
        [Route("api/persona_consultar")]
        public object persona_consultar()
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
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
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
