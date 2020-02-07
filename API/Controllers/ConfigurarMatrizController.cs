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
    public class ConfigurarMatrizController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoOpcionUnoMatriz _objCatalogoOpcionUnoMatriz = new CatalogoOpcionUnoMatriz();
        CatalogoOpcionDosMatriz _objCatalogoOpcionDosMatriz = new CatalogoOpcionDosMatriz();
        CatalogoConfigurarMatriz _objCatalogoConfigurarMatriz = new CatalogoConfigurarMatriz();
        CatalogoPregunta _objCatalogoPregunta = new CatalogoPregunta();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/configurarmatriz_insertar")]
        public object configurarmatriz_insertar(ConfigurarMatriz _objConfigurarMatriz)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objConfigurarMatriz == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto opción dos matriz";
                }
                else if (_objConfigurarMatriz.OpcionUnoMatriz.Pregunta.IdPreguntaEncriptado == null || string.IsNullOrEmpty(_objConfigurarMatriz.OpcionUnoMatriz.Pregunta.IdPreguntaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la pregunta";
                }
                else if (_objConfigurarMatriz.OpcionDosMatriz.Descripcion == null || string.IsNullOrEmpty(_objConfigurarMatriz.OpcionDosMatriz.Descripcion))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
                    _http.mensaje = "Ingrese la descripción de la opción dos matriz";
                }
                else
                {
                    int _idPregunta = Convert.ToInt32(_seguridad.DesEncriptar(_objConfigurarMatriz.OpcionUnoMatriz.Pregunta.IdPreguntaEncriptado));
                    var _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(_idPregunta).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objPregunta == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró la pregunta en el sistema";
                    }
                    else
                    {
                        _objConfigurarMatriz.OpcionUnoMatriz.Pregunta.IdPregunta = _idPregunta;
                        var _listaOpcionUnoMatrizPorPregunta = _objCatalogoOpcionUnoMatriz.ConsultarOpcionUnoMatrizPorIdPregunta(_idPregunta).Where(c=>c.Estado==true).ToList();
                        if (_listaOpcionUnoMatrizPorPregunta.Count == 0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Debe ingresar primero las opciones uno de la matriz";
                        }
                        else
                        {
                            _objConfigurarMatriz.Estado = true;
                            _objConfigurarMatriz.OpcionDosMatriz.Estado = true;
                            int _idOpcionDosMatriz = _objCatalogoOpcionDosMatriz.InsertarOpcionDosMatriz(_objConfigurarMatriz.OpcionDosMatriz);
                            if (_idOpcionDosMatriz == 0)
                            {
                                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                                _http.mensaje = "Ocurrió un error al tratar de ingresar la opción dos matriz";
                            }
                            else
                            {
                                _objConfigurarMatriz.OpcionDosMatriz.IdOpcionDosMatriz = _idOpcionDosMatriz;
                                foreach (var itemOpcionUno in _listaOpcionUnoMatrizPorPregunta)
                                {
                                    _objConfigurarMatriz.OpcionUnoMatriz.IdOpcionUnoMatriz = itemOpcionUno.IdOpcionUnoMatriz;
                                    int _idConfigurarMatriz = _objCatalogoConfigurarMatriz.InsertarConfigurarMatriz(_objConfigurarMatriz);
                                }
                                var _listaConfigurarMatriz = _objCatalogoConfigurarMatriz.ConsultarConfigurarMatrizPorIdPregunta(_objConfigurarMatriz.OpcionUnoMatriz.Pregunta.IdPregunta).Where(c => c.Estado == true).ToList();

                                foreach (var _objConfMatriz in _listaConfigurarMatriz)
                                {
                                    _objConfMatriz.IdConfigurarMatriz = 0;
                                    _objConfMatriz.OpcionDosMatriz.IdOpcionDosMatriz = 0;
                                    _objConfMatriz.OpcionUnoMatriz.IdOpcionUnoMatriz = 0;
                                    _objConfMatriz.OpcionUnoMatriz.Pregunta.IdPregunta = 0;
                                    _objConfMatriz.OpcionUnoMatriz.Pregunta.TipoPregunta.IdTipoPregunta = 0;
                                    _objConfMatriz.OpcionUnoMatriz.Pregunta.Seccion.IdSeccion = 0;
                                    _objConfMatriz.OpcionUnoMatriz.Pregunta.Seccion.Componente.IdComponente = 0;
                                    _objConfMatriz.OpcionUnoMatriz.Pregunta.Seccion.Componente.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                                }
                               
                                _respuesta = _listaConfigurarMatriz;
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
