using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarCuestionarioModelo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoCuestionarioGenerico _objCuestionarioGenerico = new CatalogoCuestionarioGenerico();
        CatalogoComponente _objComponentes = new CatalogoComponente();
        CatalogoAsignarComponenteGenerico _objAsignarComponenteGenerico = new CatalogoAsignarComponenteGenerico();
        CatalogoCuestionarioPublicado _objCuestionarioPublicado = new CatalogoCuestionarioPublicado();
        public int InsertarAsignarCuestionarioModelo(AsignarCuestionarioModelo _objAsignarCuestionarioModelo)
        {
            try
            {
                foreach (var item in db.Sp_AsignarCuestionarioModeloInsertar(int.Parse(_objAsignarCuestionarioModelo.IdModeloGenerico), int.Parse(_objAsignarCuestionarioModelo.IdCuestionarioPublicado),int.Parse(_objAsignarCuestionarioModelo.IdAsignarUsuarioTipoUsuario)))
                {
                    _objAsignarCuestionarioModelo.IdAsignarCuestionarioModelo = item.IdAsignarCuestionarioModelo;
                }
                return _objAsignarCuestionarioModelo.IdAsignarCuestionarioModelo;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<AsignarCuestionarioModelo> ConsultarAsignarCuestionarioModelo()
        {
            var listaCuestionarioGenerico = _objCuestionarioGenerico.ConsultarCuestionarioGenerico();
            var listaAsignarComponenteGenerico = _objAsignarComponenteGenerico.ConsultarAsignarComponenteGenerico();
            var listaComponentes = _objComponentes.ConsultarComponente();
            var listaCuestionarioPublicado = _objCuestionarioPublicado.ConsultarCuestionarioPublicado();
            List<AsignarCuestionarioModelo> _lista = new List<AsignarCuestionarioModelo>();
            foreach (var item in db.Sp_AsignarCuestionarioModeloConsultar())
            {
                CuestionarioPublicado DataCuestionarioPublicado = listaCuestionarioPublicado.Where(p => p.IdCuestionarioPublicado == item.IdCuestionarioPublicado).FirstOrDefault();
                int idCuestionario = db.Sp_CuestionarioGenericoDeUnCuestionarioPublicado(item.IdCuestionarioPublicado).Select(e => e.Value).FirstOrDefault();
                DataCuestionarioPublicado.CuestionarioGenerico = listaCuestionarioGenerico.Where(p => p.IdCuestionarioGenerico == idCuestionario).FirstOrDefault();
                //List<CuestionarioGenerico> ListaCuestionario = new List<CuestionarioGenerico>();
                //ListaCuestionario = listaCuestionarioGenerico.Where(p => p.IdCuestionarioGenerico == item.IdCuestionarioGenerico).ToList();
                //ListaCuestionario = listaCuestionarioGenerico.ToList();
                //if (ListaCuestionario.Count > 0)
                //{
                //    var ListaAsignarComponenteGenericoPorCuestionarioModelo = listaAsignarComponenteGenerico.Where(p => _seguridad.DesEncriptar(p.IdAsignarCuestionarioModelo) == item.IdAsignarCuestionarioModelo.ToString()).ToList();
                //    for (int i = 0; i <ListaAsignarComponenteGenericoPorCuestionarioModelo.Count ; i++)
                //    {
                //        ListaAsignarComponenteGenericoPorCuestionarioModelo[i].Componente = listaComponentes.Where(p => p.IdComponente.ToString() == _seguridad.DesEncriptar(ListaAsignarComponenteGenericoPorCuestionarioModelo[i].IdComponente.ToString())).FirstOrDefault();
                //    }
                //    for (int i = 0; i < ListaCuestionario.Count ; i++)
                //    {
                //        ListaCuestionario[i].AsignarComponenteGenerico = ListaAsignarComponenteGenericoPorCuestionarioModelo.OrderBy(e=>e.Orden).ToList();
                //    }
                //}
                _lista.Add(new AsignarCuestionarioModelo()
                {
                    IdAsignarCuestionarioModelo = item.IdAsignarCuestionarioModelo,
                    IdAsignarCuestionarioModeloEncriptado = _seguridad.Encriptar(item.IdAsignarCuestionarioModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                    IdCuestionarioPublicado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuario.ToString()),
                    FechaAsignacion = item.FechaAsignacion,
                    Utilizado = item.AsignarCuestionarioModeloUtilizado,
                    CuestionarioPublicado = DataCuestionarioPublicado,
                    AsignarComponenteGenerico = listaAsignarComponenteGenerico.Where(p=>_seguridad.DesEncriptar(p.IdAsignarCuestionarioModelo) == item.IdAsignarCuestionarioModelo.ToString()).ToList()
                    //CuestionarioGenerico = ListaCuestionario,
                });
            }
            return _lista;
        }
        public List<AsignarCuestionarioModelo> ConsultarAsignarCuestionarioModeloPorId(int _idAsignarCuestionarioModelo)
        {
            List<AsignarCuestionarioModelo> _lista = new List<AsignarCuestionarioModelo>();
            foreach (var item in db.Sp_AsignarCuestionarioModeloConsultar().Where(m => m.IdAsignarCuestionarioModelo == _idAsignarCuestionarioModelo).ToList())
            {
                _lista.Add(new AsignarCuestionarioModelo()
                {
                    IdAsignarCuestionarioModelo = item.IdAsignarCuestionarioModelo,
                    IdAsignarCuestionarioModeloEncriptado = _seguridad.Encriptar(item.IdAsignarCuestionarioModelo.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                    IdCuestionarioPublicado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuario.ToString()),
                    FechaAsignacion = item.FechaAsignacion,
                    Utilizado = item.AsignarCuestionarioModeloUtilizado,
                });
            }
            return _lista;
        }
        public List<Componente> ConsultarComponenteDeUnModeloGenerico(AsignarCuestionarioModelo _objAsignarCuestionarioModelo)
        {
            List<Componente> _lista = new List<Componente>();
            var listaComponentes = _objComponentes.ConsultarComponente();
            foreach (var item in db.Sp_ComponentesDeUnModeloGenerico(int.Parse(_objAsignarCuestionarioModelo.IdCuestionarioPublicado),int.Parse(_objAsignarCuestionarioModelo.IdModeloGenerico)))
            {
                _lista.Add(listaComponentes.Where(p => p.IdComponente == item.Value).FirstOrDefault());
            }
            return _lista;
        }
    }
}