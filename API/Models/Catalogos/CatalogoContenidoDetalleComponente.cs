using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoContenidoDetalleComponente
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarContenidoDetalleComponente(ContenidoDetalleComponente _objContenidoDetalleComponente)
        {
            try
            {
                return int.Parse(db.Sp_ContenidoDetalleComponenteInsertar(_objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacion, _objContenidoDetalleComponente.Contenido, _objContenidoDetalleComponente.FechaRegistro, _objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponente, _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario, _objContenidoDetalleComponente.EstadoDecision, _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.IdAsignarUsuarioTipoUsuario, _objContenidoDetalleComponente.FechaDecision, _objContenidoDetalleComponente.ObservacionDecision, _objContenidoDetalleComponente.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int ModificarContenidoDetalleComponente(ContenidoDetalleComponente _objContenidoDetalleComponente)
        {
            try
            {
                db.Sp_ContenidoDetalleComponenteModificar(_objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacion, _objContenidoDetalleComponente.CabeceraCaracterizacion.IdCabeceraCaracterizacion, _objContenidoDetalleComponente.Contenido, _objContenidoDetalleComponente.FechaRegistro, _objContenidoDetalleComponente.DescripcionComponente.IdDescripcionComponente, _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioAutor.IdAsignarUsuarioTipoUsuario, _objContenidoDetalleComponente.EstadoDecision, _objContenidoDetalleComponente.AsignarUsuarioTipoUsuarioDecision.IdAsignarUsuarioTipoUsuario, _objContenidoDetalleComponente.FechaDecision, _objContenidoDetalleComponente.ObservacionDecision, _objContenidoDetalleComponente.Estado);
                return _objContenidoDetalleComponente.IdContenidoDetalleComponenteCaracterizacion;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void EliminarContenidoDetalleComponente(int _idContenidoDetalleComponente)
        {
            db.Sp_ContenidoDetalleComponenteEliminar(_idContenidoDetalleComponente);
        }
        public List<ContenidoDetalleComponente> ConsultarContenidoDetalleComponente()
        {
            List<ContenidoDetalleComponente> _lista = new List<ContenidoDetalleComponente>();
            foreach (var item in db.Sp_ContenidoDetalleComponenteConsultar())
            {
                _lista.Add(new ContenidoDetalleComponente()
                {
                    IdContenidoDetalleComponenteCaracterizacion = item.IdContentidoDetalleComponeteCaracterizacion,
                    IdContenidoDetalleComponenteCaracterizacionEncriptado = _seguridad.Encriptar(item.IdContentidoDetalleComponeteCaracterizacion.ToString()),
                    Contenido = item.ContenidoContentidoDetalleComponente,
                    Estado = item.EstadoContentidoDetalleComponente,
                    FechaRegistro = item.FechaRegistroContentidoDetalleComponente,
                    EstadoDecision=item.EstadoDecisionContentidoDetalleComponente,
                    FechaDecision=item.FechaDesicionContentidoDetalleComponente,
                    ObservacionDecision=item.ObservacionDecisionContentidoDetalleComponente,
                    DescripcionComponente = new DescripcionComponente()
                    {
                        IdDescripcionComponente=item.IdDescripcionComponente,
                        Obligatorio=item.ObligatorioDescripcionComponente,
                        Orden=item.OrdenDescripcionComponente,
                        AsignarComponenteGenerico =new AsignarComponenteGenerico()
                        {
                            IdAsignarComponenteGenerico=item.IdAsignarComponenteGenericoDescripcionComponente,
                            IdAsignarComponenteGenericoEncriptado = _seguridad.Encriptar(item.IdAsignarComponenteGenericoDescripcionComponente.ToString())
                        }
                    },
                    AsignarUsuarioTipoUsuarioAutor = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.IdAsignarUsuarioTipoUsuarioAutor,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioAutor.ToString()),
                        Estado = item.EstadoAsignarUsuarioTipoUsuarioAutor,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor.ToString())
                        },
                        Usuario = new Usuario()
                        {
                            IdUsuario = item.IdUsuarioUsuarioAutor,
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.IdUsuarioUsuarioAutor.ToString()),
                            Persona = new Persona()
                            {
                                IdPersona = item.IdPersonaAutor,
                                IdPersonaEncriptado = _seguridad.Encriptar(item.IdPersonaAutor.ToString()),
                                Direccion = item.DireccionPersonaAutor,
                                Estado = item.EstadoPersonaAutor,
                                NumeroIdentificacion = item.NumeroIdentificacionPersonaAutor,
                                PrimerApellido = item.PrimerApellidPersonaAutor,
                                SegundoApellido = item.SegundoApellidoPersonaAutor,
                                PrimerNombre = item.PrimerNombrePersonaAutor,
                                SegundoNombre = item.SegundoNombrePesonaAutor,
                                Parroquia = new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaAutor,
                                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquiaPersonaAutor.ToString())
                                },
                                Sexo = new Sexo()
                                {
                                    IdSexo = item.IdSexoPersonaAutor,
                                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexoPersonaAutor.ToString())
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion = item.IdTipoIdentificacionPersonaAutor,
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacionPersonaAutor.ToString())
                                },
                                Telefono = item.TelefonoPersonaAutor
                            }
                        }
                    },
                    AsignarUsuarioTipoUsuarioDecision = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.IdAsignarUsuarioTipoUsuarioDecision,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioDecision.ToString()),
                        Estado = item.EstadoAsignarUsuarioTipoUsuarioDecision,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.IdTipoUsuarioAsignarUsuarioTipoUsuarioDecision,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioDecision.ToString())
                        },
                        Usuario = new Usuario()
                        {
                            IdUsuario = item.IdUsuarioUsuarioDecision,
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.IdUsuarioUsuarioDecision.ToString()),
                            Persona = new Persona()
                            {
                                IdPersona = item.IdPersonaDecision,
                                IdPersonaEncriptado = _seguridad.Encriptar(item.IdPersonaDecision.ToString()),
                                Direccion = item.DireccionPersonaDecision,
                                Estado = item.EstadoPersonaDecision,
                                NumeroIdentificacion = item.NumeroIdentificacionPersonaDecision,
                                PrimerApellido = item.PrimerApellidPersonaDecision,
                                SegundoApellido = item.SegundoApellidoPersonaDecision,
                                PrimerNombre = item.PrimerNombrePersonaDecision,
                                SegundoNombre = item.SegundoNombrePesonaDecision,
                                Parroquia = new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaDecision,
                                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquiaPersonaDecision.ToString())
                                },
                                Sexo = new Sexo()
                                {
                                    IdSexo = item.IdSexoPersonaDecision,
                                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexoPersonaDecision.ToString())
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion = item.IdTipoIdentificacionPersonaDecision,
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacionPersonaDecision.ToString())
                                },
                                Telefono = item.TelefonoPersonaDecision
                            }
                        }
                    },
                    CabeceraCaracterizacion = new CabeceraCaracterizacion()
                    {
                        IdCabeceraCaracterizacion = item.IdCabeceraCaracterizacion,
                        IdCabeceraCaracterizacionEncriptar = _seguridad.Encriptar(item.IdCabeceraCaracterizacion.ToString()),
                        Estado = item.EstadoCabeceraCaracterizacion,
                        FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraCaracterizacion),
                        FechaRegistro = item.FechaRegistroCabeceraCaracterizacion,
                        Finalizado = item.FinalizadoCabeceraCaracterizacion,
                        AsignarResponsableModeloPublicado = new AsignarResponsableModeloPublicado()
                        {
                            IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                            IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                            Estado = item.EstadoAsignarResponsableModeloPublicado,
                            FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                            FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                            FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
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
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }

        public List<ContenidoDetalleComponente> ConsultarContenidoDetalleComponentePorId(int _idContenidoDetalleComponente)
        {
            List<ContenidoDetalleComponente> _lista = new List<ContenidoDetalleComponente>();
            foreach (var item in db.Sp_ContenidoDetalleComponenteConsultarPorId(_idContenidoDetalleComponente))
            {
                _lista.Add(new ContenidoDetalleComponente()
                {
                    IdContenidoDetalleComponenteCaracterizacion = item.IdContentidoDetalleComponeteCaracterizacion,
                    IdContenidoDetalleComponenteCaracterizacionEncriptado = _seguridad.Encriptar(item.IdContentidoDetalleComponeteCaracterizacion.ToString()),
                    Contenido = item.ContenidoContentidoDetalleComponente,
                    Estado = item.EstadoContentidoDetalleComponente,
                    FechaRegistro = item.FechaRegistroContentidoDetalleComponente,
                    EstadoDecision = item.EstadoDecisionContentidoDetalleComponente,
                    FechaDecision = item.FechaDesicionContentidoDetalleComponente,
                    ObservacionDecision = item.ObservacionDecisionContentidoDetalleComponente,
                    DescripcionComponente = new DescripcionComponente()
                    {
                        IdDescripcionComponente = item.IdDescripcionComponente,
                        Obligatorio = item.ObligatorioDescripcionComponente,
                        Orden = item.OrdenDescripcionComponente,
                        AsignarComponenteGenerico = new AsignarComponenteGenerico()
                        {
                            IdAsignarComponenteGenerico = item.IdAsignarComponenteGenericoDescripcionComponente,
                            IdAsignarComponenteGenericoEncriptado = _seguridad.Encriptar(item.IdAsignarComponenteGenericoDescripcionComponente.ToString())
                        }
                    },
                    AsignarUsuarioTipoUsuarioAutor = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.IdAsignarUsuarioTipoUsuarioAutor,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioAutor.ToString()),
                        Estado = item.EstadoAsignarUsuarioTipoUsuarioAutor,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor.ToString())
                        },
                        Usuario = new Usuario()
                        {
                            IdUsuario = item.IdUsuarioUsuarioAutor,
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.IdUsuarioUsuarioAutor.ToString()),
                            Persona = new Persona()
                            {
                                IdPersona = item.IdPersonaAutor,
                                IdPersonaEncriptado = _seguridad.Encriptar(item.IdPersonaAutor.ToString()),
                                Direccion = item.DireccionPersonaAutor,
                                Estado = item.EstadoPersonaAutor,
                                NumeroIdentificacion = item.NumeroIdentificacionPersonaAutor,
                                PrimerApellido = item.PrimerApellidPersonaAutor,
                                SegundoApellido = item.SegundoApellidoPersonaAutor,
                                PrimerNombre = item.PrimerNombrePersonaAutor,
                                SegundoNombre = item.SegundoNombrePesonaAutor,
                                Parroquia = new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaAutor,
                                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquiaPersonaAutor.ToString())
                                },
                                Sexo = new Sexo()
                                {
                                    IdSexo = item.IdSexoPersonaAutor,
                                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexoPersonaAutor.ToString())
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion = item.IdTipoIdentificacionPersonaAutor,
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacionPersonaAutor.ToString())
                                },
                                Telefono = item.TelefonoPersonaAutor
                            }
                        }
                    },
                    AsignarUsuarioTipoUsuarioDecision = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.IdAsignarUsuarioTipoUsuarioDecision,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioDecision.ToString()),
                        Estado = item.EstadoAsignarUsuarioTipoUsuarioDecision,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.IdTipoUsuarioAsignarUsuarioTipoUsuarioDecision,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioDecision.ToString())
                        },
                        Usuario = new Usuario()
                        {
                            IdUsuario = item.IdUsuarioUsuarioDecision,
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.IdUsuarioUsuarioDecision.ToString()),
                            Persona = new Persona()
                            {
                                IdPersona = item.IdPersonaDecision,
                                IdPersonaEncriptado = _seguridad.Encriptar(item.IdPersonaDecision.ToString()),
                                Direccion = item.DireccionPersonaDecision,
                                Estado = item.EstadoPersonaDecision,
                                NumeroIdentificacion = item.NumeroIdentificacionPersonaDecision,
                                PrimerApellido = item.PrimerApellidPersonaDecision,
                                SegundoApellido = item.SegundoApellidoPersonaDecision,
                                PrimerNombre = item.PrimerNombrePersonaDecision,
                                SegundoNombre = item.SegundoNombrePesonaDecision,
                                Parroquia = new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaDecision,
                                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquiaPersonaDecision.ToString())
                                },
                                Sexo = new Sexo()
                                {
                                    IdSexo = item.IdSexoPersonaDecision,
                                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexoPersonaDecision.ToString())
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion = item.IdTipoIdentificacionPersonaDecision,
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacionPersonaDecision.ToString())
                                },
                                Telefono = item.TelefonoPersonaDecision
                            }
                        }
                    },
                    CabeceraCaracterizacion = new CabeceraCaracterizacion()
                    {
                        IdCabeceraCaracterizacion = item.IdCabeceraCaracterizacion,
                        IdCabeceraCaracterizacionEncriptar = _seguridad.Encriptar(item.IdCabeceraCaracterizacion.ToString()),
                        Estado = item.EstadoCabeceraCaracterizacion,
                        FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraCaracterizacion),
                        FechaRegistro = item.FechaRegistroCabeceraCaracterizacion,
                        Finalizado = item.FinalizadoCabeceraCaracterizacion,
                        AsignarResponsableModeloPublicado = new AsignarResponsableModeloPublicado()
                        {
                            IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                            IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                            Estado = item.EstadoAsignarResponsableModeloPublicado,
                            FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                            FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                            FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
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
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }
        public List<ContenidoDetalleComponente> ConsultarContenidoDetalleComponentePorIdDescripcionComponente(int _idDescripcionComponente)
        {
            List<ContenidoDetalleComponente> _lista = new List<ContenidoDetalleComponente>();
            foreach (var item in db.Sp_ContenidoDetalleComponenteConsultarPorIdDescripcionComponente(_idDescripcionComponente))
            {
                _lista.Add(new ContenidoDetalleComponente()
                {
                    IdContenidoDetalleComponenteCaracterizacion = item.IdContentidoDetalleComponeteCaracterizacion,
                    IdContenidoDetalleComponenteCaracterizacionEncriptado = _seguridad.Encriptar(item.IdContentidoDetalleComponeteCaracterizacion.ToString()),
                    Contenido = item.ContenidoContentidoDetalleComponente,
                    Estado = item.EstadoContentidoDetalleComponente,
                    FechaRegistro = item.FechaRegistroContentidoDetalleComponente,
                    EstadoDecision = item.EstadoDecisionContentidoDetalleComponente,
                    FechaDecision = item.FechaDesicionContentidoDetalleComponente,
                    ObservacionDecision = item.ObservacionDecisionContentidoDetalleComponente,
                    DescripcionComponente = new DescripcionComponente()
                    {
                        IdDescripcionComponente = item.IdDescripcionComponente,
                        Obligatorio = item.ObligatorioDescripcionComponente,
                        Orden = item.OrdenDescripcionComponente,
                        AsignarComponenteGenerico = new AsignarComponenteGenerico()
                        {
                            IdAsignarComponenteGenerico = item.IdAsignarComponenteGenericoDescripcionComponente,
                            IdAsignarComponenteGenericoEncriptado = _seguridad.Encriptar(item.IdAsignarComponenteGenericoDescripcionComponente.ToString())
                        }
                    },
                    AsignarUsuarioTipoUsuarioAutor = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.IdAsignarUsuarioTipoUsuarioAutor,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioAutor.ToString()),
                        Estado = item.EstadoAsignarUsuarioTipoUsuarioAutor,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor.ToString())
                        },
                        Usuario = new Usuario()
                        {
                            IdUsuario = item.IdUsuarioUsuarioAutor,
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.IdUsuarioUsuarioAutor.ToString()),
                            Persona = new Persona()
                            {
                                IdPersona = item.IdPersonaAutor,
                                IdPersonaEncriptado = _seguridad.Encriptar(item.IdPersonaAutor.ToString()),
                                Direccion = item.DireccionPersonaAutor,
                                Estado = item.EstadoPersonaAutor,
                                NumeroIdentificacion = item.NumeroIdentificacionPersonaAutor,
                                PrimerApellido = item.PrimerApellidPersonaAutor,
                                SegundoApellido = item.SegundoApellidoPersonaAutor,
                                PrimerNombre = item.PrimerNombrePersonaAutor,
                                SegundoNombre = item.SegundoNombrePesonaAutor,
                                Parroquia = new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaAutor,
                                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquiaPersonaAutor.ToString())
                                },
                                Sexo = new Sexo()
                                {
                                    IdSexo = item.IdSexoPersonaAutor,
                                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexoPersonaAutor.ToString())
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion = item.IdTipoIdentificacionPersonaAutor,
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacionPersonaAutor.ToString())
                                },
                                Telefono = item.TelefonoPersonaAutor
                            }
                        }
                    },
                    AsignarUsuarioTipoUsuarioDecision = new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario = item.IdAsignarUsuarioTipoUsuarioDecision,
                        IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioDecision.ToString()),
                        Estado = item.EstadoAsignarUsuarioTipoUsuarioDecision,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = item.IdTipoUsuarioAsignarUsuarioTipoUsuarioDecision,
                            IdTipoUsuarioEncriptado = _seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioDecision.ToString())
                        },
                        Usuario = new Usuario()
                        {
                            IdUsuario = item.IdUsuarioUsuarioDecision,
                            IdUsuarioEncriptado = _seguridad.Encriptar(item.IdUsuarioUsuarioDecision.ToString()),
                            Persona = new Persona()
                            {
                                IdPersona = item.IdPersonaDecision,
                                IdPersonaEncriptado = _seguridad.Encriptar(item.IdPersonaDecision.ToString()),
                                Direccion = item.DireccionPersonaDecision,
                                Estado = item.EstadoPersonaDecision,
                                NumeroIdentificacion = item.NumeroIdentificacionPersonaDecision,
                                PrimerApellido = item.PrimerApellidPersonaDecision,
                                SegundoApellido = item.SegundoApellidoPersonaDecision,
                                PrimerNombre = item.PrimerNombrePersonaDecision,
                                SegundoNombre = item.SegundoNombrePesonaDecision,
                                Parroquia = new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaDecision,
                                    IdParroquiaEncriptado = _seguridad.Encriptar(item.IdParroquiaPersonaDecision.ToString())
                                },
                                Sexo = new Sexo()
                                {
                                    IdSexo = item.IdSexoPersonaDecision,
                                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexoPersonaDecision.ToString())
                                },
                                TipoIdentificacion = new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion = item.IdTipoIdentificacionPersonaDecision,
                                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacionPersonaDecision.ToString())
                                },
                                Telefono = item.TelefonoPersonaDecision
                            }
                        }
                    },
                    CabeceraCaracterizacion = new CabeceraCaracterizacion()
                    {
                        IdCabeceraCaracterizacion = item.IdCabeceraCaracterizacion,
                        IdCabeceraCaracterizacionEncriptar = _seguridad.Encriptar(item.IdCabeceraCaracterizacion.ToString()),
                        Estado = item.EstadoCabeceraCaracterizacion,
                        FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraCaracterizacion),
                        FechaRegistro = item.FechaRegistroCabeceraCaracterizacion,
                        Finalizado = item.FinalizadoCabeceraCaracterizacion,
                        AsignarResponsableModeloPublicado = new AsignarResponsableModeloPublicado()
                        {
                            IdAsignarResponsableModeloPublicado = item.IdAsignarResponsableModeloPublicado,
                            IdAsignarResponsableModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdAsignarResponsableModeloPublicado.ToString()),
                            Estado = item.EstadoAsignarResponsableModeloPublicado,
                            FechaAsignacion = item.FechaAsignacionAsignarResponsableModeloPublicado,
                            FechaInicio = item.FechaInicioAsignarResponsableModeloPublicado,
                            FechaFin = item.FechaFinAsignarResponsableModeloPublicado,
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
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }
    }
}