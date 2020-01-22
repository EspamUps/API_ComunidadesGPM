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
        public void EliminarPersona(int _idPersona)
        {
            db.Sp_PersonaEliminar(_idPersona);
        }

        public List<Persona> ConsultarPersona() {
            List<Persona> lista = new List<Persona>();
            foreach (var item in db.Sp_PersonaConsultar())
            {
                lista.Add(new Persona()
                {
                    IdPersona = item.PERSONA_IdPersona,
                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                    PrimerNombre = item.PERSONA_PrimerNombre,
                    SegundoNombre = item.PERSONA_SegundoNombre,
                    PrimerApellido = item.PERSONA_PrimerApellido,
                    SegundoApellido = item.PERSONA_SegundoApellido,
                    NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                    Telefono = item.PERSONA_Telefono,
                    Direccion = item.PERSONA_Direccion,
                    Estado = item.PERSONA_Estado,
                    Utilizado = item.PERSONA_Utilizado,
                    Sexo = new Sexo()
                    {
                        IdSexo = item.SEXO_IdSexo,
                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                        Identificador = item.SEXO_Identificador,
                        Descripcion = item.SEXO_Descripcion,
                        Estado = item.SEXO_Estado,
                    },
                    TipoIdentificacion = new TipoIdentificacion()
                    {
                        IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                        Identificador = item.TIPOIDENTIFICACION_Identificador,
                        Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                        Estado = item.TIPOIDENTIFICACION_Estado,
                    },
                    Parroquia = new Parroquia()
                    {
                        IdParroquia = item.PARROQUIA_IdParroquia,
                        IdParroquiaEncriptado = _seguridad.Encriptar(item.PARROQUIA_IdParroquia.ToString()),
                        DescripcionParroquia = item.PARROQUIA_DescripcionParroquia,
                        CodigoParroquia = item.PARROQUIA_CodigoParroquia,
                        EstadoParroquia = item.PARROQUIA_EstadoParroquia,
                        NombreParroquia = item.PARROQUIA_NombreParroquia,
                        RutaLogoParroquia = item.PARROQUIA_RutaLogoParroquia,
                        Canton = new Canton()
                        {
                            IdCanton = item.CANTON_IdCanton,
                            IdCantonEncriptado = _seguridad.Encriptar(item.CANTON_IdCanton.ToString()),
                            CodigoCanton = item.CANTON_CodigoCanton,
                            DescripcionCanton = item.CANTON_DescripcionCanton,
                            NombreCanton = item.CANTON_NombreCanton,
                            RutaLogoCanton = item.CANTON_RutaLogoCanton,
                            EstadoCanton = item.CANTON_EstadoCanton,
                            Provincia = new Provincia()
                            {
                                IdProvincia = item.PROVINCIA_IdProvincia,
                                IdProvinciaEncriptado = _seguridad.Encriptar(item.PROVINCIA_IdProvincia.ToString()),
                                CodigoProvincia = item.PROVINCIA_CodigoProvincia,
                                DescripcionProvincia = item.PROVINCIA_DescripcionProvincia,
                                NombreProvincia = item.PROVINCIA_NombreProvincia,
                                RutaLogoProvincia = item.PROVINCIA_RutaLogoProvincia,
                                EstadoProvincia = item.PROVINCIA_EstadoProvincia
                            }
                        }
                    }

                });
            }
            return lista;
        }

        public List<Persona> ConsultarPersonaPorId(int _idPersona)
        {
            List<Persona> lista = new List<Persona>();
            foreach (var item in db.Sp_PersonaConsultar().Where(c=>c.PERSONA_IdPersona==_idPersona).ToList())
            {
                lista.Add(new Persona()
                {
                    IdPersona = item.PERSONA_IdPersona,
                    IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                    PrimerNombre = item.PERSONA_PrimerNombre,
                    SegundoNombre = item.PERSONA_SegundoNombre,
                    PrimerApellido = item.PERSONA_PrimerApellido,
                    SegundoApellido = item.PERSONA_SegundoApellido,
                    NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                    Telefono = item.PERSONA_Telefono,
                    Direccion = item.PERSONA_Direccion,
                    Estado = item.PERSONA_Estado,
                    Utilizado = item.PERSONA_Utilizado,
                    Sexo = new Sexo()
                    {
                        IdSexo = item.SEXO_IdSexo,
                        IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                        Identificador = item.SEXO_Identificador,
                        Descripcion = item.SEXO_Descripcion,
                        Estado = item.SEXO_Estado,
                    },
                    TipoIdentificacion = new TipoIdentificacion()
                    {
                        IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                        IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                        Identificador = item.TIPOIDENTIFICACION_Identificador,
                        Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                        Estado = item.TIPOIDENTIFICACION_Estado,
                    },
                    Parroquia = new Parroquia()
                    {
                        IdParroquia = item.PARROQUIA_IdParroquia,
                        IdParroquiaEncriptado = _seguridad.Encriptar(item.PARROQUIA_IdParroquia.ToString()),
                        DescripcionParroquia = item.PARROQUIA_DescripcionParroquia,
                        CodigoParroquia = item.PARROQUIA_CodigoParroquia,
                        EstadoParroquia = item.PARROQUIA_EstadoParroquia,
                        NombreParroquia = item.PARROQUIA_NombreParroquia,
                        RutaLogoParroquia = item.PARROQUIA_RutaLogoParroquia,
                        Canton = new Canton()
                        {
                            IdCanton = item.CANTON_IdCanton,
                            IdCantonEncriptado = _seguridad.Encriptar(item.CANTON_IdCanton.ToString()),
                            CodigoCanton = item.CANTON_CodigoCanton,
                            DescripcionCanton = item.CANTON_DescripcionCanton,
                            NombreCanton = item.CANTON_NombreCanton,
                            RutaLogoCanton = item.CANTON_RutaLogoCanton,
                            EstadoCanton = item.CANTON_EstadoCanton,
                            Provincia = new Provincia()
                            {
                                IdProvincia = item.PROVINCIA_IdProvincia,
                                IdProvinciaEncriptado = _seguridad.Encriptar(item.PROVINCIA_IdProvincia.ToString()),
                                CodigoProvincia = item.PROVINCIA_CodigoProvincia,
                                DescripcionProvincia = item.PROVINCIA_DescripcionProvincia,
                                NombreProvincia = item.PROVINCIA_NombreProvincia,
                                RutaLogoProvincia = item.PROVINCIA_RutaLogoProvincia,
                                EstadoProvincia = item.PROVINCIA_EstadoProvincia
                            }
                        }
                    }

                });
            }
            return lista;
        }

    }
}