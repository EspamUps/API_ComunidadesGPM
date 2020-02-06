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
    public class PreguntaController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        Seguridad _seguridad = new Seguridad();
        CatalogoPregunta _objCatalogoPregunta = new CatalogoPregunta();
        CatalogoTipoPregunta _objCatalogoTipoPregunta = new CatalogoTipoPregunta();
        CatalogoSeccion _objCatalogoSeccion = new CatalogoSeccion();
        [HttpPost]
        [Route("api/pregunta_insertar")]
        public object pregunta_insertar(Pregunta _objPregunta)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objPregunta == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto pregunta";
                }
                else if (_objPregunta.Seccion.IdSeccionEncriptado == null || string.IsNullOrEmpty(_objPregunta.Seccion.IdSeccionEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la sección";
                }
                else if (_objPregunta.TipoPregunta.IdTipoPreguntaEncriptado == null || string.IsNullOrEmpty(_objPregunta.TipoPregunta.IdTipoPreguntaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del tipo de pregunta";
                }
                else if (_objPregunta.Descripcion == null || string.IsNullOrEmpty(_objPregunta.Descripcion))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la descripción de la pregunta";
                }
                else if (_objPregunta.Orden == 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el orden de la pregunta";
                }
                else
                {
                    int _idSeccion = Convert.ToInt32(_seguridad.DesEncriptar(_objPregunta.Seccion.IdSeccionEncriptado));
                    int _idTipoPregunta = Convert.ToInt32(_seguridad.DesEncriptar(_objPregunta.TipoPregunta.IdTipoPreguntaEncriptado));
                    _objPregunta.Seccion.IdSeccion = _idSeccion;
                    _objPregunta.TipoPregunta.IdTipoPregunta = _idTipoPregunta;
                    _objPregunta.Estado = true;
                    int _idPregunta = _objCatalogoPregunta.InsertarPregunta(_objPregunta);
                    if (_idPregunta == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un problema al intentar ingresar la pregunta";
                    }
                    else
                    {
                        _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(_idPregunta).Where(c => c.Estado == true).FirstOrDefault();
                        _objPregunta.IdPregunta = 0;
                        _objPregunta.TipoPregunta.IdTipoPregunta = 0;
                        _objPregunta.Seccion.IdSeccion = 0;
                        _objPregunta.Seccion.Componente.IdComponente = 0;
                        _objPregunta.Seccion.Componente.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                        _respuesta = _objPregunta;
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
        [Route("api/pregunta_modificar")]
        public object pregunta_modificar(Pregunta _objPregunta)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objPregunta == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto pregunta";
                }
                else if (_objPregunta.IdPreguntaEncriptado == null || string.IsNullOrEmpty(_objPregunta.IdPreguntaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la pregunta";
                }
                else if (_objPregunta.Seccion.IdSeccionEncriptado == null || string.IsNullOrEmpty(_objPregunta.Seccion.IdSeccionEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la sección";
                }
                else if (_objPregunta.TipoPregunta.IdTipoPreguntaEncriptado == null || string.IsNullOrEmpty(_objPregunta.TipoPregunta.IdTipoPreguntaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del tipo de pregunta";
                }
                else if (_objPregunta.Descripcion == null || string.IsNullOrEmpty(_objPregunta.Descripcion))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la descripción de la pregunta";
                }
                else if (_objPregunta.Orden == 0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el orden de la pregunta";
                }
                else
                {
                    int _idPregunta = Convert.ToInt32(_seguridad.DesEncriptar(_objPregunta.IdPreguntaEncriptado));
                    int _idSeccion = Convert.ToInt32(_seguridad.DesEncriptar(_objPregunta.Seccion.IdSeccionEncriptado));
                    int _idTipoPregunta = Convert.ToInt32(_seguridad.DesEncriptar(_objPregunta.TipoPregunta.IdTipoPreguntaEncriptado));
                    _objPregunta.IdPregunta = _idPregunta;
                    _objPregunta.Seccion.IdSeccion = _idSeccion;
                    _objPregunta.TipoPregunta.IdTipoPregunta = _idTipoPregunta;
                    _objPregunta.Estado = true;
                    _idPregunta = _objCatalogoPregunta.InsertarPregunta(_objPregunta);
                    if (_idPregunta == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un problema al intentar modificar la pregunta";
                    }
                    else
                    {
                        _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(_idPregunta).Where(c => c.Estado == true).FirstOrDefault();
                        _objPregunta.IdPregunta = 0;
                        _objPregunta.TipoPregunta.IdTipoPregunta = 0;
                        _objPregunta.Seccion.IdSeccion = 0;
                        _objPregunta.Seccion.Componente.IdComponente = 0;
                        _objPregunta.Seccion.Componente.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                        _respuesta = _objPregunta;
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
        [Route("api/pregunta_cambiarestado")]
        public object pregunta_cambiarestado(string _idPreguntaEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idPreguntaEncriptado == null || string.IsNullOrEmpty(_idPreguntaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la pregunta";
                }
                else
                {
                    int _idPregunta = Convert.ToInt32(_seguridad.DesEncriptar(_idPreguntaEncriptado));
                    var _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(_idPregunta).FirstOrDefault();
                    if (_objPregunta == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró la pregunta que intenta modificar";
                    }
                    else
                    {
                        bool _nuevoEstado = false;
                        if(_objPregunta.Estado==false)
                        {
                            _nuevoEstado = true;
                        }
                        _objPregunta.Estado = _nuevoEstado;
                        _idPregunta = _objCatalogoPregunta.ModificarPregunta(_objPregunta);
                        if (_idPregunta == 0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Ocurrió un problema al intentar modificar la pregunta";
                        }
                        else
                        {
                            _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(_idPregunta).FirstOrDefault();
                            _objPregunta.IdPregunta = 0;
                            _objPregunta.TipoPregunta.IdTipoPregunta = 0;
                            _objPregunta.Seccion.IdSeccion = 0;
                            _objPregunta.Seccion.Componente.IdComponente = 0;
                            _objPregunta.Seccion.Componente.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                            _respuesta = _objPregunta;
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
        [Route("api/pregunta_eliminar")]
        public object pregunta_eliminar(string _idPreguntaEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idPreguntaEncriptado == null || string.IsNullOrEmpty(_idPreguntaEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la pregunta";
                }
                else
                {
                    int _idPregunta = Convert.ToInt32(_seguridad.DesEncriptar(_idPreguntaEncriptado));
                    var _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(_idPregunta).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objPregunta == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró la pregunta que intenta eliminar";
                    }
                    else if (_objPregunta.Utilizado == "1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Esta pregunta ya ha sido utilizada, por lo tanto no puede ser eliminada.";
                    }
                    else
                    {
                        _objCatalogoPregunta.EliminarPregunta(_idPregunta);
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
        [Route("api/pregunta_consultar")]
        public object pregunta_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _lista = _objCatalogoPregunta.ConsultarPregunta().Where(c => c.Estado == true).ToList();
                foreach (var _objPregunta in _lista)
                {
                    _objPregunta.IdPregunta = 0;
                    _objPregunta.TipoPregunta.IdTipoPregunta = 0;
                    _objPregunta.Seccion.IdSeccion = 0;
                    _objPregunta.Seccion.Componente.IdComponente = 0;
                    _objPregunta.Seccion.Componente.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                }
                _respuesta = _lista;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }
        [HttpPost]
        [Route("api/pregunta_consultaridseccion")]
        public object pregunta_consultaridseccion(string _idSeccionEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idSeccionEncriptado == null || string.IsNullOrEmpty(_idSeccionEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la sección";
                }
                else
                {
                    int _idSeccion = Convert.ToInt32(_seguridad.DesEncriptar(_idSeccionEncriptado));
                    var _objSeccion = _objCatalogoSeccion.ConsultarSeccionPorId(_idSeccion).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objSeccion == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el objeto sección";
                    }
                    else
                    {
                        var _lista = _objCatalogoPregunta.ConsultarPreguntaPorIdSeccion(_idSeccion).Where(c => c.Estado == true).ToList();
                        foreach (var _objPregunta in _lista)
                        {
                            _objPregunta.IdPregunta = 0;
                            _objPregunta.TipoPregunta.IdTipoPregunta = 0;
                            _objPregunta.Seccion.IdSeccion = 0;
                            _objPregunta.Seccion.Componente.IdComponente = 0;
                            _objPregunta.Seccion.Componente.CuestionarioGenerico.IdCuestionarioGenerico = 0;
                        }
                        _respuesta = _lista;
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
