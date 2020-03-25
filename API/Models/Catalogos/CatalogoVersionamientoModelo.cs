using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoVersionamientoModelo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarVersionamientoModelo(VersionamientoModelo _objVersionamientoModelo)
        {
            try
            {
                return int.Parse(db.Sp_VersionamientoModeloInsertar(int.Parse(_objVersionamientoModelo.IdCabeceraVersionModelo),int.Parse(_objVersionamientoModelo.IdDescripcionComponenteTipoElemento),true).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<VersionamientoModelo> ConsultarVersionamientoModelo()
        {
            List<VersionamientoModelo> _lista = new List<VersionamientoModelo>();
            foreach (var item in db.Sp_VersionamientoModeloConsultar())
            {
                _lista.Add(new VersionamientoModelo()
                {
                    IdVersionamientoModelo = item.IdVersionamientoModelo,
                    IdVersionamientoModeloEncriptado = _seguridad.Encriptar(item.IdVersionamientoModelo.ToString()),
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionamientoModelo.ToString()),
                    IdDescripcionComponenteTipoElemento = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                    Estado = item.Estado,
                });
            }
            return _lista;
        }

        public List<VersionamientoModelo> ConsultarVersionamientoModeloPorId(int _idVersionamientoModelo)
        {
            List<VersionamientoModelo> _lista = new List<VersionamientoModelo>();
            foreach (var item in db.Sp_VersionamientoModeloConsultar().Where(p=> p.IdVersionamientoModelo == _idVersionamientoModelo).ToList())
            {
                _lista.Add(new VersionamientoModelo()
                {
                    IdVersionamientoModelo = item.IdVersionamientoModelo,
                    IdVersionamientoModeloEncriptado = _seguridad.Encriptar(item.IdVersionamientoModelo.ToString()),
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionamientoModelo.ToString()),
                    IdDescripcionComponenteTipoElemento = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                    Estado = item.Estado,
                });
            }
            return _lista;
        }

        public List<VersionamientoModelo> ConsultarVersionamientoModeloPorVersion()
        {
            var ListaVersionamientoModelo = db.Sp_VersionamientoModeloConsultar();
            List<VersionamientoModelo> _lista = new List<VersionamientoModelo>();
            foreach (var item in ListaVersionamientoModelo)
            {
                _lista.Add(new VersionamientoModelo()
                {
                    IdVersionamientoModelo = item.IdVersionamientoModelo,
                    IdVersionamientoModeloEncriptado = _seguridad.Encriptar(item.IdVersionamientoModelo.ToString()),
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionamientoModelo.ToString()),
                    IdDescripcionComponenteTipoElemento = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                    Estado = item.Estado,
                });
            }
            return _lista;
        }

        public void EliminarVersionamientoModelo(int _idVersionamientoModelo)
        {
            db.Sp_VersionamientoModeloEliminar(_idVersionamientoModelo);
        }
    }
}