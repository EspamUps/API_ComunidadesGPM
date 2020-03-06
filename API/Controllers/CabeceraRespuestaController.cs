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
    public class CabeceraRespuestaController : ApiController
    {
        Seguridad _seguridad = new Seguridad();
        CatalogoCabeceraRespuesta _objCatalogoCabeceraRespuesta = new CatalogoCabeceraRespuesta();
        CatalogoAsignarEncuestado _objCatalogoAsignarEncuestado = new CatalogoAsignarEncuestado();
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();

        [HttpPost]
        [Route("api/cabecerarespuesta_insertar")]
        public object cabecerarespuesta_insertar(CabeceraRespuesta _objCabeceraRespuesta)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if(_objCabeceraRespuesta==null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto cabecera respuesta";
                }
                else if(_objCabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestadoEncriptado==null || string.IsNullOrEmpty(_objCabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del asignar encuestado";
                }
                else
                {
                    int _idAsignarEncuestado = Convert.ToInt32(_seguridad.DesEncriptar(_objCabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestadoEncriptado));
                    var _objAsignarEncuestado = _objCatalogoAsignarEncuestado.ConsultarAsignarEncuestadoPorId(_idAsignarEncuestado).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objAsignarEncuestado == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el objeto asignar encuestado";
                    }
                    else
                    {
                        _objCabeceraRespuesta.FechaRegistro = DateTime.Now;
                        _objCabeceraRespuesta.Estado = true;
                        _objCabeceraRespuesta.FechaFinalizado = null;
                        _objCabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestado = _idAsignarEncuestado;
                        int _idCabeceraRespuesta = _objCatalogoCabeceraRespuesta.InsertarCabeceraRespuesta(_objCabeceraRespuesta);
                        if(_idCabeceraRespuesta==0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Ocurrió un error al tratar de ingresar la cabecera respuesta";
                        }
                        else
                        {
                            _objCabeceraRespuesta = _objCatalogoCabeceraRespuesta.ConsultarCabeceraRespuestaPorId(_idCabeceraRespuesta).FirstOrDefault();
                            _objCabeceraRespuesta.IdCabeceraRespuesta = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.IdComunidad = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.IdParroquia = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.IdCanton = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.Periodo.IdPeriodo = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.IdComunidad = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.IdParroquia = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.IdCanton = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.Periodo.IdPeriodo = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _respuesta = _objCabeceraRespuesta;
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                        }
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
        [Route("api/cabecerarespuesta_consultarporidasignarencuestado")]
        public object cabecerarespuesta_consultarporidasignarencuestado(string _idAsignarEncuestadoEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idAsignarEncuestadoEncriptado == null || string.IsNullOrEmpty(_idAsignarEncuestadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del asignar encuestado";
                }
                else
                {
                    int _idAsignarEncuestado = Convert.ToInt32(_seguridad.DesEncriptar(_idAsignarEncuestadoEncriptado));
                    var _objAsignarEncuestado = _objCatalogoAsignarEncuestado.ConsultarAsignarEncuestadoPorId(_idAsignarEncuestado).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objAsignarEncuestado == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el objeto asignar encuestado";
                    }
                    else
                    {
                        var _objCabeceraRespuesta = _objCatalogoCabeceraRespuesta.ConsultarCabeceraRespuestaPorIdAsignarEncuestado(_idAsignarEncuestado).FirstOrDefault();
                            _objCabeceraRespuesta.IdCabeceraRespuesta = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.IdComunidad = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.IdParroquia = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.IdCanton = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.Periodo.IdPeriodo = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.IdComunidad = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.IdParroquia = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.IdCanton = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.Periodo.IdPeriodo = 0;

                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objCabeceraRespuesta.AsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                            _respuesta = _objCabeceraRespuesta;
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
    }
}
