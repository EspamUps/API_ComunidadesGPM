using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoModeloGenerico
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        CatalogoAsignarCuestionarioModelo _objAsignarCuestionarioModelo = new CatalogoAsignarCuestionarioModelo();
        Seguridad _seguridad = new Seguridad();
        public int InsertarModeloGenerico(ModeloGenerico _objModeloGenerico)
        {
            try
            {
                foreach (var item in db.Sp_ModeloGenericoInsertar(_objModeloGenerico.Nombre.ToUpper(), _objModeloGenerico.Descripcion))
                {
                    _objModeloGenerico.IdModeloGenerico = item.IdModeloGenerico;
                    _objModeloGenerico.Nombre = item.Nombre;
                    _objModeloGenerico.Descripcion = item.Descripcion;
                }
                return _objModeloGenerico.IdModeloGenerico;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<ModeloGenerico> ConsultarModeloGenerico()
        {
            var _listaAsignarCuestionarioModelo = _objAsignarCuestionarioModelo.ConsultarAsignarCuestionarioModelo();
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
                    Utilizado = item.ModeloGenericoUtilizado,
                    AsignarCuestionarioModelo = _listaAsignarCuestionarioModelo.Where(p=> _seguridad.DesEncriptar(p.IdModeloGenerico) == item.IdModeloGenerico.ToString()).ToList()
                });
            }
            return _lista;
        }
        public List<ModeloGenerico> ConsultarModeloGenericoPorId(int _idModeloGenerico)
        {
            List<ModeloGenerico> _lista = new List<ModeloGenerico>();
            foreach (var item in db.Sp_ModeloGenericoConsultar().Where(m => m.IdModeloGenerico == _idModeloGenerico).ToList())
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
    }
}