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
    public class CabeceraVersionCuestionarioController : ApiController
    {
        Seguridad _seguridad = new Seguridad();
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarResponsable _objCatalogoAsignarResponsable = new CatalogoAsignarResponsable();
        CatalogoCabeceraVersionCuestionario _objCatalogoCabeceraVersionCuestionario = new CatalogoCabeceraVersionCuestionario();
        CatalogoVersionamientoPregunta _objCatalogoVersionamientoPregunta = new CatalogoVersionamientoPregunta();
        CatalogoPregunta _objCatalogoPregunta = new CatalogoPregunta();

        [HttpPost]
        [Route("api/cabeceraversioncuestionario_insertar")]
        public object cabeceraversioncuestionario_insertar(CabeceraVersionCuestionario _objCabeceraVersionCuestionario)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objCabeceraVersionCuestionario == null)
                {
                    _http.mensaje = "Ingrese el objeto cabecera versión cuestionario";
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                }
                else if (_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsableEncriptado == null || string.IsNullOrEmpty(_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsableEncriptado))
                {
                    _http.mensaje = "Ingrese el identificador del asignar responsable";
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                }
                else if (string.IsNullOrEmpty(_objCabeceraVersionCuestionario.Caracteristica))
                {
                    _http.mensaje = "Ingrese la característica";
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                }
                else if (_objCabeceraVersionCuestionario.Version == 0)
                {
                    _http.mensaje = "Ingrese la versión";
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                }
                else
                {
                    _objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = Convert.ToInt32(_seguridad.DesEncriptar(_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsableEncriptado));
                    var _objAsignarResponsable = _objCatalogoAsignarResponsable.ConsultarAsignarResponsablePorId(_objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objAsignarResponsable == null)
                    {
                        _http.mensaje = "No se encontró el objeto asignar responsable";
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                    }
                    else
                    {
                        var _listadoPreguntas = _objCatalogoPregunta.ConsultarPreguntaPorIdCuestionarioGenerico(_objAsignarResponsable.CuestionarioGenerico.IdCuestionarioGenerico).Where(c => c.Estado == true && c.Seccion.Estado == true && c.Seccion.Componente.Estado == true).ToList();
                        if (_listadoPreguntas.Count == 0)
                        {
                            _http.mensaje = "No se han ingresado preguntas en este cuestionario";
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        }
                        else
                        {
                            _objCabeceraVersionCuestionario.Estado = true;
                            _objCabeceraVersionCuestionario.FechaCreacion = DateTime.Now;
                            int _idCabeceraVersionCuestionario = _objCatalogoCabeceraVersionCuestionario.InsertarCabeceraVersionCuestionario(_objCabeceraVersionCuestionario);
                            if (_idCabeceraVersionCuestionario == 0)
                            {
                                _http.mensaje = "Ocurrió un error al tratar de ingresar la cabecera versión cuestionario";
                                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            }
                            else
                            {
                                _objCabeceraVersionCuestionario.IdCabeceraVersionCuestionario = _idCabeceraVersionCuestionario;
                                foreach (var item in _listadoPreguntas)
                                {
                                   int _idVersionamientoPregunta =  _objCatalogoVersionamientoPregunta.InsertarVersionamientoPregunta(new VersionamientoPregunta() { Estado = true, Pregunta = item, CabeceraVersionCuestionario = _objCabeceraVersionCuestionario });
                                }
                                _objCabeceraVersionCuestionario = _objCatalogoCabeceraVersionCuestionario.ConsultarCabeceraVersionCuestionarioPorId(_idCabeceraVersionCuestionario).Where(c => c.Estado == true).FirstOrDefault();
                                _objCabeceraVersionCuestionario.IdCabeceraVersionCuestionario = 0;
                                _objCabeceraVersionCuestionario.AsignarResponsable.IdAsignarResponsable = 0;
                                _respuesta = _objCabeceraVersionCuestionario;
                               _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                            }
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
    }
}