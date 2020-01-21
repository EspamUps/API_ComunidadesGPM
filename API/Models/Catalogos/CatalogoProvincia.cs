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
                    EstadoProvincia = item.EstadoProvincia
                });
            }
            return _lista;
        }
    }
}