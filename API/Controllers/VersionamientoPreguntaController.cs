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
    public class VersionamientoPreguntaController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoVersionamientoPregunta _objCatalogoVersionamientoPregunta = new CatalogoVersionamientoPregunta();
        CatalogoCabeceraVersionCuestionario _objCatalogoCabeceraVersionCuestionario = new CatalogoCabeceraVersionCuestionario();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/versionamientopregunta_consultarporcabeceraversion")]
        public object versionamientopregunta_consultarporcabeceraversion(string _idCabeceraVersionEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idCabeceraVersionEncriptado == null || string.IsNullOrEmpty(_idCabeceraVersionEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la cabecera versión";
                }
                else
                {
                    int _idCabeceraVersion = Convert.ToInt32(_seguridad.DesEncriptar(_idCabeceraVersionEncriptado));
                    var _objCabeceraVersion = _objCatalogoCabeceraVersionCuestionario.ConsultarCabeceraVersionCuestionarioPorId(_idCabeceraVersion).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objCabeceraVersion == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el objeto cabecera versión";
                    }
                    else
                    {
                        var _listaVersionamiento = _objCatalogoVersionamientoPregunta.ConsultarVersionamientoPreguntaCompletoPorIdCabeceraVersion(_idCabeceraVersion).ToList();
                        foreach (var _objVersionamiento in _listaVersionamiento)
                        {
                            _objVersionamiento.IdVersionamientoPregunta = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.IdUsuario = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.TipoUsuario.IdTipoUsuario = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.IdPersona = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.Sexo.IdSexo = 0;
                            _objVersionamiento.CabeceraVersionCuestionario.AsignarResponsable.AsignarUsuarioTipoUsuario.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                            _objVersionamiento.Pregunta.IdPregunta = 0;
                            _objVersionamiento.Pregunta.TipoPregunta.IdTipoPregunta = 0;
                            _objVersionamiento.Pregunta.Seccion.IdSeccion = 0;
                            _objVersionamiento.Pregunta.Seccion.Componente.IdComponente = 0;
                        }
                        _respuesta = _listaVersionamiento;
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
