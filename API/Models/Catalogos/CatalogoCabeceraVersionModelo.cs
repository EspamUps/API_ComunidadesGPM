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
        CatalogoVersionamientoModelo _objVersionamientoModelo = new CatalogoVersionamientoModelo();
        CatalogoCuestionarioGenerico _objCuestionarioGenerico = new CatalogoCuestionarioGenerico();
        CatalogoDescripcionComponente _objDescripcionComponente = new CatalogoDescripcionComponente();
        public int InsertarCabeceraVersionModelo(CabeceraVersionModelo _obCabeceraVersionModelo)
        {
            try
            {
                return int.Parse(db.Sp_CabeceraVersionModeloInsertar(int.Parse(_obCabeceraVersionModelo.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado),int.Parse(_obCabeceraVersionModelo.IdModeloGenerico),_obCabeceraVersionModelo.Caracteristica,_obCabeceraVersionModelo.Version).Select(x => x.Value.ToString()).FirstOrDefault());
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
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p=> p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                });
            }
            return _lista;
        }
        public List<CabeceraVersionModelo> ConsultarCabeceraVersionModeloPorId(int _idCabeceraVersionModelo)
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar().Where(p=> p.IdCabeceraVersionModelo == _idCabeceraVersionModelo).ToList())
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

        public List<CabeceraVersionModelo> ConsultarCabeceraVersionModeloTodasLasVersiones()
        {
            //body versionamientomodelo
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaCuestionarioGenerico = _objCuestionarioGenerico.ConsultarCuestionarioGenerico();
            var ListaDescripcionCompoennte = _objDescripcionComponente.ConsultarDescripcionComponente();
            var ListaModeloGenerico = ConsultarModeloGenerico().ToList();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar())
            {
                List<AsignarComponenteGenerico> ListaAsignarComponenteGenerico = new List<AsignarComponenteGenerico>();
                foreach (var dataComponentes in db.Sp_ComponenteConsultarDeUnaVersion(item.IdCabeceraVersionModelo))
                {
                    Componente Componentes = new Componente();
                    List<DescripcionComponente> DataDescripcionComponente = new List<DescripcionComponente>();
                    Componentes.IdComponente = 0;
                    Componentes.IdComponenteEncriptado = _seguridad.Encriptar(dataComponentes.IdComponente.ToString());
                    Componentes.Descripcion = dataComponentes.Descripcion;
                    Componentes.Estado = dataComponentes.Estado;
                    Componentes.Orden = dataComponentes.Orden;
                    Componentes.CuestionarioGenerico = ListaCuestionarioGenerico.Where(p => p.IdCuestionarioGenerico == dataComponentes.IdCuestionarioGenerico).FirstOrDefault();
                    foreach (var DataDescripcionCompoennte in db.Sp_DataConsultarDeUnaVersion1(item.IdCabeceraVersionModelo,dataComponentes.IdComponente))
                    {
                        DataDescripcionComponente.Add(ListaDescripcionCompoennte.Where(p => p.IdDescripcionComponente == DataDescripcionCompoennte.DescripcionComponenteIdDescripcionComponente).FirstOrDefault());
                    }
                    ListaAsignarComponenteGenerico.Add(new AsignarComponenteGenerico()
                    {
                        Componente = Componentes,
                        DescripcionComponente = DataDescripcionComponente,
                    });
                }

                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    ModeloGenerico = ListaModeloGenerico.Where(p=> p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).FirstOrDefault(),
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Version = item.VersionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    AsignarComponenteGenerico = ListaAsignarComponenteGenerico,
                });
            }
            return _lista;
        }

    }
}