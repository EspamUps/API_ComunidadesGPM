using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
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
        public CabeceraVersionModelo ConsultarInformacionVersion(int _idCabeceraVersionModelo)
        {
            CabeceraVersionModelo Version = new CabeceraVersionModelo();
            Version.IdCabeceraVersionModelo = 0;
            List<AsignarCuestionarioModelo> _AsignarCuestionarioModelo = new List<AsignarCuestionarioModelo>();
            foreach (var item in db.Sp_CuestionarioConsultarDeUnaVersion(_idCabeceraVersionModelo))
            {
                List<AsignarComponenteGenerico> _AsignarComponenteGenerico = new List<AsignarComponenteGenerico>();
                foreach (var item1 in db.Sp_ComponenteConsultarDeUnaVersion(_idCabeceraVersionModelo, item.CuestionarioGenericoIdCuestionarioGenerico))
                {
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
