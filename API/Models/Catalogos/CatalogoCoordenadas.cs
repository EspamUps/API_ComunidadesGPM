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
        public int ModificarCoordenadas(Coordenadas coordenadas)
        {
            try
            {
                var estado = db.Sp_CoordenasComunidadInsert(coordenadas.latitud, coordenadas.longitud, Convert.ToInt32(coordenadas.id));
                return estado = 1; 
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Coordenadas> ConsultarCanton(string parroquia)
        {
            List<Coordenadas> _lista = new List<Coordenadas>();
            foreach (var item in db.Sp_CargarCoordenadasDeComunidadesPorParroquia(parroquia))
            {
                _lista.Add(new Coordenadas(item.latitud,item.longitud, item.NombreCanton, item.NombreParroquia, item.NombreComunidad,_seguridad.Encriptar(Convert.ToString(item.IdComunidad))));
               
            }
            return _lista;
        }
    }
}