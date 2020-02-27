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
    public class AsignarEncuestadoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarEncuestado _objCatalogoAsignarEncuestado = new CatalogoAsignarEncuestado();
        Seguridad _seguridad = new Seguridad();
        [HttpPost]
        [Route("api/asignarencuestado_insertar")]
        public object asignarencuestado_insertar(AsignarEncuestado _objAsignarEncuestado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objAsignarEncuestado == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto asignar encuestado";
                }
                else if (_objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado == null || string.IsNullOrEmpty(_objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del asignar usuario tipo usuario.";
                }
                else if (_objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuarioEncriptado == null || string.IsNullOrEmpty(_objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del asignar usuario técnico.";
                }
                else if (_objAsignarEncuestado.Comunidad.IdComunidadEncriptado == null || string.IsNullOrEmpty(_objAsignarEncuestado.Comunidad.IdComunidadEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la comunidad.";
                }
                else if (_objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicadoEncriptado == null || string.IsNullOrEmpty(_objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del cuestionario publicado.";
                }
                else if (_objAsignarEncuestado.FechaInicio == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la fecha de inicio.";
                }
                else if (_objAsignarEncuestado.FechaFin == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la fecha de finalización.";
                }
                else if (DateTime.Compare(Convert.ToDateTime(_objAsignarEncuestado.FechaInicio), Convert.ToDateTime(_objAsignarEncuestado.FechaFin)) >= 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "La fecha de inicio debe ser menor a la fecha fin.";
                }
                else
                {
                    _objAsignarEncuestado.Estado = true;
                    _objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado));
                    _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuarioEncriptado));
                    _objAsignarEncuestado.Comunidad.IdComunidad = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarEncuestado.Comunidad.IdComunidadEncriptado));
                    _objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = Convert.ToInt32(_seguridad.DesEncriptar(_objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicadoEncriptado));
                    int _idAsignarEncuestado = _objCatalogoAsignarEncuestado.InsertarAsignarEncuestado(_objAsignarEncuestado);
                    if (_idAsignarEncuestado == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar al encuestado";
                    }
                    else
                    {
                        _objAsignarEncuestado = _objCatalogoAsignarEncuestado.ConsultarAsignarEncuestadoPorId(_idAsignarEncuestado).Where(c=>c.Estado==true).FirstOrDefault();
                        _objAsignarEncuestado.IdAsignarEncuestado = 0;

                        _objAsignarEncuestado.Comunidad.IdComunidad = 0;
                        _objAsignarEncuestado.Comunidad.Parroquia.IdParroquia = 0;
                        _objAsignarEncuestado.Comunidad.Parroquia.Canton.IdCanton = 0;
                        _objAsignarEncuestado.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;

                        _objAsignarEncuestado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                        _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.IdAsignarUsuarioTipoUsuario = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.IdUsuario = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.TipoUsuario.IdTipoUsuario = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.IdPersona = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.Sexo.IdSexo = 0;
                        _objAsignarEncuestado.AsignarUsuarioTipoUsuarioTecnico.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                        _objAsignarEncuestado.CuestionarioPublicado.IdCuestionarioPublicado = 0;

                        _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;

                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                         _objAsignarEncuestado.CuestionarioPublicado.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                        _objAsignarEncuestado.CuestionarioPublicado.Periodo.IdPeriodo = 0;

                        _objAsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                        _objAsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                        _objAsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                        _objAsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                        _objAsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                        _objAsignarEncuestado.CuestionarioPublicado.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;

                        _respuesta = _objAsignarEncuestado;
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
