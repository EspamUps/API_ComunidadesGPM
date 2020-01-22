using API.Models.Catalogos;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AsignarUsuarioTipoUsuarioController : ApiController
    {

        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarUsuarioTipoUsuario _objCatalogoAsignarUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();
        CatalogoUsuario _objCatalogoUsuario = new CatalogoUsuario();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/asignarusuariotipousuario_consultar")]
        public object asignarusuariotipousuario_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaAsignarUsuarioTipoUsuario = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaAsignarUsuarioTipoUsuario)
                {
                    item.IdAsignarUsuarioTipoUsuario = 0;
                    item.Usuario.Persona.IdPersona = 0;
                    item.Usuario.IdUsuario = 0;
                    item.Usuario.Persona.Sexo.IdSexo = 0;
                    item.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                    item.TipoUsuario.IdTipoUsuario = 0;
                }
                _respuesta = _listaAsignarUsuarioTipoUsuario;
               _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new { respuesta = _respuesta, http = _http };
            }

            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/asignarusuariotipousuario_consultar")]
        public object asignarusuariotipousuario_consultar( string _IdUsuarioEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(_IdUsuarioEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                }
                else
                {
                    int _idUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_IdUsuarioEncriptado));
                    CatalogoUsuario _objCatalogoUsuarios = new CatalogoUsuario();
                    var _objUsuario = _objCatalogoUsuarios.ConsultarUsuario().Where(c => c.IdUsuario == _idUsuario).FirstOrDefault();
                    var lista = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.Estado == true && c.Usuario.IdUsuario == _objUsuario.IdUsuario).ToList();
                    foreach (var item in lista)
                    {
                        item.IdAsignarUsuarioTipoUsuario = 0;
                        item.Usuario.IdUsuario = 0;
                        item.TipoUsuario.IdTipoUsuario = 0;
                        item.Usuario.Persona.IdPersona = 0;
                        item.Usuario.Persona.Sexo.IdSexo = 0;
                        item.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                    }
                    _respuesta = lista;
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
                return new { respuesta = _respuesta, http = _http };
            }
            return new { respuesta = _respuesta, http = _http };
        }
        [HttpPost]
        [Route("api/asignarusuariotipousuario_insertar")]
        public object asignarusuariotipousuario_insertar(AsignarUsuarioTipoUsuario _objAsignarUsuarioTipoUsuario)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "500").FirstOrDefault();
            try
            {
                if(string.IsNullOrEmpty(_objAsignarUsuarioTipoUsuario.Usuario.IdUsuarioEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el id encriptado del usuario";
                }
                else if(string.IsNullOrEmpty(_objAsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuarioEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el id encriptado del tipo de usuario";
                }
                else
                {
                    _objAsignarUsuarioTipoUsuario.Usuario.IdUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarUsuarioTipoUsuario.Usuario.IdUsuarioEncriptado));
                    _objAsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuarioEncriptado));
                    _objAsignarUsuarioTipoUsuario.Estado = true;
                    int _idAsignarUsuarioTipoUsuarioIngresado = _objCatalogoAsignarUsuarioTipoUsuario.InsertarAsignarUsuarioTipoUsuario(_objAsignarUsuarioTipoUsuario);
                    if(_idAsignarUsuarioTipoUsuarioIngresado == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al intentar asignar el usuario con el tipo de usuario seleccionado, intente nuevamente.";
                    }
                    else
                    {
                        var _objAsignarUsuarioTipoUsuarioIngresado = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.IdAsignarUsuarioTipoUsuario == _idAsignarUsuarioTipoUsuarioIngresado).FirstOrDefault();
                        _objAsignarUsuarioTipoUsuarioIngresado.IdAsignarUsuarioTipoUsuario = 0;
                        _objAsignarUsuarioTipoUsuarioIngresado.Usuario.Persona.IdPersona = 0;
                        _objAsignarUsuarioTipoUsuarioIngresado.Usuario.IdUsuario = 0;
                        _objAsignarUsuarioTipoUsuarioIngresado.Usuario.Persona.Sexo.IdSexo = 0;
                        _objAsignarUsuarioTipoUsuarioIngresado.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _respuesta = _objAsignarUsuarioTipoUsuarioIngresado;
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "200").FirstOrDefault();
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

        [HttpPost]
        [Route("api/asignarusuariotipousuario_modificar")]
        public object asignarusuariotipousuario_modificar(AsignarUsuarioTipoUsuario _objAsignarUsuarioTipoUsuario)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(_objAsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el id encriptado del asignar usuario tipo usuario";
                }
                else
                {
                    _objAsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado));
                    int _idAsignarUsuarioTipoUsuarioModificado = _objCatalogoAsignarUsuarioTipoUsuario.CambiarEstadoAsignarUsuarioTipoUsuario(_objAsignarUsuarioTipoUsuario);
                    if (_idAsignarUsuarioTipoUsuarioModificado == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al intentar cambiar el estado del usuario con el tipo de usuario seleccionado, intente nuevamente.";
                    }
                    else
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "200").FirstOrDefault();
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

        [HttpPost]
        [Route("api/asignarusuariotipousuario_eliminar")]
        public object asignarusuariotipousuario_eliminar(string _IdAsignarUsuarioTipoUsuario)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(_objAsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el id encriptado del asignar usuario tipo usuario";
                }
                else
                {
                    _objAsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado));
                    _objAsignarUsuarioTipoUsuario.Estado=false;
                    int _idAsignarUsuarioTipoUsuarioModificado = _objCatalogoAsignarUsuarioTipoUsuario.CambiarEstadoAsignarUsuarioTipoUsuario(_objAsignarUsuarioTipoUsuario);
                    if (_idAsignarUsuarioTipoUsuarioModificado == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al intentar cambiar el estado del usuario con el tipo de usuario seleccionado, intente nuevamente.";
                    }
                    else
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(c => c.codigo == "200").FirstOrDefault();
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

    }
}
