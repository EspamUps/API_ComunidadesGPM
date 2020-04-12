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
    public class ContenidoDetalleComponenteController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoContenidoDetalleComponente _objCatalogoContenidoDetalleComponente = new CatalogoContenidoDetalleComponente();
        CatalogoCabeceraCaracterizacion _objCatalogoCabeceraCaracterizacion = new CatalogoCabeceraCaracterizacion();
        CatalogoDescripcionComponente _objCatalogoDescripcionComponente = new CatalogoDescripcionComponente();
        Seguridad _seguridad = new Seguridad();

        [HttpPost]
        [Route("api/contenidodetallecomponente_insertar")]
        public object contenidodetallecomponente_insertar(ContenidoDetalleComponente _objContenidoDetalleComponente)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if(_objContenidoDetalleComponente == null)
                {
                     _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el objeto contenido detalle componente";
                }
                else if(_objContenidoDetalleComponente.CabeceraCaracterizacion==null || string.IsNullOrEmpty(_objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacionEncriptar))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador de la cabecera caracterización";
                }
                else if (string.IsNullOrEmpty(_objContenidoDetalleComponente.Contenido))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el contenido";
                }
                else if (_objContenidoDetalleComponente.DescripcionComponente ==null || string.IsNullOrEmpty(_objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponenteEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del objeto descripcion componente";
                }
                else if (_objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor == null || string.IsNullOrEmpty(_objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del objeto asignar usuario tipo usuario autor";
                }
                else if (_objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision == null || string.IsNullOrEmpty(_objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.IdAsignarUsuarioTipoUsuarioEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del objeto asignar usuario tipo usuario decisión";
                }
                else
                {
                    _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuarioEncriptado));
                    _objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacion = Convert.ToInt32(_seguridad.DesEncriptar(_objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacionEncriptar));
                    _objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponente = Convert.ToInt32(_seguridad.DesEncriptar(_objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponenteEncriptado));
                    _objContenidoDetalleComponente.EstadoDecision = true;
                    _objContenidoDetalleComponente.FechaDecision = DateTime.Now;
                    _objContenidoDetalleComponente.FechaRegistro = DateTime.Now;
                    _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.IdAsignarUsuarioTipoUsuario = Convert.ToInt32(_seguridad.DesEncriptar(_objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.IdAsignarUsuarioTipoUsuarioEncriptado));
                    _objContenidoDetalleComponente.Estado = true;

                    int _idContenidoDetalleComponente = _objCatalogoContenidoDetalleComponente.InsertarContenidoDetalleComponente(_objContenidoDetalleComponente);
                    if(_idContenidoDetalleComponente==0)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                        _http.mensaje = "Ocurrió un error al tratar de ingresar el contenido detalle componente.";
                    }
                    else
                    {
                        _objContenidoDetalleComponente = _objCatalogoContenidoDetalleComponente.ConsultarContenidoDetalleComponentePorId(_idContenidoDetalleComponente).FirstOrDefault();
                        _objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacion = 0;
                        _objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponente = 0;
                        _objContenidoDetalleComponente.DescripcionComponente.AsignarComponenteGenerico.IdAsignarComponenteGenerico = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.TipoUsuario.IdTipoUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.IdUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.IdPersona = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Sexo.IdSexo = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Parroquia.IdParroquia= 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.TipoUsuario.IdTipoUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.IdUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.IdPersona = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Sexo.IdSexo = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Parroquia.IdParroquia = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacion = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.IdAsignarResponsableModeloPublicado = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.IdModeloPublicado = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.IdCabeceraVersionModelo = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.ModeloGenerico.IdModeloGenerico = 0;

                        _respuesta = _objContenidoDetalleComponente;
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
        [Route("api/contenidodetallecomponente_modificar")]
        public object contenidodetallecomponente_modificar(ContenidoDetalleComponente _objContenidoDetalleComponente)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (_objContenidoDetalleComponente == null)
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el objeto contenido detalle componente";
                }
                else if (string.IsNullOrEmpty(_objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacionEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del contenido detalle componente";
                }
                else if (_objContenidoDetalleComponente.DescripcionComponente == null || string.IsNullOrEmpty(_objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponenteEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del objeto descripcion componente";
                }
                else
                {
                    int _idContenidoDetalleComponente = Convert.ToInt32(_seguridad.DesEncriptar(_objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacionEncriptado));
                    var _objContenidoDetalleComponenteConsultado = _objCatalogoContenidoDetalleComponente.ConsultarContenidoDetalleComponentePorId(_idContenidoDetalleComponente).FirstOrDefault();
                    if (_objContenidoDetalleComponenteConsultado == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el objeto que intenta modificar";
                    }
                    else
                    {
                        _objContenidoDetalleComponenteConsultado.Contenido = _objContenidoDetalleComponente.Contenido;
                        if (_objCatalogoContenidoDetalleComponente.ModificarContenidoDetalleComponente(_objContenidoDetalleComponenteConsultado) == 0)
                        {
                            _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                            _http.mensaje = "Ocurrió un error al tratar de modificar el contenido detalle componente.";
                        }
                        else
                        {
                            _objContenidoDetalleComponenteConsultado.IdContenidoDetalleComponenteCaracterizacion = 0;
                            _objContenidoDetalleComponenteConsultado.DescripcionComponente.IdDescripcionComponente = 0;
                            _objContenidoDetalleComponenteConsultado.DescripcionComponente.AsignarComponenteGenerico.IdAsignarComponenteGenerico = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.TipoUsuario.IdTipoUsuario = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.Usuario.IdUsuario = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.IdPersona = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Sexo.IdSexo = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Parroquia.IdParroquia = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioDecision.TipoUsuario.IdTipoUsuario = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioDecision.Usuario.IdUsuario = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.IdPersona = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Sexo.IdSexo = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                            _objContenidoDetalleComponenteConsultado.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Parroquia.IdParroquia = 0;
                            _objContenidoDetalleComponenteConsultado.CabeceraCaracterizacion.IdCabeceraCaracterizacion = 0;
                            _objContenidoDetalleComponenteConsultado.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.IdAsignarResponsableModeloPublicado = 0;
                            _objContenidoDetalleComponenteConsultado.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.IdModeloPublicado = 0;
                            _objContenidoDetalleComponenteConsultado.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.IdCabeceraVersionModelo = 0;
                            _objContenidoDetalleComponenteConsultado.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.ModeloGenerico.IdModeloGenerico = 0;

                            _respuesta = _objContenidoDetalleComponente;
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
        [Route("api/contenidodetallecomponente_eliminar")]
        public object contenidodetallecomponente_eliminar(string _idContenidoDetalleComponenteEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(_idContenidoDetalleComponenteEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del contenido detalle componente";
                }
                else
                {
                    int _idContenidoDetalleComponente = Convert.ToInt32(_seguridad.DesEncriptar(_idContenidoDetalleComponenteEncriptado));
                    var _objContenidoDetalleComponente = _objCatalogoContenidoDetalleComponente.ConsultarContenidoDetalleComponentePorId(_idContenidoDetalleComponente).FirstOrDefault();
                    if (_objContenidoDetalleComponente == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el contenido detalle componente que intenta eliminar";
                    }
                    else
                    {
                        _objCatalogoContenidoDetalleComponente.EliminarContenidoDetalleComponente(_idContenidoDetalleComponente);
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
        [Route("api/contenidodetallecomponente_consultar")]
        public object contenidodetallecomponente_consultar(string _idContenidoDetalleComponenteEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(_idContenidoDetalleComponenteEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador del contenido detalle componente";
                }
                else
                {
                    int _idContenidoDetalleComponente = Convert.ToInt32(_seguridad.DesEncriptar(_idContenidoDetalleComponenteEncriptado));
                    var _objContenidoDetalleComponente = _objCatalogoContenidoDetalleComponente.ConsultarContenidoDetalleComponentePorId(_idContenidoDetalleComponente).FirstOrDefault();
                    if (_objContenidoDetalleComponente == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el contenido detalle componente que intenta consultar";
                    }
                    else
                    {
                        _objContenidoDetalleComponente = _objCatalogoContenidoDetalleComponente.ConsultarContenidoDetalleComponentePorId(_idContenidoDetalleComponente).FirstOrDefault();
                        _objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacion = 0;
                        _objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponente = 0;
                        _objContenidoDetalleComponente.DescripcionComponente.AsignarComponenteGenerico.IdAsignarComponenteGenerico = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.TipoUsuario.IdTipoUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.IdUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.IdPersona = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Sexo.IdSexo = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Parroquia.IdParroquia = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.TipoUsuario.IdTipoUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.IdUsuario = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.IdPersona = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Sexo.IdSexo = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                        _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Parroquia.IdParroquia = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacion = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.IdAsignarResponsableModeloPublicado = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.IdModeloPublicado = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.IdCabeceraVersionModelo = 0;
                        _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.ModeloGenerico.IdModeloGenerico = 0;

                        _respuesta = _objContenidoDetalleComponente;
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
        [Route("api/contenidodetallecomponente_consultarporiddescripcioncomponente")]
        public object contenidodetallecomponente_consultarporiddescripcioncomponente(string _idDescripcionComponenteEncriptado)
        {
            object _respuesta = new object();
            RespuestaHTTP _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "500").FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(_idDescripcionComponenteEncriptado))
                {
                    _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "400").FirstOrDefault();
                    _http.mensaje = "Por favor, ingrese el identificador de la descripcion componente";
                }
                else
                {
                    int _idDescripcionComponente = Convert.ToInt32(_seguridad.DesEncriptar(_idDescripcionComponenteEncriptado));
                    var _objDescripcionComponente = _objCatalogoDescripcionComponente.ConsultarDescripcionComponentePorId(_idDescripcionComponente).FirstOrDefault();
                    if (_objDescripcionComponente == null)
                    {
                        _http = _objCatalogoRespuestasHTTP.consultar().Where(x => x.codigo == "404").FirstOrDefault();
                        _http.mensaje = "No se encontró el objeto descripcion componente";
                    }
                    else
                    {
                        var _listaContenidoDetalleComponente = _objCatalogoContenidoDetalleComponente.ConsultarContenidoDetalleComponentePorIdDescripcionComponente(_idDescripcionComponente).ToList();
                        foreach (var _objContenidoDetalleComponente in _listaContenidoDetalleComponente)
                        {
                            _objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacion = 0;
                            _objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponente = 0;
                            _objContenidoDetalleComponente.DescripcionComponente.AsignarComponenteGenerico.IdAsignarComponenteGenerico = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.TipoUsuario.IdTipoUsuario = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.IdUsuario = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.IdPersona = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Sexo.IdSexo = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.Usuario.Persona.Parroquia.IdParroquia = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.TipoUsuario.IdTipoUsuario = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.IdUsuario = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.IdPersona = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Sexo.IdSexo = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.TipoIdentificacion.IdTipoIdentificacion = 0;
                            _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.Usuario.Persona.Parroquia.IdParroquia = 0;
                            _objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacion = 0;
                            _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.IdAsignarResponsableModeloPublicado = 0;
                            _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.IdModeloPublicado = 0;
                            _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.IdCabeceraVersionModelo = 0;
                            _objContenidoDetalleComponente.CabeceraCaracterizacion.AsignarResponsableModeloPublicado.ModeloPublicado.CabeceraVersionModelo.ModeloGenerico.IdModeloGenerico = 0;

                        }
                        _respuesta = _listaContenidoDetalleComponente;
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
