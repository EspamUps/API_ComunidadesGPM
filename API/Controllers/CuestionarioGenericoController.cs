using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Catalogos;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Controllers
{
    public class CuestionarioGenericoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoCuestionarioGenerico _objCatalogoCuestionarioGenerico = new CatalogoCuestionarioGenerico();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/cuestionariogenerico_insertar")]
        public object cuestionariogenerico_insertar(CuestionarioGenerico _objCuestionarioGenerico)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if(_objCuestionarioGenerico==null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto cuestionario genérico";
                }
                else if(_objCuestionarioGenerico.Nombre == null || string.IsNullOrEmpty(_objCuestionarioGenerico.Nombre.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el nombre del cuestionario genérico";
                }
                else if(_objCuestionarioGenerico.Descripcion == null || string.IsNullOrEmpty(_objCuestionarioGenerico.Descripcion.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la descripción del cuestionario genérico";
                }
                else if (_objCatalogoCuestionarioGenerico.ConsultarCuestionarioGenerico().Where(c=>c.Estado==true && c.Nombre==_objCuestionarioGenerico.Nombre.Trim()).ToList().Count>0)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                    _http.mensaje = "Ya existe un cuestionario con el mismo nombre, verifique en la lista.";
                }
                else
                {
                    _objCuestionarioGenerico.Nombre = _objCuestionarioGenerico.Nombre.Trim();
                    _objCuestionarioGenerico.Estado = true;
                    int _idCuestionarioGenerico = _objCatalogoCuestionarioGenerico.InsertarCuestionarioGenerico(_objCuestionarioGenerico);
                    if(_idCuestionarioGenerico==0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar el cuestionario.";
                    }
                    else
                    {
                        var _objCuestionarioGenericoIngresado = _objCatalogoCuestionarioGenerico.ConsultarCuestionarioGenerico().Where(C => C.IdCuestionarioGenerico == _idCuestionarioGenerico && C.Estado == true).FirstOrDefault();
                        _objCuestionarioGenericoIngresado.IdCuestionarioGenerico = 0;
                        _respuesta = _objCuestionarioGenericoIngresado;
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
        [Route("api/cuestionariogenerico_modificar")]
        public object cuestionariogenerico_modificar(CuestionarioGenerico _objCuestionarioGenerico)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objCuestionarioGenerico == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el objeto cuestionario genérico";
                }
                else if (_objCuestionarioGenerico.IdCuestionarioGenericoEncriptado == null || string.IsNullOrEmpty(_objCuestionarioGenerico.IdCuestionarioGenericoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del cuestionario genérico";
                }
                else if (_objCuestionarioGenerico.Nombre == null || string.IsNullOrEmpty(_objCuestionarioGenerico.Nombre.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el nombre del cuestionario genérico";
                }
                else if (_objCuestionarioGenerico.Descripcion == null || string.IsNullOrEmpty(_objCuestionarioGenerico.Descripcion.Trim()))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la descripción del cuestionario genérico";
                }
                else
                {
                    int _idCuestionarioGenerico = Convert.ToInt32(_seguridad.DesEncriptar(_objCuestionarioGenerico.IdCuestionarioGenericoEncriptado));
                    if (_objCatalogoCuestionarioGenerico.ConsultarCuestionarioGenerico().Where(c => c.Estado == true && c.Nombre == _objCuestionarioGenerico.Nombre.Trim() && c.IdCuestionarioGenerico!= _idCuestionarioGenerico).ToList().Count > 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "406").FirstOrDefault();
                        _http.mensaje = "Ya existe un cuestionario con el mismo nombre, verifique en la lista.";
                    }
                    else
                    {
                        _objCuestionarioGenerico.IdCuestionarioGenerico = _idCuestionarioGenerico;
                        _objCuestionarioGenerico.Nombre = _objCuestionarioGenerico.Nombre.Trim();
                        _objCuestionarioGenerico.Estado = true;
                        _idCuestionarioGenerico = _objCatalogoCuestionarioGenerico.ModificarCuestionarioGenerico(_objCuestionarioGenerico);
                        if (_idCuestionarioGenerico == 0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Ocurrió un error al tratar de modificar el cuestionario.";
                        }
                        else
                        {
                            var _objCuestionarioGenericoModificado = _objCatalogoCuestionarioGenerico.ConsultarCuestionarioGenerico().Where(C => C.IdCuestionarioGenerico == _idCuestionarioGenerico && C.Estado == true).FirstOrDefault();
                            _objCuestionarioGenericoModificado.IdCuestionarioGenerico = 0;
                            _respuesta = _objCuestionarioGenericoModificado;
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
        [Route("api/cuestionariogenerico_consultar")]
        public object cuestionariogenerico_consultar()
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                var _listaCuestionariosGenericos = _objCatalogoCuestionarioGenerico.ConsultarCuestionarioGenerico().Where(c => c.Estado == true).ToList();
                foreach (var item in _listaCuestionariosGenericos)
                {
                    item.IdCuestionarioGenerico = 0;
                }
                _respuesta = _listaCuestionariosGenericos;
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }
        [HttpPost]
        [Route("api/cuestionariogenerico_eliminar")]
        public object cuestionariogenerico_eliminar(string _idCuestionarioGenericoEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_idCuestionarioGenericoEncriptado == null || string.IsNullOrEmpty(_idCuestionarioGenericoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del cuestionario genérico";
                }
                int _idCuestionarioGenerico = Convert.ToInt32(_seguridad.DesEncriptar(_idCuestionarioGenericoEncriptado));
                _objCatalogoCuestionarioGenerico.EliminarCuestionarioGenerico(_idCuestionarioGenerico);
                _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "200").FirstOrDefault();
            }
            catch (Exception ex)
            {
                _http.mensaje = _http.mensaje + " " + ex.Message.ToString();
            }
            return new { respuesta = _respuesta, http = _http };
        }
    }
}
