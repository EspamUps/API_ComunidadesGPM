using API.Models.Catalogos;
using API.Models.Metodos;
using API.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DescripcionComponenteController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoDescripcionComponente DescripcionComponente = new CatalogoDescripcionComponente();
        Seguridad _seguridad = new Seguridad();


        [HttpPost]
        [Route("api/descripcionComponente_insertar")]
        public object descripcionComponente_insertar(DescripcionComponente _objDescripcionComponente)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objDescripcionComponente == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el _objDescripcionComponente";
                }
                else if (_objDescripcionComponente.IdAsignarComponenteGenerico == null || string.IsNullOrEmpty(_objDescripcionComponente.IdAsignarComponenteGenerico))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el ComponenteGenerico";
                }
                else if (_objDescripcionComponente.Orden.ToString() == null || string.IsNullOrEmpty(_objDescripcionComponente.Orden.ToString()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el Orden";
                }
                else
                {
                    _objDescripcionComponente.IdAsignarComponenteGenerico = _seguridad.DesEncriptar(_objDescripcionComponente.IdAsignarComponenteGenerico);
                    int _idDescripcionComponente = DescripcionComponente.InsertarDescripcionComponente(_objDescripcionComponente);
                    if (_idDescripcionComponente == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar DescripcionComponente";
                    }
                    else
                    {
                        var _dataDescripcionComponente = DescripcionComponente.ConsultarDescripcionComponentePorId(_idDescripcionComponente).FirstOrDefault();
                        _dataDescripcionComponente.IdDescripcionComponente = 0;
                        _respuesta = _dataDescripcionComponente;
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
        [Route("api/descripcionComponente_eliminar")]
        public object asignarDescripcionComponenteTipoElemento_eliminar(DescripcionComponente _objDescripcionComponente)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objDescripcionComponente.IdDescripcionComponenteEncriptado == null || string.IsNullOrEmpty(_objDescripcionComponente.IdDescripcionComponenteEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el AsignarDescripcionComponenteTipoElemento";
                }
                else
                {
                    _objDescripcionComponente.IdDescripcionComponenteEncriptado = _seguridad.DesEncriptar(_objDescripcionComponente.IdDescripcionComponenteEncriptado);
                    /*var _objAsignarDescripcionComponenteTE = AsignarDescripcionComponenteTipoElemento.ConsultarAsignarDescripcionComponenteTipoElementoPorId(int.Parse(_objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado)).FirstOrDefault();
                    if (_objPrefecto.Utilizado == "1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Este alcalde ya ha sido utilizado, por lo tanto no lo puede eliminar.";
                    }
                    else
                    {*/
                    DescripcionComponente.eliminarDescripcionComponente(int.Parse(_objDescripcionComponente.IdDescripcionComponenteEncriptado));
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
                    //}
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
