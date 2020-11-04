using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;

namespace API.Models.Catalogos
{
    public class CatalogoCoordenadas 
    {

        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int ModificarCoordenadas(string idComunidad, string latitud, string longitud)
        {
            try
            {
                var estado = db.Sp_CoordenasComunidadInsert(latitud, longitud, Convert.ToInt32(idComunidad));
                return estado = 1; 
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Coordenadas> ConsultarCanton(float latitud, float longitud)
        {
            List<Coordenadas> _lista = new List<Coordenadas>();
            foreach (var item in db.Sp_CargarCoordenadasDeComunidadesPorParroquia(latitud, longitud))
            {
                _lista.Add(new Coordenadas(_seguridad.Encriptar(Convert.ToString(item.IdComunidad)),item.NombreComunidad,item.latitud, item.longitud));
               
            }
            return _lista;
        }
    }
}