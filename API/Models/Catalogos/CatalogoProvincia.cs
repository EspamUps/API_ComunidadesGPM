using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoProvincia
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Provincia> ConsultarProvincia()
        {
            List<Provincia> _lista = new List<Provincia>();
            foreach (var item in db.Sp_ProvinciaConsultar())
            {
                _lista.Add(new Provincia()
                {
                    IdProvincia = item.IdProvincia,
                    IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                    CodigoProvincia = item.CodigoProvincia,
                    DescripcionProvincia = item.DescripcionProvincia,
                    NombreProvincia = item.NombreProvincia,
                    RutaLogoProvincia = item.RutaLogoProvincia,
                    EstadoProvincia = item.EstadoProvincia,
                    Utilizado=item.UtilizadoProvincia
                });
            }
            return _lista;
        }

        public List<Provincia> ConsultarProvinciaPorId(int _idProvincia)
        {
            List<Provincia> _lista = new List<Provincia>();
            foreach (var item in db.Sp_ProvinciaConsultar().Where(c => c.IdProvincia == _idProvincia).ToList())
            {
                _lista.Add(new Provincia()
                {
                    IdProvincia = item.IdProvincia,
                    IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                    CodigoProvincia = item.CodigoProvincia,
                    DescripcionProvincia = item.DescripcionProvincia,
                    NombreProvincia = item.NombreProvincia,
                    RutaLogoProvincia = item.RutaLogoProvincia,
                    EstadoProvincia = item.EstadoProvincia,
                    Utilizado = item.UtilizadoProvincia
                });
            }
            return _lista;
        }

        public int ModificarProvincia(Provincia _objProvincia)
        {
            try
            {
                db.Sp_ProvinciaModificar(_objProvincia.IdProvincia, _objProvincia.CodigoProvincia, _objProvincia.NombreProvincia, _objProvincia.DescripcionProvincia, _objProvincia.RutaLogoProvincia, _objProvincia.EstadoProvincia);
                return _objProvincia.IdProvincia;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int InsertarProvincia(Provincia _objProvincia)
        {
            try
            {
                return int.Parse(db.Sp_ProvinciaInsertar(_objProvincia.CodigoProvincia, _objProvincia.NombreProvincia, _objProvincia.DescripcionProvincia, _objProvincia.RutaLogoProvincia, _objProvincia.EstadoProvincia).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarProvincia(int _idProvincia)
        {
            db.Sp_ProvinciaEliminar(_idProvincia);
        }
    }
}