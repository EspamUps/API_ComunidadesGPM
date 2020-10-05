using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoCabeceraVersionModelo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoAsignarUsuarioTipoUsuario _objAsignarUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();
        public int InsertarCabeceraVersionModelo(CabeceraVersionModelo _obCabeceraVersionModelo)
        {
            try
            {
                int idCabeceraVersion = int.Parse(db.Sp_CabeceraVersionModeloInsertar(int.Parse(_obCabeceraVersionModelo.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado), int.Parse(_obCabeceraVersionModelo.IdModeloGenerico), _obCabeceraVersionModelo.Caracteristica, _obCabeceraVersionModelo.Version).Select(x => x.Value.ToString()).FirstOrDefault());
                foreach (var item in db.Sp_AsignarComponenteGenericoPorModeloGenericoConsultar(int.Parse(_obCabeceraVersionModelo.IdModeloGenerico)))
                {
                    string contenido = "";
                    int imagen = 0;
                    foreach (var item1 in db.Sp_ConfigurarComponentePorIdAsignarComponente(item.IdAsignarComponenteGenerico))
                    {
                        contenido = item1.Contenido;
                        if (item1.Imagen)
                        {
                            imagen = 1;
                        }
                    }
                    int idVersionamientoModelo = int.Parse(db.Sp_VersionamientoModeloInsertar(idCabeceraVersion, item.IdAsignarComponenteGenerico, true, contenido, imagen).Select(x => x.Value.ToString()).FirstOrDefault());
                }
                return idCabeceraVersion;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<CabeceraVersionModelo> ConsultarCabeceraVersionModelo()
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar())
            {
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Version = item.VersionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                });
            }
            return _lista;
        }
        public List<CabeceraVersionModelo> ConsultarCabeceraVersionModeloPorId(int _idCabeceraVersionModelo)
        {
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloPorIdConsultar(_idCabeceraVersionModelo))
            {
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.CabeceraVersionModeloIdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.CabeceraVersionModeloIdModeloGenerico.ToString()),
                    Version = item.CabeceraVersionModeloVersion,
                    Caracteristica = item.CabeceraVersionModeloCaracteristica,
                    FechaCreacion = item.CabeceraVersionModeloFechaCreacion,
                    Estado = item.CabeceraVersionModeloEstado,
                    Publicado = item.Publicado
                });
            }
            return _lista;
        }
        public List<ModeloGenerico> ConsultarModeloGenerico()
        {
            List<ModeloGenerico> _lista = new List<ModeloGenerico>();
            foreach (var item in db.Sp_ModeloGenericoConsultar())
            {
                _lista.Add(new ModeloGenerico()
                {
                    IdModeloGenerico = item.IdModeloGenerico,
                    IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado,
                    Utilizado = item.ModeloGenericoUtilizado
                });
            }
            return _lista;
        }
        public void EliminarCabeceraVersionModelo(int _idCabeceraVersionModelo)
        {
            db.Sp_CabeceraVersionModeloEliminar(_idCabeceraVersionModelo);
        }
        public List<CabeceraVersionModelo> ConsultarVersionCaracterizacionPorModeloGenerico(int _idModeloGenerico)
        {
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloPorModeloGenericoConsultar(_idModeloGenerico))
            {
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.CabeceraVersionModeloIdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.CabeceraVersionModeloIdModeloGenerico.ToString()),
                    Version = item.CabeceraVersionModeloVersion,
                    Caracteristica = item.CabeceraVersionModeloCaracteristica,
                    FechaCreacion = item.CabeceraVersionModeloFechaCreacion,
                    Estado = item.CabeceraVersionModeloEstado,
                    Publicado = item.Publicado
                });
            }
            return _lista;
        }
        public List<CabeceraVersionModelo> ConsultarVersionCaracterizacionPorPublicar(int _idModeloGenerico)
        {
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloParaPublicarConsultar(_idModeloGenerico))
            {
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.CabeceraVersionModeloIdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.CabeceraVersionModeloIdModeloGenerico.ToString()),
                    Version = item.CabeceraVersionModeloVersion,
                    Caracteristica = item.CabeceraVersionModeloCaracteristica,
                    FechaCreacion = item.CabeceraVersionModeloFechaCreacion,
                    Estado = item.CabeceraVersionModeloEstado
                });
            }
            return _lista;
        }
        public CabeceraVersionModelo ConsultarInformacionVersion(int _idCabeceraVersionModelo, int? _asignarEncuestado)
        {
            CabeceraVersionModelo Version = new CabeceraVersionModelo();
            Version.IdCabeceraVersionModelo = 0;
            List<AsignarCuestionarioModelo> _AsignarCuestionarioModelo = new List<AsignarCuestionarioModelo>();
            foreach (var item in db.Sp_CuestionarioConsultarDeUnaVersion(_idCabeceraVersionModelo))
            {
                List<AsignarComponenteGenerico> _AsignarComponenteGenerico = new List<AsignarComponenteGenerico>();
                foreach (var item1 in db.Sp_ComponenteConsultarDeUnaVersion(_idCabeceraVersionModelo, item.CuestionarioGenericoIdCuestionarioGenerico))
                {
                    if (_asignarEncuestado != null)
                    {
                        var doc = new HtmlDocument();
                        doc.LoadHtml(item1.VersionamientoModeloContenido);
                        HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//textarea").ToArray();
                        foreach (HtmlNode node in nodes)
                        {
                            List<Pregunta> _Pregunta = new List<Pregunta>();
                            foreach (var item2 in db.Sp_ConsultarPreguntaPorId(int.Parse(_seguridad.DesEncriptar(node.GetAttributeValue("name", string.Empty)))))
                            {
                                if (item2.TipoPreguntaIdentificador == 1)
                                {
                                    string RespuestaPabierta = "";
                                    foreach (var item3 in db.Sp_ConsultarRespuestaPreguntaAbierta(_asignarEncuestado, item2.PreguntaIdPregunta))
                                    {
                                        RespuestaPabierta = item3.RespuestaDescripcionRespuestaAbierta;
                                    }
                                    if (RespuestaPabierta == "")
                                    {
                                        RespuestaPabierta = "N/A";
                                    }
                                    RespuestaPabierta = "<strong>" + RespuestaPabierta + "</strong>";
                                    item1.VersionamientoModeloContenido = item1.VersionamientoModeloContenido.Replace(node.OuterHtml, RespuestaPabierta);
                                }
                                else if (item2.TipoPreguntaIdentificador == 2)
                                {
                                    string RespuestaUnica = "";
                                    foreach (var item3 in db.Sp_ConsultarRespuestaPreguntaUnica(_asignarEncuestado, item2.PreguntaIdPregunta))
                                    {
                                        if (item3.PreguntaEncajonadaIdPreguntaEncajonada == null)
                                        {
                                            RespuestaUnica = item3.OpcionPreguntaSeleccionDescripcion;
                                        }
                                        else
                                        {
                                            foreach (var item4 in db.Sp_PreguntaConsultar().Where(p => p.IdPregunta == item3.PreguntaEncajonadaIdPregunta).ToList())
                                            {
                                                if (item4.IdentificadorTipoPregunta == 1)
                                                {
                                                    RespuestaUnica = item3.RespuestaDescripcionRespuestaAbierta;
                                                }
                                            }
                                        }
                                    }
                                    if (RespuestaUnica == "")
                                    {
                                        RespuestaUnica = "N/A";
                                    }
                                    RespuestaUnica = "<strong>" + RespuestaUnica + "</strong>";
                                    item1.VersionamientoModeloContenido = item1.VersionamientoModeloContenido.Replace(node.OuterHtml, RespuestaUnica);
                                }
                                else if (item2.TipoPreguntaIdentificador == 3)
                                {
                                    string RespuestaMultiple = "";
                                    foreach (var item3 in db.Sp_ConsultarRespuestaPreguntaMultiple(_asignarEncuestado, item2.PreguntaIdPregunta))
                                    {
                                        RespuestaMultiple += "<li><strong>" + item3.OpcionPreguntaSeleccionDescripcion + "</strong></li>";
                                    }
                                    if (RespuestaMultiple != "")
                                    {
                                        RespuestaMultiple = "<ul>" + RespuestaMultiple + "</ul>";
                                    }
                                    else
                                    {
                                        RespuestaMultiple = "<ul><li><strong>N/A</strong></li></ul>";
                                    }
                                    item1.VersionamientoModeloContenido = item1.VersionamientoModeloContenido.Replace(node.ParentNode.ParentNode.OuterHtml, RespuestaMultiple);
                                }
                                else if(item2.TipoPreguntaIdentificador == 4)
                                {
                                    string RespuestaMatriz = "";
                                    string base_ = node.InnerHtml;
                                    foreach (var item3 in db.Sp_ConsultarRespuestaMatriz(_asignarEncuestado, item2.PreguntaIdPregunta))
                                    {
                                        string dato = "";
                                        dato = base_.Replace("F", "<strong>" + item3.OpcionUnoMatrizDescripcion + "</strong>");
                                        dato = dato.Replace("C", "<strong>" + item3.OpcionDosMatrizDescripcion + "</strong>");                                        
                                        RespuestaMatriz += "<p>"+ dato + "</p>";
                                    }
                                    if (RespuestaMatriz!="")
                                    {
                                        item1.VersionamientoModeloContenido = item1.VersionamientoModeloContenido.Replace(node.OuterHtml, RespuestaMatriz);
                                    }
                                }
                                _Pregunta.Add(new Pregunta()
                                {
                                    Descripcion = item2.PreguntaDescripcion,
                                    TipoPregunta = new TipoPregunta()
                                    {
                                        Descripcion = item2.TipoPreguntaDescripcion,
                                        Identificador = item2.TipoPreguntaIdentificador
                                    }
                                });
                            }
                        }
                    }
                    _AsignarComponenteGenerico.Add(new AsignarComponenteGenerico()
                    {
                        IdComponente = "0",
                        Orden = item1.ComponenteOrden,
                        Componente = new Componente()
                        {
                            Descripcion = item1.ComponenteDescripcion,
                        },
                        VersionamientoModelo = new VersionamientoModelo()
                        {
                            Contenido = item1.VersionamientoModeloContenido,
                            Imagen = Convert.ToInt32(item1.VersionamientoModeloImagen)
                        }
                    });
                }
                if (_AsignarComponenteGenerico.Count > 0)
                {
                    _AsignarComponenteGenerico = _AsignarComponenteGenerico.OrderBy(e => e.Orden).ToList();
                }
                _AsignarCuestionarioModelo.Add(new AsignarCuestionarioModelo()
                {
                    IdModeloGenerico = "0",
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicado = 0,
                        CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                        {
                            Caracteristica = item.CabeceraVersionCuestionarioCaracteristica,
                            Version = item.CabeceraVersionCuestionarioVersion,
                        },
                        CuestionarioGenerico = new CuestionarioGenerico()
                        {
                            Descripcion = item.CuestionarioGenericoDescripcion,
                            Nombre = item.CuestionarioGenericoNombre,
                        }
                    },
                    AsignarComponenteGenerico = _AsignarComponenteGenerico
                });
            }
            Version.AsignarCuestionarioModelo = _AsignarCuestionarioModelo;
            return Version;
        }
    }
}
