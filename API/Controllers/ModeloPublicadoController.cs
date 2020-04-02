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
    public class ModeloPublicadoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoModeloPublicado _objModeloPublicados = new CatalogoModeloPublicado();
        Seguridad _seguridad = new Seguridad();


        [HttpPost]
        [Route("api/modeloPublicado_insertar")]
        public object modeloPublicado_insertar(ModeloPublicado _objModeloPublicado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objModeloPublicado == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "No se encontró el Modelo a publicar";
                }
                else if (_objModeloPublicado.IdCabeceraVersionModelo == null || string.IsNullOrEmpty(_objModeloPublicado.IdCabeceraVersionModelo))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la version a guardar";
                }
                else if (_objModeloPublicado.IdPeriodo == null || string.IsNullOrEmpty(_objModeloPublicado.IdPeriodo))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el periodo";
                }
                else if (_objModeloPublicado.IdAsignarUsuarioTipoUsuario == null || string.IsNullOrEmpty(_objModeloPublicado.IdAsignarUsuarioTipoUsuario))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese la asignacion tipo usuario";
                }
                else
                {
                    _objModeloPublicado.IdCabeceraVersionModelo = _seguridad.DesEncriptar(_objModeloPublicado.IdCabeceraVersionModelo);
                    _objModeloPublicado.IdPeriodo = _seguridad.DesEncriptar(_objModeloPublicado.IdPeriodo);
                    _objModeloPublicado.IdAsignarUsuarioTipoUsuario = _seguridad.DesEncriptar(_objModeloPublicado.IdAsignarUsuarioTipoUsuario);
                    int _idModeloPublicado = _objModeloPublicados.InsertarModeloPublicado(_objModeloPublicado);
                    if (_idModeloPublicado == 0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar al el modelo publicado";
                    }
                    else
                    {
                        var DataModeloPublicado = _objModeloPublicados.ConsultarModeloPublicadoPorId(_idModeloPublicado).FirstOrDefault();
                        DataModeloPublicado.IdModeloPublicado = 0;
                        _respuesta = DataModeloPublicado;
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
        [Route("api/modeloPublicado_eliminar")]
        public object modeloPublicado_eliminar(ModeloPublicado _objModeloPublicado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objModeloPublicado.IdModeloPublicadoEncriptado == null || string.IsNullOrEmpty(_objModeloPublicado.IdModeloPublicadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del modelo publicado que va a eliminar.";
                }
                else
                {
                    _objModeloPublicado.IdModeloPublicadoEncriptado = _seguridad.DesEncriptar(_objModeloPublicado.IdModeloPublicadoEncriptado);
                    var _objModeloPublicadoConsultado = _objModeloPublicados.ConsultarModeloPublicadoPorId(int.Parse(_objModeloPublicado.IdModeloPublicadoEncriptado)).FirstOrDefault();
                    if (_objModeloPublicadoConsultado == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "El modelo publicado que intenta eliminar no existe.";
                    }
                    else if (_objModeloPublicadoConsultado.Utilizado == "1")
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "El modelo publicado ya esta utilizado, por la tanto no puede ser eliminado.";
                    }
                    else
                    {
                        _objModeloPublicados.EliminarModeloPublicado(int.Parse(_objModeloPublicado.IdModeloPublicadoEncriptado));
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
        [Route("api/HabilitarModeloPublicado")]
        public object HabilitarModeloPublicado(ModeloPublicado _objModeloPublicado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objModeloPublicado.IdModeloPublicadoEncriptado == null || string.IsNullOrEmpty(_objModeloPublicado.IdModeloPublicadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del modelo publicado de la version que va habilitar";
                }
                else
                {
                    var _dataModeloPublicado = _objModeloPublicados.ConsultarModeloPublicadoPorId(int.Parse(_seguridad.DesEncriptar(_objModeloPublicado.IdModeloPublicadoEncriptado))).FirstOrDefault();
                    if (_dataModeloPublicado == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "El modelo publicado que intenta habilitar no existe.";
                    }
                    else
                    {
                        _objModeloPublicados.HabilitarModeloPublicado(int.Parse(_seguridad.DesEncriptar(_objModeloPublicado.IdModeloPublicadoEncriptado)));
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
        [Route("api/DesHabilitarModeloPublicad")]
        public object DesHabilitarModeloPublicad(ModeloPublicado _objModeloPublicado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objModeloPublicado.IdModeloPublicadoEncriptado == null || string.IsNullOrEmpty(_objModeloPublicado.IdModeloPublicadoEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Ingrese el identificador del modelo publicado de la version que va deshabilitar";
                }
                else
                {
                    var _dataModeloPublicado = _objModeloPublicados.ConsultarModeloPublicadoPorId(int.Parse(_seguridad.DesEncriptar(_objModeloPublicado.IdModeloPublicadoEncriptado))).FirstOrDefault();
                    if (_dataModeloPublicado == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "El modelo publicado que intenta deshabilitar no existe.";
                    }
                    else
                    {
                        _objModeloPublicados.DesHabilitarModeloPublicad(int.Parse(_seguridad.DesEncriptar(_objModeloPublicado.IdModeloPublicadoEncriptado)));
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
