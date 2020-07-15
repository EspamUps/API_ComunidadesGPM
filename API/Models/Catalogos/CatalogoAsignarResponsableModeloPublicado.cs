using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System.IO;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarResponsableModeloPublicado
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoPresidenteJuntaParroquial _objPresidenteJuntaParroquia = new CatalogoPresidenteJuntaParroquial();
        public int InsertarAsignarResponsableModeloPublicado(AsignarResponsableModeloPublicado _objAsignar)
        {
            try
            {
                return int.Parse(db.Sp_AsignarResponsableModeloPublicadoInsertar(_objAsignar.Parroquia.IdParroquia,_objAsignar.FechaAsignacion,_objAsignar.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario,_objAsignar.ModeloPublicado.IdModeloPublicado,_objAsignar.FechaInicio,_objAsignar.FechaFin,_objAsignar.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarAsignarResponsableModeloPublicado(AsignarResponsableModeloPublicado _objAsignar)
        {
            try
            {
               db.Sp_AsignarResponsableModeloPublicadoModificar(_objAsignar.IdAsignarResponsableModeloPublicado,_objAsignar.Parroquia.IdParroquia, _objAsignar.FechaAsignacion, _objAsignar.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario, _objAsignar.ModeloPublicado.IdModeloPublicado, _objAsignar.FechaInicio, _objAsignar.FechaFin, _objAsignar.Estado);
                return _objAsignar.IdAsignarResponsableModeloPublicado;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarAsignarResponsableModeloPublicado(int _idAsignarResponsableModeloPublicado)
        {
            db.Sp_AsignarResponsableModeloPublicadoEliminar(_idAsignarResponsableModeloPublicado);
        }
        public List<AsignarResponsableModeloPublicado> ConsultarAsignarResponsableModeloPublicado()
        {
            List<AsignarResponsableModeloPublicado> _lista = new List<AsignarResponsableModeloPublicado>();
            foreach (var item in db.Sp_AsignarResponsableModeloPublicadoConsultar())
            {
                _lista.Add(new AsignarResponsableModeloPublicado()
                {
                    IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                    IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                    Estado = item.EstadoAsignarResponsableModeloPublicado,
                    FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                    FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                    FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
                    Representante = item.RepresentantePresidenteJuntaParroquial,
                    //Utilizado = item.UtilizadoAsignarResponsableModeloPublicado,
                    Parroquia = new Parroquia()
                        {
                            IdParroquia = item.IdParroquia,
                            IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                            DescripcionParroquia = item.DescripcionParroquia,
                            CodigoParroquia = item.CodigoParroquia,
                            EstadoParroquia = item.EstadoParroquia,
                            NombreParroquia = item.NombreParroquia,
                            RutaLogoParroquia = item.RutaLogoParroquia,
                            Canton = new Canton()
                            {
                                IdCanton = item.IdCanton,
                                IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                                CodigoCanton = item.CodigoCanton,
                                DescripcionCanton = item.DescripcionCanton,
                                NombreCanton = item.NombreCanton,
                                RutaLogoCanton = item.RutaLogoCanton,
                                EstadoCanton = item.EstadoCanton,
                                Provincia = new Provincia()
                                {
                                    IdProvincia = item.IdProvincia,
                                    IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                                    CodigoProvincia = item.CodigoProvincia,
                                    DescripcionProvincia = item.DescripcionProvincia,
                                    NombreProvincia = item.NombreProvincia,
                                    RutaLogoProvincia = item.RutaLogoProvincia,
                                    EstadoProvincia = item.EstadoProvincia
                                }
                            }
                        },
                    AsignarUsuarioTipoUsuario=new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIO_IdUsuario,
                            Correo = item.USUARIO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                            Estado = item.USUARIO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                IdPersona = item.PERSONA_IdPersona,
                                PrimerNombre = item.PERSONA_PrimerNombre,
                                SegundoNombre = item.PERSONA_SegundoNombre,
                                PrimerApellido = item.PERSONA_PrimerApellido,
                                SegundoApellido = item.PERSONA_SegundoApellido,
                                NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                Telefono = item.PERSONA_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONA_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                    IdSexo = item.SEXO_IdSexo,
                                    Identificador = item.SEXO_Identificador,
                                    Descripcion = item.SEXO_Descripcion,
                                    Estado = item.SEXO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACION_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                    Estado = item.TIPOIDENTIFICACION_Estado,
                                }

                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                            Identificador = item.TIPOUSUARIO_Identificador,
                            Descripcion = item.TIPOUSUARIO_Descripcion,
                            Estado = item.TIPOUSUARIO_Estado
                        },
                    },
                    ModeloPublicado = new ModeloPublicado()
                    {
                        IdModeloPublicado=item.IdModeloPublicado,
                        IdModeloPublicadoEncriptado=_seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                        Estado=item.EstadoModeloPublicado,
                        FechaPublicacion=item.FechaPublicacionModeloPublicado,
                        CabeceraVersionModelo=new CabeceraVersionModelo()
                        {
                            IdCabeceraVersionModelo=item.IdCabeceraVersionModelo,
                            IdCabeceraVersionModeloEncriptado=_seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                            Caracteristica=item.CaracteristicaCabeceraVersionModelo,
                            Estado=item.EstadoCabeceraVersionModelo,
                            FechaCreacion=item.FechaCreacionCabeceraVersionModelo,
                            Version=item.VersionCabeceraVersionModelo,
                            ModeloGenerico = new ModeloGenerico()
                            {
                                IdModeloGenerico=item.IdModeloGenerico,
                                IdModeloGenericoEncriptado=_seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                Descripcion=item.DescripcionModeloGenerico,
                                Estado=item.EstadoModeloGenerico,
                                Nombre=item.NombreModeloGenerico                                
                            }
                        }
                    }
                });
            }
            return _lista.GroupBy(a => a.IdAsignarResponsableModeloPublicadoEncriptado).Select(grp => grp.First()).ToList(); ;
        }
        public List<AsignarResponsableModeloPublicado> ConsultarAsignarResponsableModeloPublicadoPorIdModeloPublicado(int _idModeloPublicado)
        {
            List<AsignarResponsableModeloPublicado> _lista = new List<AsignarResponsableModeloPublicado>();
            var listaJuntaParroquia = _objPresidenteJuntaParroquia.ConsultarPresidenteJuntaParroquial();
            foreach (var item in db.Sp_AsignarResponsableModeloPublicadoConsultarPorModeloPublicado(_idModeloPublicado))
            {
                PresidenteJuntaParroquial Presidente = new PresidenteJuntaParroquial();
                Presidente = listaJuntaParroquia.Where(p => p.Parroquia.IdParroquia == item.IdParroquia && Convert.ToDateTime(p.FechaSalida).ToShortDateString() == "01/01/0001").FirstOrDefault();
                string NombrePresidente = "";
                if(Presidente != null)
                {
                    NombrePresidente = Presidente.Representante;
                }
                _lista.Add(new AsignarResponsableModeloPublicado()
                {
                    IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                    IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                    Estado = item.EstadoAsignarResponsableModeloPublicado,
                    FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                    FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                    FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
                    Representante = NombrePresidente,
                    Utilizado = item.UtilizadoAsignarResponsableModeloPublicado,
                    Parroquia = new Parroquia()
                        {
                            IdParroquia = item.IdParroquia,
                            IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                            DescripcionParroquia = item.DescripcionParroquia,
                            CodigoParroquia = item.CodigoParroquia,
                            EstadoParroquia = item.EstadoParroquia,
                            NombreParroquia = item.NombreParroquia,
                            RutaLogoParroquia = item.RutaLogoParroquia,
                            Canton = new Canton()
                            {
                                IdCanton = item.IdCanton,
                                IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                                CodigoCanton = item.CodigoCanton,
                                DescripcionCanton = item.DescripcionCanton,
                                NombreCanton = item.NombreCanton,
                                RutaLogoCanton = item.RutaLogoCanton,
                                EstadoCanton = item.EstadoCanton,
                                Provincia = new Provincia()
                                {
                                    IdProvincia = item.IdProvincia,
                                    IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                                    CodigoProvincia = item.CodigoProvincia,
                                    DescripcionProvincia = item.DescripcionProvincia,
                                    NombreProvincia = item.NombreProvincia,
                                    RutaLogoProvincia = item.RutaLogoProvincia,
                                    EstadoProvincia = item.EstadoProvincia
                                }
                            }
                        },
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIO_IdUsuario,
                            Correo = item.USUARIO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                            Estado = item.USUARIO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                IdPersona = item.PERSONA_IdPersona,
                                PrimerNombre = item.PERSONA_PrimerNombre,
                                SegundoNombre = item.PERSONA_SegundoNombre,
                                PrimerApellido = item.PERSONA_PrimerApellido,
                                SegundoApellido = item.PERSONA_SegundoApellido,
                                NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                Telefono = item.PERSONA_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONA_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                    IdSexo = item.SEXO_IdSexo,
                                    Identificador = item.SEXO_Identificador,
                                    Descripcion = item.SEXO_Descripcion,
                                    Estado = item.SEXO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACION_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                    Estado = item.TIPOIDENTIFICACION_Estado,
                                }

                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                            Identificador = item.TIPOUSUARIO_Identificador,
                            Descripcion = item.TIPOUSUARIO_Descripcion,
                            Estado = item.TIPOUSUARIO_Estado
                        },
                    },
                    ModeloPublicado = new ModeloPublicado()
                    {
                        IdModeloPublicado = item.IdModeloPublicado,
                        IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                        Estado = item.EstadoModeloPublicado,
                        FechaPublicacion = item.FechaPublicacionModeloPublicado,
                        CabeceraVersionModelo = new CabeceraVersionModelo()
                        {
                            IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                            IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                            Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                            Estado = item.EstadoCabeceraVersionModelo,
                            FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                            Version = item.VersionCabeceraVersionModelo,
                            ModeloGenerico = new ModeloGenerico()
                            {
                                IdModeloGenerico = item.IdModeloGenerico,
                                IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                Descripcion = item.DescripcionModeloGenerico,
                                Estado = item.EstadoModeloGenerico,
                                Nombre = item.NombreModeloGenerico
                            }
                        }
                    }
                });
            }
            return _lista.GroupBy(a => a.IdAsignarResponsableModeloPublicadoEncriptado).Select(grp => grp.First()).ToList();
        }
        public List<AsignarResponsableModeloPublicado> ConsultarAsignarResponsableModeloPublicadoPorId(int _idAsignarResponsableModeloPublicado)
        {
            List<AsignarResponsableModeloPublicado> _lista = new List<AsignarResponsableModeloPublicado>();
            foreach (var item in db.Sp_AsignarResponsableModeloPublicadoConsultarPorId(_idAsignarResponsableModeloPublicado))
            {
                _lista.Add(new AsignarResponsableModeloPublicado()
                {
                    IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                    IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                    Estado = item.EstadoAsignarResponsableModeloPublicado,
                    FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                    FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                    FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
                    Utilizado = item.UtilizadoAsignarResponsableModeloPublicado,
                    Representante = item.RepresentantePresidenteJuntaParroquial,
                    Parroquia = new Parroquia()
                        {
                            IdParroquia = item.IdParroquia,
                            IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                            DescripcionParroquia = item.DescripcionParroquia,
                            CodigoParroquia = item.CodigoParroquia,
                            EstadoParroquia = item.EstadoParroquia,
                            NombreParroquia = item.NombreParroquia,
                            RutaLogoParroquia = item.RutaLogoParroquia,
                            Canton = new Canton()
                            {
                                IdCanton = item.IdCanton,
                                IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                                CodigoCanton = item.CodigoCanton,
                                DescripcionCanton = item.DescripcionCanton,
                                NombreCanton = item.NombreCanton,
                                RutaLogoCanton = item.RutaLogoCanton,
                                EstadoCanton = item.EstadoCanton,
                                Provincia = new Provincia()
                                {
                                    IdProvincia = item.IdProvincia,
                                    IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                                    CodigoProvincia = item.CodigoProvincia,
                                    DescripcionProvincia = item.DescripcionProvincia,
                                    NombreProvincia = item.NombreProvincia,
                                    RutaLogoProvincia = item.RutaLogoProvincia,
                                    EstadoProvincia = item.EstadoProvincia
                                }
                            }
                        },
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIO_IdUsuario,
                            Correo = item.USUARIO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                            Estado = item.USUARIO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                IdPersona = item.PERSONA_IdPersona,
                                PrimerNombre = item.PERSONA_PrimerNombre,
                                SegundoNombre = item.PERSONA_SegundoNombre,
                                PrimerApellido = item.PERSONA_PrimerApellido,
                                SegundoApellido = item.PERSONA_SegundoApellido,
                                NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                Telefono = item.PERSONA_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONA_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                    IdSexo = item.SEXO_IdSexo,
                                    Identificador = item.SEXO_Identificador,
                                    Descripcion = item.SEXO_Descripcion,
                                    Estado = item.SEXO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACION_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                    Estado = item.TIPOIDENTIFICACION_Estado,
                                }

                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                            Identificador = item.TIPOUSUARIO_Identificador,
                            Descripcion = item.TIPOUSUARIO_Descripcion,
                            Estado = item.TIPOUSUARIO_Estado
                        },
                    },
                    ModeloPublicado = new ModeloPublicado()
                    {
                        IdModeloPublicado = item.IdModeloPublicado,
                        IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                        Estado = item.EstadoModeloPublicado,
                        FechaPublicacion = item.FechaPublicacionModeloPublicado,
                        CabeceraVersionModelo = new CabeceraVersionModelo()
                        {
                            IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                            IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                            Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                            Estado = item.EstadoCabeceraVersionModelo,
                            FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                            Version = item.VersionCabeceraVersionModelo,
                            ModeloGenerico = new ModeloGenerico()
                            {
                                IdModeloGenerico = item.IdModeloGenerico,
                                IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                Descripcion = item.DescripcionModeloGenerico,
                                Estado = item.EstadoModeloGenerico,
                                Nombre = item.NombreModeloGenerico
                            }
                        }
                    }
                });
            }
            return _lista;
        }
        public List<AsignarResponsableModeloPublicado> ConsultarAsignarResponsableModeloPublicadoPorParroquia(int _idParroquia)
        {
            List<AsignarResponsableModeloPublicado> _lista = new List<AsignarResponsableModeloPublicado>();
            foreach (var item in db.Sp_AsignarResponsableModeloPublicadoConsultarPorParroquia(_idParroquia))
            {
                _lista.Add(new AsignarResponsableModeloPublicado()
                {
                    IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                    IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                    Estado = item.EstadoAsignarResponsableModeloPublicado,
                    FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                    FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                    FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
                    Representante = item.RepresentantePresidenteJuntaParroquial,
                    //Utilizado = item.UtilizadoAsignarResponsableModeloPublicado,
                    Parroquia = new Parroquia()
                    {
                        IdParroquia = item.IdParroquia,
                        IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquia.ToString()),
                        DescripcionParroquia = item.DescripcionParroquia,
                        CodigoParroquia = item.CodigoParroquia,
                        EstadoParroquia = item.EstadoParroquia,
                        NombreParroquia = item.NombreParroquia,
                        RutaLogoParroquia = item.RutaLogoParroquia,
                        Canton = new Canton()
                        {
                            IdCanton = item.IdCanton,
                            IdCantonEncriptado = _seguridad.Encriptar(item.IdCanton.ToString()),
                            CodigoCanton = item.CodigoCanton,
                            DescripcionCanton = item.DescripcionCanton,
                            NombreCanton = item.NombreCanton,
                            RutaLogoCanton = item.RutaLogoCanton,
                            EstadoCanton = item.EstadoCanton,
                            Provincia = new Provincia()
                            {
                                IdProvincia = item.IdProvincia,
                                IdProvinciaEncriptado = _seguridad.Encriptar(item.IdProvincia.ToString()),
                                CodigoProvincia = item.CodigoProvincia,
                                DescripcionProvincia = item.DescripcionProvincia,
                                NombreProvincia = item.NombreProvincia,
                                RutaLogoProvincia = item.RutaLogoProvincia,
                                EstadoProvincia = item.EstadoProvincia
                            }
                        }
                    },
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIO_IdAsignarUsuarioTipoUsuario.ToString()),
                        Estado = item.ASIGNARUSUARIOTIPOUSUARIO_Estado,
                        Usuario = new Usuario()
                        {
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.USUARIO_IdUsuario.ToString()),
                            IdUsuario = item.USUARIO_IdUsuario,
                            Correo = item.USUARIO_Correo,
                            ClaveEncriptada = _seguridad.Encriptar(item.USUARIO_Clave.ToString()),
                            Estado = item.USUARIO_Estado,
                            Persona = new Persona()
                            {
                                IdPersonaEncriptado = _seguridad.Encriptar(item.PERSONA_IdPersona.ToString()),
                                IdPersona = item.PERSONA_IdPersona,
                                PrimerNombre = item.PERSONA_PrimerNombre,
                                SegundoNombre = item.PERSONA_SegundoNombre,
                                PrimerApellido = item.PERSONA_PrimerApellido,
                                SegundoApellido = item.PERSONA_SegundoApellido,
                                NumeroIdentificacion = item.PERSONA_NumeroIdentificacion,
                                Telefono = item.PERSONA_Telefono,
                                Direccion = item.PERSONA_Direccion,
                                Estado = item.PERSONA_Estado,
                                Sexo = new Sexo()
                                {
                                    IdSexoEncriptado = _seguridad.Encriptar(item.SEXO_IdSexo.ToString()),
                                    IdSexo = item.SEXO_IdSexo,
                                    Identificador = item.SEXO_Identificador,
                                    Descripcion = item.SEXO_Descripcion,
                                    Estado = item.SEXO_Estado,
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.TIPOIDENTIFICACION_IdTipoIdentificacion.ToString()),
                                    IdTipoIdentificacion = item.TIPOIDENTIFICACION_IdTipoIdentificacion,
                                    Identificador = item.TIPOIDENTIFICACION_Identificador,
                                    Descripcion = item.TIPOIDENTIFICACION_Descripcion,
                                    Estado = item.TIPOIDENTIFICACION_Estado,
                                }

                            }
                        },
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.TIPOUSUARIO_IdTipoUsuario,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                            Identificador = item.TIPOUSUARIO_Identificador,
                            Descripcion = item.TIPOUSUARIO_Descripcion,
                            Estado = item.TIPOUSUARIO_Estado
                        },
                    },
                    ModeloPublicado = new ModeloPublicado()
                    {
                        IdModeloPublicado = item.IdModeloPublicado,
                        IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                        Estado = item.EstadoModeloPublicado,
                        FechaPublicacion = item.FechaPublicacionModeloPublicado,
                        CabeceraVersionModelo = new CabeceraVersionModelo()
                        {
                            IdCabeceraVersionModelo = item.IdCabeceraVersionModelo,
                            IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                            Caracteristica = item.CaracteristicaCabeceraVersionModelo,
                            Estado = item.EstadoCabeceraVersionModelo,
                            FechaCreacion = item.FechaCreacionCabeceraVersionModelo,
                            Version = item.VersionCabeceraVersionModelo,
                            ModeloGenerico = new ModeloGenerico()
                            {
                                IdModeloGenerico = item.IdModeloGenerico,
                                IdModeloGenericoEncriptado = _seguridad.Encriptar(item.IdModeloGenerico.ToString()),
                                Descripcion = item.DescripcionModeloGenerico,
                                Estado = item.EstadoModeloGenerico,
                                Nombre = item.NombreModeloGenerico
                            }
                        }
                    }
                });
            }
            return _lista.GroupBy(a => a.IdAsignarResponsableModeloPublicado).Select(grp => grp.First()).ToList();
        }
        public void HabilitarAsignarResponsableModeloPublicado(int _idAsignarResponsableModeloPublicado)
        {
            db.Sp_HabilitarAsignarResponsableModeloPublicado(_idAsignarResponsableModeloPublicado);
        }
        public void DesHabilitarAsignarResponsableModeloPublicado(int _idAsignarResponsableModeloPublicado)
        {
            db.Sp_DesHabilitarAsignarResponsableModeloPublicado(_idAsignarResponsableModeloPublicado);
        }
        public string[] obtenerCarpeta()
        {
            string GetDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string[] dirs = Directory.GetFiles(GetDirectory + @"\Imagenes");
            for (int i = 0; i < dirs.Length; i++)
            {
                var bytes = File.ReadAllBytes(dirs[i]);
                var b64String = Convert.ToBase64String(bytes);
                dirs[i] = "data:image/"+ System.IO.Path.GetExtension(dirs[i]).Replace(".","") + ";base64," + b64String;
            }
            return dirs;
        }
    }
}