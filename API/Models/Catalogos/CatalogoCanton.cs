using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoCanton
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Canton> ConsultarCanton()
        {
            List<Canton> _lista = new List<Canton>();
            foreach (var item in db.Sp_CantonConsultar())
            {
                _lista.Add(new Canton()
                {
                    IdCanton = item.IdCanton,
                    IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                    CodigoCanton = item.CodigoCanton,
                    DescripcionCanton = item.DescripcionCanton,
                    NombreCanton = item.NombreCanton,
                    RutaLogoCanton = item.RutaLogoCanton,
                    EstadoCanton = item.EstadoCanton,
                    Utilizado = item.UtilizadoCanton,
                    Provincia= new Provincia()
                    {
                        IdProvincia = item.IdProvincia,
                        IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                        CodigoProvincia = item.CodigoProvincia,
                        DescripcionProvincia = item.DescripcionProvincia,
                        NombreProvincia = item.NombreProvincia,
                        RutaLogoProvincia = item.RutaLogoProvincia,
                        EstadoProvincia = item.EstadoProvincia
                    }
                });
            }
            return _lista;
        }
    }
}