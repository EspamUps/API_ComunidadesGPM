using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoVersionamientoPregunta
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarVersionamientoPregunta(VersionamientoPregunta _objVersionamientoPregunta )
        {
            try
            {
                return int.Parse(db.Sp_VersionamientoPreguntaInsertar(_objVersionamientoPregunta.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario,_objVersionamientoPregunta.Pregunta.IdPregunta,_objVersionamientoPregunta.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarVersionamientoPregunta(int _idVersionamientoPregunta)
        {
            db.Sp_VersionamientoPreguntaEliminar(_idVersionamientoPregunta);
        }
    }
}