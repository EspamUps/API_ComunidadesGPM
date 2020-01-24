using API.Models.Catalogos;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class LiderComunitarioController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoLiderComunitario _objCatalogoLiderComunitario = new CatalogoLiderComunitario();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/lidercomunitario_consultar")]
        public object lidercomunitario_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaLiderComunitario = _objCatalogoLiderComunitario.ConsultarLiderComunitario().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaLiderComunitario)
                {
                    item.IdLiderComunitario = 0;
                    item.Comunidad.IdComunidad = 0;
                    item.Comunidad.Parroquia.IdParroquia = 0;
                    item.Comunidad.Parroquia.Canton.IdCanton = 0;
                    item.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaLiderComunitario;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/lidercomunitario_consultar")]
        public object lidercomunitario_consultar(string _idLiderComunitarioEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idLiderComunitarioEncriptado == null || string.IsNullOrEmpty(_idLiderComunitarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del lider de la comunidad.";
                }
                else
                {
                    int _idLiderComunitario = Convert.ToInt32(_seguridad.DesEncriptar(_idLiderComunitarioEncriptado));
                    var _objLiderComunitario = _objCatalogoLiderComunitario.ConsultarLiderComunitarioPorId(_idLiderComunitario).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objLiderComunitario == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el lider de la comunidad.";
                    }
                    else
                    {
                        _objLiderComunitario.IdLiderComunitario = 0;
                        _objLiderComunitario.Comunidad.IdComunidad = 0;
                        _objLiderComunitario.Comunidad.Parroquia.IdParroquia = 0;
                        _objLiderComunitario.Comunidad.Parroquia.Canton.IdCanton = 0;
                        _objLiderComunitario.Comunidad.Parroquia.Canton.Provincia.IdProvincia = 0;
                        _respuesta = _objLiderComunitario;
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
