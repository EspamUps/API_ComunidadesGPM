using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoDescripcionComponente
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoAsignarDescripcionComponenteTipoElemento _objAsignarDescripcionComponenteTipoElemento = new CatalogoAsignarDescripcionComponenteTipoElemento();
        public int InsertarDescripcionComponente(DescripcionComponente _obDescripcionComponente)
        {
            try
            {
                foreach (var item in db.Sp_DescripcionComponenteInsertar(int.Parse(_obDescripcionComponente.IdAsignarComponenteGenerico), _obDescripcionComponente.Obligatorio, _obDescripcionComponente.Orden))
                {
                    _obDescripcionComponente.IdDescripcionComponente = item.IdDescripcionComponente;
                }
                return _obDescripcionComponente.IdDescripcionComponente;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<DescripcionComponente> ConsultarDescripcionComponente()
        {
            var ListaAsignarDescripcionComponenteTipoElemento = _objAsignarDescripcionComponenteTipoElemento.ConsultarAsignarDescripcionComponenteTipoElemento();
            List<DescripcionComponente> _lista = new List<DescripcionComponente>();
            foreach (var item in db.Sp_DescripcionComponenteConsultar())
            {
                _lista.Add(new DescripcionComponente()
                {
                    IdDescripcionComponente = item.IdDescripcionComponente,
                    IdDescripcionComponenteEncriptado = _seguridad.Encriptar(item.IdDescripcionComponente.ToString()),
                    IdAsignarComponenteGenerico = _seguridad.Encriptar(item.IdAsignarComponenteGenerico.ToString()),
                    Obligatorio = item.Obligatorio,
                    Orden = item.Orden,
                    Utilizado = item.DescripcionComponenteUtilizado,
                    AsignarDescripcionComponenteTipoElemento = ListaAsignarDescripcionComponenteTipoElemento.Where(p=> _seguridad.DesEncriptar(p.IdDescripcionComponente) == item.IdDescripcionComponente.ToString()).FirstOrDefault()
                });
            }
            return _lista;
        }
        public List<DescripcionComponente> ConsultarDescripcionComponentePorId(int _idDescripcionComponente)
        {
            List<DescripcionComponente> _lista = new List<DescripcionComponente>();
            foreach (var item in db.Sp_DescripcionComponenteConsultar().Where(p=> p.IdDescripcionComponente == _idDescripcionComponente).ToList())
            {
                _lista.Add(new DescripcionComponente()
                {
                    IdDescripcionComponente = item.IdDescripcionComponente,
                    IdDescripcionComponenteEncriptado = _seguridad.Encriptar(item.IdDescripcionComponente.ToString()),
                    IdAsignarComponenteGenerico = _seguridad.Encriptar(item.IdAsignarComponenteGenerico.ToString()),
                    Obligatorio = item.Obligatorio,
                    Orden = item.Orden,
                    Utilizado = item.DescripcionComponenteUtilizado,
                });
            }
            return _lista;
        }

        public void eliminarDescripcionComponente(int _idDescripcionComponente)
        {
            db.Sp_DescripcionComponenteEliminar(_idDescripcionComponente);
        }
    }
}