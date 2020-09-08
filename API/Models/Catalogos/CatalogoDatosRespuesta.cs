using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoDatosRespuesta
    {
        DatosRespuesta objDatosRespuesta = new DatosRespuesta();
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public string  InsertarDatosRespuesta(DatosRespuesta _objDatos)
        {
            try
            {
                string msj="";
                foreach (var item in db.Sp_InserDatosRespuesta(_objDatos.datos, _objDatos.DescripcionRespuestaAbierta, Convert.ToInt32(_objDatos.IdAsignarEncuestado), Convert.ToInt32(_objDatos.IdPregunta)))
                {
                     msj = item.ToString();
   
                }
                return msj;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
           
        }
    }
}