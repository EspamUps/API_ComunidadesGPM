using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoOpcionDosMatriz
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int InsertarOpcionDosMatriz(OpcionDosMatriz _objOpcionDosMatriz)
        {
            try
            {
                return int.Parse(db.Sp_OpcionDosMatrizInsertar(_objOpcionDosMatriz.Descripcion, _objOpcionDosMatriz.Estado).Select(c => c.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void EliminarOpcionDosMatriz(int _idOpcionDosMatriz)
        {
            db.Sp_OpcionDosMatrizEliminar(_idOpcionDosMatriz);
        }     
    }
}