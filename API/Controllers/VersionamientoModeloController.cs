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
    public class VersionamientoModeloController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoVersionamientoModelo _objVersionamientoModelo = new CatalogoVersionamientoModelo();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/versionamientoModelo_insertar")]
        public object versionamientoModelo_insertar(VersionamientoModelo VersionamientoModelo)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (VersionamientoModelo == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el objeto VersionamientoModelo";
                }
                else if (VersionamientoModelo.IdCabeceraVersionModelo == null || string.IsNullOrEmpty(VersionamientoModelo.IdCabeceraVersionModelo))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la cabecera de la version del modelo";
                }
                else if (VersionamientoModelo.IdDescripcionComponenteTipoElemento == null || string.IsNullOrEmpty(VersionamientoModelo.IdDescripcionComponenteTipoElemento))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la descripcion del componente tipo elemento";
                }
                else if (VersionamientoModelo.Estado.ToString() == null || string.IsNullOrEmpty(VersionamientoModelo.Estado.ToString()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el estado";
                }
                else
                {
                    VersionamientoModelo.IdCabeceraVersionModelo = _seguridad.DesEncriptar(VersionamientoModelo.IdCabeceraVersionModelo);
                    VersionamientoModelo.IdDescripcionComponenteTipoElemento = _seguridad.DesEncriptar(VersionamientoModelo.IdDescripcionComponenteTipoElemento);
                    int _idVersionamientoModelo = _objVersionamientoModelo.InsertarVersionamientoModelo(VersionamientoModelo);
                    if (_idVersionamientoModelo == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar la version modelo";
                    }
                    else
                    {
                        var dataVersionamientoModelo = _objVersionamientoModelo.ConsultarVersionamientoModeloPorId(_idVersionamientoModelo).FirstOrDefault();
                        dataVersionamientoModelo.IdVersionamientoModelo = 0;
                        _respuesta = dataVersionamientoModelo;
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
        [Route("api/versionamientoModelo_eliminar")]
        public object versionamientoModelo_eliminar(VersionamientoModelo VersionamientoModelo)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (VersionamientoModelo.IdVersionamientoModeloEncriptado == null || string.IsNullOrEmpty(VersionamientoModelo.IdVersionamientoModeloEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador de la cabecera versionamiento que va a eliminar.";
                    //}else if (VersionamientoModelo.IdDescripcionComponenteTipoElemento == null || string.IsNullOrEmpty(VersionamientoModelo.IdDescripcionComponenteTipoElemento))
                    //{
                    //    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    //    _http.mensaje = "Ingrese el identificador de la descripcion componente tipo elemento que va a eliminar.";
                    //}
                }
                else
                {
                    //VersionamientoModelo.IdCabeceraVersionModelo = _seguridad.DesEncriptar(VersionamientoModelo.IdCabeceraVersionModelo);
                    //VersionamientoModelo.IdDescripcionComponenteTipoElemento = _seguridad.DesEncriptar(VersionamientoModelo.IdDescripcionComponenteTipoElemento);
                    var DataVersionamientoModelo = _objVersionamientoModelo.ConsultarVersionamientoModelo().Where(p => p.IdVersionamientoModelo.ToString() == _seguridad.DesEncriptar(VersionamientoModelo.IdVersionamientoModeloEncriptado)).FirstOrDefault();
                    if (DataVersionamientoModelo == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "El versionamiento que intenta eliminar no existe.";
                    }
                    /*else if (DataVersionamientoModelo == "1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "El cantón ya es utilizado, por la tanto no puede ser eliminado.";
                    }*/
                    else
                    {
                        _respuesta = _objVersionamientoModelo.EliminarVersionamientoModelo(DataVersionamientoModelo.IdVersionamientoModelo);
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
