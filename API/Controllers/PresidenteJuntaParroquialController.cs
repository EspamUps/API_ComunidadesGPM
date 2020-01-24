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
    public class PresidenteJuntaParroquialController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoPresidenteJuntaParroquial _objCatalogoPresidenteJuntaParroquial = new CatalogoPresidenteJuntaParroquial();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/presidentejuntaparroquial_consultar")]
        public object presidentejuntaparroquial_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaPresidenteJuntaParroquial = _objCatalogoPresidenteJuntaParroquial.ConsultarPresidenteJuntaParroquial().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaPresidenteJuntaParroquial)
                {
                    item.IdPresidenteJuntaParroquial = 0;
                    item.Parroquia.IdParroquia = 0;
                    item.Parroquia.Canton.IdCanton = 0;
                    item.Parroquia.Canton.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaPresidenteJuntaParroquial;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/presidentejuntaparroquial_consultar")]
        public object presidentejuntaparroquial_consultar(string _idPresidenteJuntaParroquialEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idPresidenteJuntaParroquialEncriptado == null || string.IsNullOrEmpty(_idPresidenteJuntaParroquialEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del presidente de la junta";
                }
                else
                {
                    int _idPresidenteJuntaParroquial = Convert.ToInt32(_seguridad.DesEncriptar(_idPresidenteJuntaParroquialEncriptado));
                    var _objPresidenteJuntaParroquial = _objCatalogoPresidenteJuntaParroquial.ConsultarPresidenteJuntaParroquialPorId(_idPresidenteJuntaParroquial).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objPresidenteJuntaParroquial == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el presidente de la junta parroquial.";
                    }
                    else
                    {
                        _objPresidenteJuntaParroquial.IdPresidenteJuntaParroquial = 0;
                        _objPresidenteJuntaParroquial.Parroquia.IdParroquia = 0;
                        _objPresidenteJuntaParroquial.Parroquia.Canton.IdCanton = 0;
                        _objPresidenteJuntaParroquial.Parroquia.Canton.Provincia.IdProvincia = 0;
                        _respuesta = _objPresidenteJuntaParroquial;
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
