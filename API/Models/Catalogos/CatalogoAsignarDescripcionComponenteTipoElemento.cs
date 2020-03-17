using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarDescripcionComponenteTipoElemento
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoTipoElemento _objTipoElemento = new CatalogoTipoElemento();

        public int InsertarAsignarDescripcionComponenteTipoElemento(AsignarDescripcionComponenteTipoElemento _objAsignarDescripcionComponenteTipoElemento)
        {
            try
            {
                foreach (var item in db.Sp_AsignarDescripcionComponenteTipoElementoInsertar(int.Parse(_objAsignarDescripcionComponenteTipoElemento.IdDescripcionComponente),int.Parse(_objAsignarDescripcionComponenteTipoElemento.IdTipoElemento), _objAsignarDescripcionComponenteTipoElemento.Obligatorio, _objAsignarDescripcionComponenteTipoElemento.Orden))
                {
                    _objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento = item.IdAsignarDescripcionComponenteTipoElemento;
                }
                return _objAsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<AsignarDescripcionComponenteTipoElemento> ConsultarAsignarDescripcionComponenteTipoElemento()
        {
            var ListaTipoElemento = _objTipoElemento.ConsultarTipoElemento();
            List<AsignarDescripcionComponenteTipoElemento> _lista = new List<AsignarDescripcionComponenteTipoElemento>();
            foreach (var item in db.Sp_AsignarDescripcionComponenteTipoElementoConsultar())
            {
                _lista.Add(new AsignarDescripcionComponenteTipoElemento()
                {
                    IdAsignarDescripcionComponenteTipoElemento = item.IdAsignarDescripcionComponenteTipoElemento,
                    IdAsignarDescripcionComponenteTipoElementoEncriptado = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                    IdDescripcionComponente = _seguridad.Encriptar(item.IdDescripcionComponente.ToString()),
                    IdTipoElemento = _seguridad.Encriptar(item.IdTipoElemento.ToString()),
                    Orden = item.Orden,
                    Obligatorio = item.Obligatorio,
                    TipoElemento = ListaTipoElemento.Where(p=>p.IdTipoElemento == item.IdTipoElemento).FirstOrDefault()
                });
            }
            return _lista;
        }

        public List<AsignarDescripcionComponenteTipoElemento> ConsultarAsignarDescripcionComponenteTipoElementoPorId(int _idAsignarDescripcionComponenteTipoElemento)
        {
            List<AsignarDescripcionComponenteTipoElemento> _lista = new List<AsignarDescripcionComponenteTipoElemento>();
            foreach (var item in db.Sp_AsignarDescripcionComponenteTipoElementoConsultar().Where(p=> p.IdAsignarDescripcionComponenteTipoElemento == _idAsignarDescripcionComponenteTipoElemento).ToList())
            {
                _lista.Add(new AsignarDescripcionComponenteTipoElemento()
                {
                    IdAsignarDescripcionComponenteTipoElemento = item.IdAsignarDescripcionComponenteTipoElemento,
                    IdAsignarDescripcionComponenteTipoElementoEncriptado = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                    IdDescripcionComponente = _seguridad.Encriptar(item.IdDescripcionComponente.ToString()),
                    IdTipoElemento = _seguridad.Encriptar(item.IdTipoElemento.ToString()),
                    Orden = item.Orden,
                    Obligatorio = item.Obligatorio,
                });
            }
            return _lista;
        }

        public void eliminarAsignarDescripcionComponenteTipoElemento(int _idAsignarDescripcionComponenteTipoElemento)
        {
            db.Sp_AsignarDescripcionComponenteTipoElementoEliminar(_idAsignarDescripcionComponenteTipoElemento);
        }


    }
}