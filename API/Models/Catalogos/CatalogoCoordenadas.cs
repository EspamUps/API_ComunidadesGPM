using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;


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
    }
}