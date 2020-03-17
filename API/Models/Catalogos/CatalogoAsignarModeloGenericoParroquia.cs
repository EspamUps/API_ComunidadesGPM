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
        public int InsertarAsignarModeloGenericoParroquia(AsignarModeloGenericoParroquia _objAsignarModeloGenericoParroquia)
        {
            try
            {
                foreach (var item in db.Sp_AsignarModeloGenericoParroquiaInsertar(int.Parse(_objAsignarModeloGenericoParroquia.IdModeloGenerico),int.Parse(_objAsignarModeloGenericoParroquia.IdParroquia)))
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
            List<AsignarModeloGenericoParroquia> _lista = new List<AsignarModeloGenericoParroquia>();
            foreach (var item in db.SpAsignarModeloGenericoParroquiaConsultar())
            {
                _lista.Add(new AsignarModeloGenericoParroquia()
                {
                    IdAsignarModeloGenericoParroquia = item.IdAsignarModeloGenericoParroquia,
                    IdAsignarModeloGenericoParroquiaEncriptado = _seguridad.Encriptar(item.IdAsignarModeloGenericoParroquia.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                    IdParroquia = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    Estado = item.Estado,
                    FechaAsignacion = item.FechaAsignacion,
                });
            }
            return _lista;
        }
        public List<AsignarModeloGenericoParroquia> ConsultarAsignarModeloGenericoParroquiaPorId(int _idAsignarModeloGenericoParroquia)
        {
            List<AsignarModeloGenericoParroquia> _lista = new List<AsignarModeloGenericoParroquia>();
            foreach (var item in db.SpAsignarModeloGenericoParroquiaConsultar().Where(p=>p.IdAsignarModeloGenericoParroquia == _idAsignarModeloGenericoParroquia).ToList())
            {
                _lista.Add(new AsignarModeloGenericoParroquia()
                {
                    IdAsignarModeloGenericoParroquia = item.IdAsignarModeloGenericoParroquia,
                    IdAsignarModeloGenericoParroquiaEncriptado = _seguridad.Encriptar(item.IdAsignarModeloGenericoParroquia.ToString()),
                    IdModeloGenerico = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                    IdParroquia = _seguridad.Encriptar(item.IdParroquia.ToString()),
                    Estado = item.Estado,
                    FechaAsignacion = item.FechaAsignacion,
                });
            }
            return _lista;
        }
    }
}