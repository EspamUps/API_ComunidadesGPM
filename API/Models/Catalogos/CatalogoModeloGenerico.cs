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
        CatalogoCabeceraVersionModelo _objVersionamientoModelo = new CatalogoCabeceraVersionModelo();
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
            var _ListaVersionamientoModelo = _objVersionamientoModelo.ConsultarCabeceraVersionModelo();
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
                    //ModeloGenericoVersionadoUtilizado = item.ModeloGenericoVersionamientoUtilizado,
                    NumeroVersionesSinPublicar = _ListaVersionamientoModelo.Where(p=> _seguridad.DesEncriptar(p.IdModeloGenerico) == item.IdModeloGenerico.ToString() && p.Utilizado == "0").ToList().Count,
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
                    Utilizado = item.ModeloGenericoUtilizado,
                    //ModeloGenericoVersionadoUtilizado = item.ModeloGenericoVersionamientoUtilizado,
                });
            }
            return _lista;
        }
        public void EliminarModeloGenerico(int _idModeloGenerico)
        {
            foreach (var item in db.Sp_AsignarCuestionarioModeloConsultar().Where(p=>p.IdModeloGenerico == _idModeloGenerico).ToList())
            {
                foreach (var item1 in db.Sp_AsignarComponenteGenericoConsultar().Where(p=>p.IdAsignarCuestionarioModelo == item.IdAsignarCuestionarioModelo).ToList())
                {
                    foreach (var item2 in db.Sp_DescripcionComponenteConsultar().Where(p=>p.IdAsignarComponenteGenerico == item1.IdAsignarComponenteGenerico).ToList())
                    {
                        foreach (var item3 in db.Sp_AsignarDescripcionComponenteTipoElementoConsultar().Where(p=>p.IdDescripcionComponente == item2.IdDescripcionComponente).ToList())
                        {
                            db.Sp_AsignarDescripcionComponenteTipoElementoEliminar(item3.IdAsignarDescripcionComponenteTipoElemento);
                        }
                        db.Sp_DescripcionComponenteEliminar(item2.IdDescripcionComponente);
                    }
                    db.Sp_AsignarComponenteGenericoEliminar(item1.IdAsignarComponenteGenerico);
                }
                db.Sp_AsignarCuestionarioModeloEliminar(item.IdAsignarCuestionarioModelo);
            }
            //db.Sp_ModeloGenericoEliminar(_idModeloGenerico);
        }

        
    }
}