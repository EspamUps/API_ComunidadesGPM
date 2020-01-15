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
                _respuesta = _objCatalogoAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario().Where(c => c.Estado == true).ToList();
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
    }
}
