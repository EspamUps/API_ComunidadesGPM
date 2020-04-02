using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarModeloGenericoParroquia
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoParroquia _objParroquia = new CatalogoParroquia();
        public int InsertarAsignarModeloGenericoParroquia(AsignarModeloGenericoParroquia _objAsignarModeloGenericoParroquia)
        {
            try
            {
                foreach (var item in db.Sp_AsignarModeloPublicadoParroquiaInsertar(int.Parse(_objAsignarModeloGenericoParroquia.IdModeloPublicado),int.Parse(_objAsignarModeloGenericoParroquia.IdParroquia)))
                {
                    _objAsignarModeloGenericoParroquia.IdAsignarModeloGenericoParroquia = item.IdAsignarModeloGenericoParroquia;
                }
                return _objAsignarModeloGenericoParroquia.IdAsignarModeloGenericoParroquia;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<AsignarModeloGenericoParroquia> ConsultarAsignarModeloGenericoParroquia()
        {
            var _listaParroquia = _objParroquia.ConsultarParroquia();
            List<AsignarModeloGenericoParroquia> _lista = new List<AsignarModeloGenericoParroquia>();
            foreach (var item in db.Sp_AsignarModeloPublicadoParroquiaConsultar())
            {
                _lista.Add(new AsignarModeloGenericoParroquia()
                {
                    IdAsignarModeloGenericoParroquia = item.IdAsignarModeloGenericoParroquia,
                    IdAsignarModeloGenericoParroquiaEncriptado = _seguridad.Encriptar(item.IdAsignarModeloGenericoParroquia.ToString()),
                    IdModeloPublicado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                    IdParroquia = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    Estado = item.Estado,
                    FechaAsignacion = item.FechaAsignacion,
                    Parroquia = _listaParroquia.Where(p=> p.IdParroquia == item.IdParroquia).FirstOrDefault()
                });
            }
            return _lista;
        }
        public List<AsignarModeloGenericoParroquia> ConsultarAsignarModeloGenericoParroquiaPorId(int _idAsignarModeloGenericoParroquia)
        {
            var _listaParroquia = _objParroquia.ConsultarParroquia();
            List<AsignarModeloGenericoParroquia> _lista = new List<AsignarModeloGenericoParroquia>();
            foreach (var item in db.Sp_AsignarModeloPublicadoParroquiaConsultar().Where(p=>p.IdAsignarModeloGenericoParroquia == _idAsignarModeloGenericoParroquia).ToList())
            {
                _lista.Add(new AsignarModeloGenericoParroquia()
                {
                    IdAsignarModeloGenericoParroquia = item.IdAsignarModeloGenericoParroquia,
                    IdAsignarModeloGenericoParroquiaEncriptado = _seguridad.Encriptar(item.IdAsignarModeloGenericoParroquia.ToString()),
                    IdModeloPublicado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                    IdParroquia = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    Estado = item.Estado,
                    FechaAsignacion = item.FechaAsignacion,
                    Parroquia = _listaParroquia.Where(p => p.IdParroquia == item.IdParroquia).FirstOrDefault()
                });
            }
            return _lista;
        }
        public void EliminarModeloGenericoParroquia(int _idModeloGenericoParroquia)
        {
            db.Sp_AsignarModeloPublicadoParroquiaEliminar(_idModeloGenericoParroquia);
        }
        public void HabilitarModeloGenericoParroquia(int _idModeloGenericoParroquia)
        {
            db.Sp_HabilitarAsignarModeloGenericoParroquia(_idModeloGenericoParroquia);
        }
        public void DesHabilitarModeloGenericoParroquia(int _idModeloGenericoParroquia)
        {
            db.Sp_DesHabilitarAsignarModeloGenericoParroquia(_idModeloGenericoParroquia);
        }
    }
}