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
    public class AsignarDescripcionComponenteTipoElementoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarDescripcionComponenteTipoElemento AsignarDescripcionComponenteTipoElemento = new CatalogoAsignarDescripcionComponenteTipoElemento();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/asignarDescripcionComponenteTipoElemento_insertar")]
        public object asignarDescripcionComponenteTipoElemento_insertar(AsignarDescripcionComponenteTipoElemento _objAsignarDescripcionComponenteTipoElemento)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objAsignarDescripcionComponenteTipoElemento == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el objeto alcalde";
                }
                else if (_objAsignarDescripcionComponenteTipoElemento.IdDescripcionComponente == null || string.IsNullOrEmpty(_objAsignarDescripcionComponenteTipoElemento.IdDescripcionComponente))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el DescripcionComponente";
                }
                else if (_objAsignarDescripcionComponenteTipoElemento.IdTipoElemento == null || string.IsNullOrEmpty(_objAsignarDescripcionComponenteTipoElemento.IdTipoElemento))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el TipoElemento";
                }else
                {
                    _objAsignarDescripcionComponenteTipoElemento.IdDescripcionComponente = _seguridad.DesEncriptar(_objAsignarDescripcionComponenteTipoElemento.IdDescripcionComponente);
                    _objAsignarDescripcionComponenteTipoElemento.IdTipoElemento = _seguridad.DesEncriptar(_objAsignarDescripcionComponenteTipoElemento.IdTipoElemento);
                    int _idAsignarDescripcionComponenteTipoElemento = AsignarDescripcionComponenteTipoElemento.InsertarAsignarDescripcionComponenteTipoElemento(_objAsignarDescripcionComponenteTipoElemento);
                    if (_idAsignarDescripcionComponenteTipoElemento == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar al AsignarDescripcionComponenteTipoElemento";
                    }
                    else
                    {
                        var dataAsignarDescripcionComponenteTipoElemento = AsignarDescripcionComponenteTipoElemento.ConsultarAsignarDescripcionComponenteTipoElementoPorId(_idAsignarDescripcionComponenteTipoElemento).FirstOrDefault();
                        dataAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento = 0;
                        _respuesta = dataAsignarDescripcionComponenteTipoElemento;
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
        [Route("api/asignarDescripcionComponenteTipoElemento_eliminar")]
        public object asignarDescripcionComponenteTipoElemento_eliminar(AsignarDescripcionComponenteTipoElemento _objAsignarDescripcionComponenteTipoElemento)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado == null || string.IsNullOrEmpty(_objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el AsignarDescripcionComponenteTipoElemento";
                }
                else
                {
                    _objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado = _seguridad.DesEncriptar(_objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado);
                    /*var _objAsignarDescripcionComponenteTE = AsignarDescripcionComponenteTipoElemento.ConsultarAsignarDescripcionComponenteTipoElementoPorId(int.Parse(_objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado)).FirstOrDefault();
                    if (_objPrefecto.Utilizado == "1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Este alcalde ya ha sido utilizado, por lo tanto no lo puede eliminar.";
                    }
                    else
                    {*/
                    AsignarDescripcionComponenteTipoElemento.eliminarAsignarDescripcionComponenteTipoElemento(int.Parse(_objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElementoEncriptado));
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
