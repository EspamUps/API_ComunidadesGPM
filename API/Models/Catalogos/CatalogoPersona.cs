using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;


namespace API.Models.Catalogos
{
    public class CatalogoPersona
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        public int InsertarPersona(Persona objPersona) {
            try
            {
                return int.Parse(db.Sp_PersonaInsertar(
                        objPersona.PrimerNombre, 
                        objPersona.SegundoNombre, 
                        objPersona.PrimerApellido, 
                        objPersona.SegundoApellido, 
                        objPersona.NumeroIdentificacion, 
                        objPersona.TipoIdentificacion.IdTipoIdentificacion, 
                        objPersona.Telefono, 
                        objPersona.Sexo.IdSexo, 
                        objPersona.Parroquia.IdParroquia,
                        objPersona.Direccion,
                        objPersona.Estado
                    ).Select(x=>x.Value).ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarPersona(Persona objPersona)
        {
            try
            {
                db.Sp_PersonaModificar(
                        objPersona.IdPersona,
                        objPersona.PrimerNombre,
                        objPersona.SegundoNombre,
                        objPersona.PrimerApellido,
                        objPersona.SegundoApellido,
                        objPersona.NumeroIdentificacion,
                        objPersona.TipoIdentificacion.IdTipoIdentificacion,
                        objPersona.Telefono,
                        objPersona.Sexo.IdSexo,
                        objPersona.Parroquia.IdParroquia,
                        objPersona.Direccion
                 );
                return objPersona.IdPersona;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}