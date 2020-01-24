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
    public class AlcaldeController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAlcalde _objCatalogoAlcalde = new CatalogoAlcalde();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/alcalde_consultar")]
        public object alcalde_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaAlcalde = _objCatalogoAlcalde.ConsultarAlcalde().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaAlcalde)
                {
                    item.IdAlcalde = 0;
                    item.Canton.IdCanton = 0;
                    item.Canton.Provincia.IdProvincia = 0;
                }
                _respuesta = _listaAlcalde;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }

        [HttpPost]
        [Route("api/alcalde_consultar")]
        public object alcalde_consultar(string _idAlcaldeEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idAlcaldeEncriptado == null || string.IsNullOrEmpty(_idAlcaldeEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del alcalde";
                }
                else
                {
                    int _idAlcalde = Convert.ToInt32(_seguridad.DesEncriptar(_idAlcaldeEncriptado));
                    var _objAlcalde = _objCatalogoAlcalde.ConsultarAlcaldePorId(_idAlcalde).Where(c => c.Estado == true).FirstOrDefault();
                    if (_objAlcalde == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el alcalde registrado.";
                    }
                    else
                    {
                        _objAlcalde.IdAlcalde = 0;
                        _objAlcalde.Canton.IdCanton = 0;
                        _objAlcalde.Canton.Provincia.IdProvincia = 0;
                        _respuesta = _objAlcalde;
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
