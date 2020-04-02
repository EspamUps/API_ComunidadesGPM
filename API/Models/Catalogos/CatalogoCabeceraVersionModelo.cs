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
        CatalogoModeloPublicado _objModeloPublicado = new CatalogoModeloPublicado();
        CatalogoAsignarCuestionarioModelo _objAsignarCuestionarioModelo = new CatalogoAsignarCuestionarioModelo();
        CatalogoAsignarComponenteGenerico _objAsignarComponenteGenerico = new CatalogoAsignarComponenteGenerico();
        CatalogoAsignarModeloGenericoParroquia _objAsignarModeloGenericoParroquia = new CatalogoAsignarModeloGenericoParroquia();
        //CatalogoModeloGenerico _objModeloGenerico = new CatalogoModeloGenerico();
        public int InsertarCabeceraVersionModelo(CabeceraVersionModelo _obCabeceraVersionModelo)
        {
            try
            {
                int idCabeceraVersion = int.Parse(db.Sp_CabeceraVersionModeloInsertar(int.Parse(_obCabeceraVersionModelo.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuarioEncriptado), int.Parse(_obCabeceraVersionModelo.IdModeloGenerico), _obCabeceraVersionModelo.Caracteristica, _obCabeceraVersionModelo.Version).Select(x => x.Value.ToString()).FirstOrDefault());
                //foreach (var item in db.Sp_AsignarDescripcionComponenteTipoElementoConsultar().Where(p=>p.IdModeloGenerico == int.Parse(_obCabeceraVersionModelo.IdModeloGenerico)).ToList())
                //{
                //    try
                //    {
                //        int idVersionamientoModelo = int.Parse(db.Sp_VersionamientoModeloInsertar(idCabeceraVersion, item.IdAsignarDescripcionComponenteTipoElemento, true).Select(x => x.Value.ToString()).FirstOrDefault());
                //    }
                //    catch (Exception)
                //    {
                //        EliminarCabeceraVersionModelo(idCabeceraVersion);
                //        return 0;
                //    }
                //}
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
        public List<CabeceraVersionModelo> ConsultarCabeceraVersionModeloTodasLasVersiones(int _idModeloGenerico)
        {
            //body versionamientomodelo
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaCuestionarioGenerico = _objCuestionarioGenerico.ConsultarCuestionarioGenerico();
            var ListaDescripcionCompoennte = _objDescripcionComponente.ConsultarDescripcionComponente();
            var ListaModeloGenerico = ConsultarModeloGenerico().ToList();
            var ListaModeloPublicado = _objModeloPublicado.ConsultarModeloPublicado();
            var ListaVersionamientoModelo = _objVersionamientoModelo.ConsultarVersionamientoModelo();
            var ListaAsignarCuestionarioModelo = _objAsignarCuestionarioModelo.ConsultarAsignarCuestionarioModelo();
            var listaAsignarComponenteGenerico = _objAsignarComponenteGenerico.ConsultarAsignarComponenteGenerico();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar().Where(p => p.MODELOGENERICO_IdModeloGenerico == _idModeloGenerico).ToList())
            {
                ModeloGenerico DataModeloGenerico = new ModeloGenerico();
                DataModeloGenerico = ListaModeloGenerico.Where(p => p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).First();

                List<AsignarCuestionarioModelo> DataListaCuestionarioModelo = new List<AsignarCuestionarioModelo>();
                foreach (var item1 in db.Sp_ConsultarAsignarCuestionarioModeloDeUnaVersion(item.IdCabeceraVersionModelo).ToList())
                {
                    AsignarCuestionarioModelo DataAsignarCuestionarioModelo = new AsignarCuestionarioModelo();
                    DataAsignarCuestionarioModelo = ListaAsignarCuestionarioModelo.Where(p => p.IdAsignarCuestionarioModelo == item1.Value).FirstOrDefault();

                    List<AsignarComponenteGenerico> DataListaComponenteGenerico = new List<AsignarComponenteGenerico>();
                    foreach (var item2 in db.Sp_ConsultarAsignarComponenteGenericoDeUnAsignarCuestionarioModelo(item.IdCabeceraVersionModelo,item1.Value).ToList())
                    {
                        AsignarComponenteGenerico DataAsignarComponenteGenerico = new AsignarComponenteGenerico();
                        DataAsignarComponenteGenerico = listaAsignarComponenteGenerico.Where(p => p.IdAsignarComponenteGenerico == item2.Value).FirstOrDefault();

                        List<DescripcionComponente> DataListaDescripcionComponente = new List<DescripcionComponente>();
                        foreach (var item3 in db.Sp_ConsultarDescripcionComponenteDeUnAsignarComponenteGenerico(item.IdCabeceraVersionModelo,item2.Value).ToList())
                        {
                            DescripcionComponente DataDescripcionComponente = new DescripcionComponente();
                            DataDescripcionComponente = ListaDescripcionCompoennte.Where(p => p.IdDescripcionComponente == item3.Value).FirstOrDefault();
                            DataListaDescripcionComponente.Add(DataDescripcionComponente);
                        }
                        DataListaComponenteGenerico.Add(DataAsignarComponenteGenerico);
                    }
                    DataAsignarCuestionarioModelo.AsignarComponenteGenerico = DataListaComponenteGenerico;
                    DataListaCuestionarioModelo.Add(DataAsignarCuestionarioModelo);
                }
                DataModeloGenerico.AsignarCuestionarioModelo = DataListaCuestionarioModelo;
                _lista.Add(new CabeceraVersionModelo() {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    ModeloGenerico = DataModeloGenerico,
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Version = item.VersionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    ModeloPublicado = ListaModeloPublicado.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString()).FirstOrDefault(),
                });
            }
            return _lista.Where(p=> _seguridad.DesEncriptar(p.IdModeloGenerico) == _idModeloGenerico.ToString()).OrderBy(e=>e.Version).ToList();
        }
        public void EliminarCabeceraVersionModelo(int _idCabeceraVersionModelo)
        {
            foreach (var item in db.Sp_VersionamientoModeloConsultar().Where(p=>p.IdCabeceraVersionamientoModelo == _idCabeceraVersionModelo).ToList())
            {
                db.Sp_VersionamientoModeloEliminar(item.IdVersionamientoModelo);
            }
            db.Sp_CabeceraVersionModeloEliminar(_idCabeceraVersionModelo);
        }
        public List<CabeceraVersionModelo> ConsultarVersionCaracterizacion(int _idModeloGenerico)
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloPublicado = _objModeloPublicado.ConsultarModeloPublicado();
            var ListaModeloGenerico = ConsultarModeloGenerico();
            var ListaAsignarCuestionarioModelo = _objAsignarCuestionarioModelo.ConsultarAsignarCuestionarioModelo();
            var ListaAsignarComponenteGenerico = _objAsignarComponenteGenerico.ConsultarAsignarComponenteGenerico();
            var ListaDescripcionComponente = _objDescripcionComponente.ConsultarDescripcionComponente();
            var ListaVersionamientoModelo = _objVersionamientoModelo.ConsultarVersionamientoModelo();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar().Where(p=>p.MODELOGENERICO_IdModeloGenerico == _idModeloGenerico).ToList())
            {
                ModeloGenerico DataModeloGenericoConsulta = new ModeloGenerico();
                DataModeloGenericoConsulta = ListaModeloGenerico.Where(p => p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).FirstOrDefault();
                DataModeloGenericoConsulta.AsignarCuestionarioModelo = null;
                List<AsignarComponenteGenerico> dataListaAsignarComponenteGenerico = new List<AsignarComponenteGenerico>();
                foreach (var item1 in db.Sp_ConsultarAsignarComponenteGenericoDeUnaVersion(item.IdCabeceraVersionModelo))
                {
                    AsignarComponenteGenerico dataAsignarComponenteGenerico = new AsignarComponenteGenerico();
                    dataAsignarComponenteGenerico = ListaAsignarComponenteGenerico.Where(p => p.IdAsignarComponenteGenerico == item1.Value).FirstOrDefault();
                    List<DescripcionComponente> dataListaDescripcionComponente = new List<DescripcionComponente>();
                    foreach (var item2 in db.Sp_ConsultarDescripcionComponenteDeUnAsignarComponenteGenerico(item.IdCabeceraVersionModelo, dataAsignarComponenteGenerico.IdAsignarComponenteGenerico))
                    {
                        DescripcionComponente dataDescripcionComponente = new DescripcionComponente();
                        dataDescripcionComponente = ListaDescripcionComponente.Where(p => p.IdDescripcionComponente == item2.Value).FirstOrDefault();
                        dataDescripcionComponente.AsignarDescripcionComponenteTipoElemento.VersionamientoModelo = ListaVersionamientoModelo.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString() && _seguridad.DesEncriptar(p.IdDescripcionComponenteTipoElemento) == dataDescripcionComponente.AsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento.ToString()).FirstOrDefault();
                        dataListaDescripcionComponente.Add(dataDescripcionComponente);
                    }
                    dataAsignarComponenteGenerico.DescripcionComponente = dataListaDescripcionComponente;
                    dataListaAsignarComponenteGenerico.Add(dataAsignarComponenteGenerico);
                }
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    Version = item.VersionCabeceraVersionModelo,
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p=>p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    ModeloPublicado = ListaModeloPublicado.Where(p=>_seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString()).FirstOrDefault(),
                    AsignarComponenteGenerico = dataListaAsignarComponenteGenerico,
                    ModeloGenerico = DataModeloGenericoConsulta,
                });
            }
            return _lista;
        }
        public List<CabeceraVersionModelo> ConsultarModeloGenericoVersionesSinpPublicar()
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloPublicado = _objModeloPublicado.ConsultarModeloPublicado();
            var ListaModeloGenerico = ConsultarModeloGenerico();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar())
            {
                ModeloGenerico DataModeloGenericoConsulta = new ModeloGenerico();
                DataModeloGenericoConsulta = ListaModeloGenerico.Where(p => p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).FirstOrDefault();
                DataModeloGenericoConsulta.AsignarCuestionarioModelo = null;
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    Version = item.VersionCabeceraVersionModelo,
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    ModeloPublicado = ListaModeloPublicado.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString()).FirstOrDefault(),
                    ModeloGenerico = DataModeloGenericoConsulta,
                });
            }
            return _lista.Where(p => p.ModeloPublicado == null && p.ModeloGenerico.Estado == true).GroupBy(a => a.IdModeloGenerico).Select(grp => grp.First()).ToList();
        }
        public List<CabeceraVersionModelo> ConsultarVersioneSinPublicarDeUnModeloGenerico(int _idModeloGenerico)
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloPublicado = _objModeloPublicado.ConsultarModeloPublicado();
            var ListaModeloGenerico = ConsultarModeloGenerico();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar().Where(p=>p.MODELOGENERICO_IdModeloGenerico == _idModeloGenerico).ToList())
            {
                ModeloGenerico DataModeloGenericoConsulta = new ModeloGenerico();
                DataModeloGenericoConsulta = ListaModeloGenerico.Where(p => p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).FirstOrDefault();
                DataModeloGenericoConsulta.AsignarCuestionarioModelo = null;
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    Version = item.VersionCabeceraVersionModelo,
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    ModeloPublicado = ListaModeloPublicado.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString()).FirstOrDefault(),
                    ModeloGenerico = DataModeloGenericoConsulta,
                });
            }
            return _lista.Where(p => p.ModeloPublicado == null).ToList();
        }
        public List<CabeceraVersionModelo> ConsultarVersionesCaracterizacionPublicadas()
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloPublicado = _objModeloPublicado.ConsultarModeloPublicado();
            var ListaModeloGenerico = ConsultarModeloGenerico();
            var ListaAsignarCuestionarioModelo = _objAsignarCuestionarioModelo.ConsultarAsignarCuestionarioModelo();
            var ListaAsignarComponenteGenerico = _objAsignarComponenteGenerico.ConsultarAsignarComponenteGenerico();
            var ListaDescripcionComponente = _objDescripcionComponente.ConsultarDescripcionComponente();
            var ListaVersionamientoModelo = _objVersionamientoModelo.ConsultarVersionamientoModelo();
            var ListaAsignarModeloGenericoParroquia = _objAsignarModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquia();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar())
            {
                ModeloPublicado DataModeloPublicado = new ModeloPublicado();
                DataModeloPublicado = ListaModeloPublicado.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString()).FirstOrDefault();
                if (DataModeloPublicado!=null)
                {
                    DataModeloPublicado.CantidadAsignarParroquiaActivos = ListaAsignarModeloGenericoParroquia.Where(p => _seguridad.DesEncriptar(p.IdModeloPublicado) == DataModeloPublicado.IdModeloPublicado.ToString() && p.Estado == true).ToList().Count;
                }

                ModeloGenerico DataModeloGenericoConsulta = new ModeloGenerico();
                DataModeloGenericoConsulta = ListaModeloGenerico.Where(p => p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).FirstOrDefault();
                DataModeloGenericoConsulta.AsignarCuestionarioModelo = null;
                List<AsignarComponenteGenerico> dataListaAsignarComponenteGenerico = new List<AsignarComponenteGenerico>();
                foreach (var item1 in db.Sp_ConsultarAsignarComponenteGenericoDeUnaVersion(item.IdCabeceraVersionModelo))
                {
                    AsignarComponenteGenerico dataAsignarComponenteGenerico = new AsignarComponenteGenerico();
                    dataAsignarComponenteGenerico = ListaAsignarComponenteGenerico.Where(p => p.IdAsignarComponenteGenerico == item1.Value).FirstOrDefault();
                    List<DescripcionComponente> dataListaDescripcionComponente = new List<DescripcionComponente>();
                    foreach (var item2 in db.Sp_ConsultarDescripcionComponenteDeUnAsignarComponenteGenerico(item.IdCabeceraVersionModelo, dataAsignarComponenteGenerico.IdAsignarComponenteGenerico))
                    {
                        DescripcionComponente dataDescripcionComponente = new DescripcionComponente();
                        dataDescripcionComponente = ListaDescripcionComponente.Where(p => p.IdDescripcionComponente == item2.Value).FirstOrDefault();
                        dataDescripcionComponente.AsignarDescripcionComponenteTipoElemento.VersionamientoModelo = ListaVersionamientoModelo.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString() && _seguridad.DesEncriptar(p.IdDescripcionComponenteTipoElemento) == dataDescripcionComponente.AsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento.ToString()).FirstOrDefault();
                        dataListaDescripcionComponente.Add(dataDescripcionComponente);
                    }
                    dataAsignarComponenteGenerico.DescripcionComponente = dataListaDescripcionComponente;
                    dataListaAsignarComponenteGenerico.Add(dataAsignarComponenteGenerico);
                }
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    Version = item.VersionCabeceraVersionModelo,
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    ModeloPublicado = DataModeloPublicado,
                    AsignarComponenteGenerico = dataListaAsignarComponenteGenerico,
                    ModeloGenerico = DataModeloGenericoConsulta,
                });
            }
            return _lista.Where(p=>p.ModeloPublicado!=null).ToList();
        }
        public CabeceraVersionModelo ConsultarParroquiaDeUnaVersionesCaracterizacionPublicadas(int _idModeloPublicado)
        {
            var ListaAsignacionTipoUsuario = _objAsignarUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloPublicado = _objModeloPublicado.ConsultarModeloPublicado();
            var ListaModeloGenerico = ConsultarModeloGenerico();
            var ListaAsignarModeloGenericoParroquia = _objAsignarModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquia();
            var ListaDescripcionComponente = _objDescripcionComponente.ConsultarDescripcionComponente();
            var ListaAsignarComponenteGenerico = _objAsignarComponenteGenerico.ConsultarAsignarComponenteGenerico();
            List<CabeceraVersionModelo> _lista = new List<CabeceraVersionModelo>();
            foreach (var item in db.Sp_CabeceraVersionModeloConsultar())
            {
                ModeloGenerico DataModeloGenericoConsulta = new ModeloGenerico();
                DataModeloGenericoConsulta = ListaModeloGenerico.Where(p => p.IdModeloGenerico == item.MODELOGENERICO_IdModeloGenerico).FirstOrDefault();
                DataModeloGenericoConsulta.AsignarCuestionarioModelo = null;
                ModeloPublicado DataModeloPublicado = new ModeloPublicado();
                DataModeloPublicado = ListaModeloPublicado.Where(p => _seguridad.DesEncriptar(p.IdCabeceraVersionModelo) == item.IdCabeceraVersionModelo.ToString()).FirstOrDefault();
                if (DataModeloPublicado!=null)
                {
                    List<AsignarModeloGenericoParroquia> dataListaAsignarModeloGenericoParroquia = new List<AsignarModeloGenericoParroquia>();
                    foreach (var item1 in ListaAsignarModeloGenericoParroquia.Where(p => _seguridad.DesEncriptar(p.IdModeloPublicado) == DataModeloPublicado.IdModeloPublicado.ToString()).ToList())
                    {
                        //AsignarModeloGenericoParroquia dataAsignarModeloGenericoParroquia = new AsignarModeloGenericoParroquia();
                        dataListaAsignarModeloGenericoParroquia.Add(item1);
                    }
                    DataModeloPublicado.AsignarModeloGenericoParroquia = dataListaAsignarModeloGenericoParroquia;
                }

                List<AsignarComponenteGenerico> dataListaAsignarComponenteGenerico = new List<AsignarComponenteGenerico>();
                foreach (var item1 in db.Sp_ConsultarAsignarComponenteGenericoDeUnaVersion(item.IdCabeceraVersionModelo))
                {
                    AsignarComponenteGenerico dataAsignarComponenteGenerico = new AsignarComponenteGenerico();
                    dataAsignarComponenteGenerico = ListaAsignarComponenteGenerico.Where(p => p.IdAsignarComponenteGenerico == item1.Value).FirstOrDefault();
                    List<DescripcionComponente> dataListaDescripcionComponente = new List<DescripcionComponente>();
                    foreach (var item2 in db.Sp_ConsultarDescripcionComponenteDeUnAsignarComponenteGenerico(item.IdCabeceraVersionModelo, dataAsignarComponenteGenerico.IdAsignarComponenteGenerico))
                    {
                        DescripcionComponente dataDescripcionComponente = new DescripcionComponente();
                        dataDescripcionComponente = ListaDescripcionComponente.Where(p => p.IdDescripcionComponente == item2.Value).FirstOrDefault();
                        dataListaDescripcionComponente.Add(dataDescripcionComponente);
                    }
                    dataAsignarComponenteGenerico.DescripcionComponente = dataListaDescripcionComponente;
                    dataListaAsignarComponenteGenerico.Add(dataAsignarComponenteGenerico);
                }
                _lista.Add(new CabeceraVersionModelo()
                {
                    IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                    IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.MODELOGENERICO_IdModeloGenerico.ToString()),
                    Version = item.VersionCabeceraVersionModelo,
                    Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                    FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                    Estado = item.EstadoCabeceraVersionModelo,
                    Utilizado = item.UtilizadoCabeceraVersionModelo,
                    AsignarUsuarioTipoUsuario = ListaAsignacionTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    ModeloPublicado = DataModeloPublicado,
                    ModeloGenerico = DataModeloGenericoConsulta,
                });
            }
            return _lista.Where(p => p.ModeloPublicado != null && p.ModeloPublicado.IdModeloPublicado == _idModeloPublicado).FirstOrDefault();
        }
    }
}
