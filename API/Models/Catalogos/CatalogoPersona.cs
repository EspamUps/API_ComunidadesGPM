using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoPersona
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
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
                    ).Select(x=>x.Value.ToString()).FirstOrDefault());
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
                        objPersona.Direccion,
                        objPersona.Estado
                 );
                return objPersona.IdPersona;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int EliminarPersona(Persona objPersona)
        {
            try
            {
                db.Sp_PersonaEliminar(
                        objPersona.IdPersona
                 );
                return objPersona.IdPersona;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Persona> ConsultarPersona() {
            List<Persona> lista = new List<Persona>();
            foreach (var item in db.Sp_PersonaConsultar())
            {
                lista.Add(new Persona() {
                        IdPersona               = item.PERSONA_IdPersona,
                        IdPersonaEncriptado     = _seguridad.Encriptar( item.PERSONA_IdPersona.ToString()),
                        PrimerNombre            = item.PERSONA_PrimerNombre,
                        SegundoNombre           = item.PERSONA_SegundoNombre,
                        PrimerApellido          = item.PERSONA_PrimerApellido,
                        SegundoApellido         = item.PERSONA_SegundoApellido,
                        NumeroIdentificacion    = item.PERSONA_NumeroIdentificacion,
                        Telefono                = item.PERSONA_Telefono,
                        Direccion               = item.PERSONA_Direccion,
                        Estado                  = item.PERSONA_Estado,
                        Utilizado               = item.PERSONA_Utilizado,
                        Sexo = new Sexo()
                        {
                            IdSexo              = item.SEXO_IdSexo,
                            IdSexoEncriptado    = _seguridad.Encriptar( item.SEXO_IdSexo.ToString()),
                            Identificador       = item.SEXO_Identificador,
                            Descripcion         = item.SEXO_Descripcion,
                            Estado              = item.SEXO_Estado,
                        },
                        TipoIdentificacion = new TipoIdentificacion()
                        {
                            IdTipoIdentificacion            = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                            IdTipoIdentificacionEncriptado  = _seguridad.Encriptar( item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                            Identificador                   = item.TIPOIDENTIFICACION_Identificador,
                            Descripcion                     = item.TIPOIDENTIFICACION_Descripcion,
                            Estado                          = item.TIPOIDENTIFICACION_Estado,
                        }

                });
            }
            return lista;
        }

    }
}