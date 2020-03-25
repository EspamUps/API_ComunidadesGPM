using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace API.Models.Catalogos
{
    public class CatalogoModeloPublicado
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoPeriodo _objPeriodo = new CatalogoPeriodo();
        CatalogoAsignarUsuarioTipoUsuario _objUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();
        CatalogoAsignarModeloGenericoParroquia _objModeloGenericoParroquia = new CatalogoAsignarModeloGenericoParroquia();
        public int InsertarModeloPublicado(ModeloPublicado _objModeloPublicado)
        {
            try
            {
                foreach (var item in db.Sp_CabeceraModeloPublicadoInsertar(int.Parse(_objModeloPublicado.IdCabeceraVersionModelo),int.Parse(_objModeloPublicado.IdPeriodo),int.Parse(_objModeloPublicado.IdAsignarUsuarioTipoUsuario)))
                {
                    _objModeloPublicado.IdModeloPublicado = item.IdModeloPublicado;
                }
                return _objModeloPublicado.IdModeloPublicado;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void EliminarModeloPublicado(int _idModeloPublicado)
        {
            db.Sp_CabeceraModeloPublicadoEliminar(_idModeloPublicado);
        }

        public List<ModeloPublicado> ConsultarModeloPublicado()
        {
            var ListaPeriodos = _objPeriodo.ConsultarPeriodo();
            var ListaUsuarioTipoUsuario = _objUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloGenericoParroquia = _objModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquia();
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoConsultar())
            {
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicado = item.IdModeloPublicado,
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                    FechaPublicacion = item.FechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.Estado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = ListaPeriodos.Where(p=>p.IdPeriodo == item.IdPeriodo).FirstOrDefault(),
                    AsignarUsuarioTipoUsuario = ListaUsuarioTipoUsuario.Where(p=>p.IdAsignarUsuarioTipoUsuario == item.IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    AsignarModeloGenericoParroquia = ListaModeloGenericoParroquia.Where(p=>_seguridad.DesEncriptar(p.IdModeloPublicado) == item.IdModeloPublicado.ToString()).ToList()
                });
            }
            return _lista;
        }

        public List<ModeloPublicado> ConsultarModeloPublicadoPorId(int _idModeloPublicado)
        {
            var ListaPeriodos = _objPeriodo.ConsultarPeriodo();
            var ListaUsuarioTipoUsuario = _objUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloGenericoParroquia = _objModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquia();
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoConsultar().Where(p=>p.IdModeloPublicado == _idModeloPublicado).ToList())
            {
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicado = item.IdModeloPublicado,
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                    FechaPublicacion = item.FechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.Estado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = ListaPeriodos.Where(p => p.IdPeriodo == item.IdPeriodo).FirstOrDefault(),
                    AsignarUsuarioTipoUsuario = ListaUsuarioTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    AsignarModeloGenericoParroquia = ListaModeloGenericoParroquia.Where(p => _seguridad.DesEncriptar(p.IdModeloPublicado) == item.IdModeloPublicado.ToString()).ToList()
                });
            }
            return _lista;
        }

    }
}