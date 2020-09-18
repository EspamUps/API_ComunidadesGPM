using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarComponenteGenerico
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoComponente _objComponentes = new CatalogoComponente();
        public int InsertarAsignarComponenteGenerico(AsignarComponenteGenerico _objAsignarComponenteGenerico)
        {
            try
            {
                foreach (var item in db.Sp_AsignarComponenteGenericoInsertar(int.Parse(_objAsignarComponenteGenerico.IdAsignarCuestionarioModelo), int.Parse(_objAsignarComponenteGenerico.IdComponente)))
                {
                    _objAsignarComponenteGenerico.IdAsignarComponenteGenerico = item.IdAsignarComponenteGenerico;
                }
                return _objAsignarComponenteGenerico.IdAsignarComponenteGenerico;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<AsignarComponenteGenerico> ConsultarAsignarComponenteGenerico()
        {
            //var ListaDescripcionComponente = _objDescripcionComponente.ConsultarDescripcionComponente();
            var listaComponentes = _objComponentes.ConsultarComponente();
            List<AsignarComponenteGenerico> _lista = new List<AsignarComponenteGenerico>();
            foreach (var item in db.Sp_AsignarComponenteGenericoConsultar())
            {
                Componente DataComponente = new Componente();
                DataComponente = listaComponentes.Where(p => p.IdComponente == item.IdComponente).FirstOrDefault();
                //DataComponente.DescripcionComponente = ListaDescripcionComponente.Where(p => _seguridad.DesEncriptar(p.IdAsignarComponenteGenerico) == item.IdAsignarComponenteGenerico.ToString()).ToList();
                _lista.Add(new AsignarComponenteGenerico()
                {
                    IdAsignarComponenteGenerico = item.IdAsignarComponenteGenerico,
                    IdAsignarComponenteGenericoEncriptado = _seguridad.Encriptar(item.IdAsignarComponenteGenerico.ToString()),
                    IdAsignarCuestionarioModelo = _seguridad.Encriptar(item.IdAsignarCuestionarioModelo.ToString()),
                    IdComponente = _seguridad.Encriptar(item.IdComponente.ToString()),
                    Orden = item.Orden,
                    Utilizado = item.AsignarComponenteGenericoUtilizado,
                    //DescripcionComponente = ListaDescripcionComponente.Where(p=> _seguridad.DesEncriptar(p.IdAsignarComponenteGenerico) == item.IdAsignarComponenteGenerico.ToString()).ToList(),
                    Componente = DataComponente
                });
            }
            return _lista;
        }
        public List<AsignarComponenteGenerico> ConsultarAsignarComponenteGenericoPorId(int _idAsignarComponenteGenerico)
        {
            List<AsignarComponenteGenerico> _lista = new List<AsignarComponenteGenerico>();
            foreach (var item in db.Sp_AsignarComponenteGenericoConsultar().Where(p => p.IdAsignarComponenteGenerico == _idAsignarComponenteGenerico).ToList())
            {
                _lista.Add(new AsignarComponenteGenerico()
                {
                    IdAsignarComponenteGenerico = item.IdAsignarComponenteGenerico,
                    IdAsignarCuestionarioModelo = _seguridad.Encriptar(item.IdAsignarCuestionarioModelo.ToString()),
                    IdComponente = _seguridad.Encriptar(item.IdComponente.ToString()),
                    Orden = item.Orden,
                    Utilizado = item.AsignarComponenteGenericoUtilizado,
                });
            }
            return _lista;
        }
        public List<AsignarComponenteGenerico> ConsultarAsignarComponenteGenericoPorIdDHBD(int _idAsignarComponenteGenerico)
        {
            List<AsignarComponenteGenerico> _lista = new List<AsignarComponenteGenerico>();
            foreach (var item in db.Sp_AsignarComponenteGenericoConsultarPorId(_idAsignarComponenteGenerico))
            {
                _lista.Add(new AsignarComponenteGenerico()
                {
                    IdAsignarComponenteGenerico = item.IdAsignarComponenteGenerico,
                    Orden = item.Orden,
                    Utilizado = item.AsignarComponenteGenericoUtilizado,
                    Estado = item.EstadoAsignarComponenteGenerico,
                    Componente = new Componente()
                    {
                        IdComponente = item.IdComponente,
                        IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString())
                    },
                    AsignarCuestionarioModelo = new AsignarCuestionarioModelo()
                    {
                        IdAsignarCuestionarioModelo = item.IdAsignarCuestionarioModelo,
                        IdAsignarCuestionarioModeloEncriptado = _seguridad.Encriptar(item.IdAsignarCuestionarioModelo.ToString()),
                        CuestionarioPublicado = new CuestionarioPublicado()
                        {
                            IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                            IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                            Estado = item.EstadoCuestionarioPublicado,
                            FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,
                            Periodo = new Periodo()
                            {
                                IdPeriodo = item.IdPeriodoCuestionarioPublicado,
                                IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodoCuestionarioPublicado.ToString()),
                            },
                            CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                            {
                                IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionarioCuestionarioPublicado,
                                IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionarioCuestionarioPublicado.ToString())
                            }
                        }
                    },
                });
            }
            return _lista;
        }
        public void EliminarAsignarComponenteGenerico(int _idAsignarComponenteGenerico)
        {
            var DataAsignarComponenteGenerico = ConsultarAsignarComponenteGenericoPorId(_idAsignarComponenteGenerico).FirstOrDefault();
            //var ListaDescripcionComponente = _objDescripcionComponente.ConsultarDescripcionComponente();
            //foreach (var item in ListaDescripcionComponente.Where(p => _seguridad.DesEncriptar(p.IdAsignarComponenteGenerico) == DataAsignarComponenteGenerico.IdAsignarComponenteGenerico.ToString()).ToList())
            //{

            //}
            db.Sp_AsignarComponenteGenericoEliminar(_idAsignarComponenteGenerico);
            var cantidadAsignarCuestionarioModelo = db.Sp_AsignarCuestionarioModeloConsultar().Where(p => p.IdAsignarCuestionarioModelo.ToString() == _seguridad.DesEncriptar(DataAsignarComponenteGenerico.IdAsignarCuestionarioModelo)).FirstOrDefault();
            if (cantidadAsignarCuestionarioModelo.AsignarCuestionarioModeloUtilizado == "0")
            {
                db.Sp_AsignarCuestionarioModeloEliminar(int.Parse(_seguridad.DesEncriptar(DataAsignarComponenteGenerico.IdAsignarCuestionarioModelo)));
            }
        }
        public bool SubirAsignarComponenteGenerico(AsignarComponenteGenerico _AsignarComponenteGenerico)
        {
            try
            {
                db.sp_AsignarComponenteGenericoSubir(_AsignarComponenteGenerico.IdAsignarComponenteGenerico, _AsignarComponenteGenerico.Orden);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}