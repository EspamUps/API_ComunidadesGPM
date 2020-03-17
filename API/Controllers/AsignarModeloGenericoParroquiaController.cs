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
    public class AsignarModeloGenericoParroquiaController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoAsignarModeloGenericoParroquia _objAsignarModeloGenericoParroquia = new CatalogoAsignarModeloGenericoParroquia();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/asignarModeloGenericoParroquia_insertar")]
        public object asignarModeloGenericoParroquia_insertar(AsignarModeloGenericoParroquia _AsignarModeloGenericoParroquia)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_AsignarModeloGenericoParroquia == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el objeto alcalde";
                }
                else if (_AsignarModeloGenericoParroquia.IdModeloGenerico == null || string.IsNullOrEmpty(_AsignarModeloGenericoParroquia.IdModeloGenerico))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el modelo generico";
                }
                else if (_AsignarModeloGenericoParroquia.IdParroquia == null || string.IsNullOrEmpty(_AsignarModeloGenericoParroquia.IdParroquia))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la parroquia";
                }
                else
                {
                    _AsignarModeloGenericoParroquia.IdParroquia = _seguridad.DesEncriptar(_AsignarModeloGenericoParroquia.IdParroquia);
                    _AsignarModeloGenericoParroquia.IdModeloGenerico = _seguridad.DesEncriptar(_AsignarModeloGenericoParroquia.IdModeloGenerico);
                    int _idAsignarModeloGenericoParroquia = _objAsignarModeloGenericoParroquia.InsertarAsignarModeloGenericoParroquia(_AsignarModeloGenericoParroquia);
                    if (_idAsignarModeloGenericoParroquia == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar el asignar modelo generico parroquia.";
                    }
                    else
                    {
                        _AsignarModeloGenericoParroquia = _objAsignarModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquiaPorId(_idAsignarModeloGenericoParroquia).FirstOrDefault();
                        _AsignarModeloGenericoParroquia.IdAsignarModeloGenericoParroquia = 0;
                        _respuesta = _AsignarModeloGenericoParroquia;
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
