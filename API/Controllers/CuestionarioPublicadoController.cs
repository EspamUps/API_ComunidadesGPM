using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Catalogos;
using API.Models.Metodos;
using API.Models.Entidades;
namespace API.Controllers
{
    public class CuestionarioPublicadoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoCuestionarioPublicado _objCatalogoCuestionarioPublicado = new CatalogoCuestionarioPublicado();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/cuestionariopublicado_insertar")]
        public object cuestionariopublicado_insertar(CuestionarioPublicado _objCuestionarioPublicado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objCuestionarioPublicado == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto cuestionario publicado";
                }
                else if (_objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado == null || string.IsNullOrEmpty(_objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del asignar usuario tipo usuario que publica";
                }
                else if (_objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionarioEncriptado == null || string.IsNullOrEmpty(_objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la cabecera de la versión del cuestionario";
                }
                else if (_objCuestionarioPublicado.Periodo.IdPeriodoEncriptado == null || string.IsNullOrEmpty(_objCuestionarioPublicado.Periodo.IdPeriodoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el periodo";
                }
                else
                {
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado));
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = Convert.ToInt32(_seguridad.DesEncriptar(_objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionarioEncriptado));
                    _objCuestionarioPublicado.Periodo.IdPeriodo = Convert.ToInt32(_seguridad.DesEncriptar(_objCuestionarioPublicado.Periodo.IdPeriodoEncriptado));
                    _objCuestionarioPublicado.FechaPublicacion = DateTime.Now;
                    _objCuestionarioPublicado.Estado = true;
                    int _idCuestionarioPublicado = _objCatalogoCuestionarioPublicado.InsertarCuestionarioPublicado(_objCuestionarioPublicado);
                    if(_idCuestionarioPublicado==0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de publicar el cuestionario";
                    }
                    else
                    {
                        _objCuestionarioPublicado = _objCatalogoCuestionarioPublicado.ConsultarCuestionarioPublicadoPorId(_idCuestionarioPublicado).FirstOrDefault();
                        _objCuestionarioPublicado.IdCuestionarioPublicado = 0;
                        _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                        _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                        _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                        _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                        _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                        _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                        _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objCuestionarioPublicado.Periodo.IdPeriodo = 0;
                        _respuesta = _objCuestionarioPublicado;
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/cuestionariopublicado_eliminar")]
        public object cuestionariopublicado_eliminar(string _idCuestionarioPublicadoEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idCuestionarioPublicadoEncriptado == null || string.IsNullOrEmpty(_idCuestionarioPublicadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del cuestionario publicado";
                }
                else
                {
                    int _idCuestionarioPublicado = Convert.ToInt32(_seguridad.DesEncriptar(_idCuestionarioPublicadoEncriptado));
                   var  _objCuestionarioPublicado = _objCatalogoCuestionarioPublicado.ConsultarCuestionarioPublicadoPorId(_idCuestionarioPublicado).FirstOrDefault();
                    if(_objCuestionarioPublicado==null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró la publicación que intenta eliminar";
                    }
                    else if(_objCuestionarioPublicado.Utilizado=="1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "No se puede eliminar la publicación porque ya ha sido utilizada";
                    }
                    else
                    {
                        _objCatalogoCuestionarioPublicado.EliminarCuestionarioPublicado(_idCuestionarioPublicado);
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                    }

                }
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/cuestionariopublicado_consultar")]
        public object cuestionariopublicado_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaCuestionarioPublicado = _objCatalogoCuestionarioPublicado.ConsultarCuestionarioPublicado().Where(c => c.Estado == true).ToList();
                foreach (var _objCuestionarioPublicado in _listaCuestionarioPublicado)
                {
                    _objCuestionarioPublicado.IdCuestionarioPublicado = 0;
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                    _objCuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                    _objCuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                    _objCuestionarioPublicado.Periodo.IdPeriodo = 0;
                }
                _respuesta = _listaCuestionarioPublicado;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }
    }
}
