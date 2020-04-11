using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoContenidoTipoElemento
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarContenidoTipoElemento(ContenidoTipoElemento _objContenidoTipoElemento)
        {
            try
            {
                return int.Parse(db.Sp_ContenidoTipoElementoInsertar(_objContenidoTipoElemento.CabeceraCaracterizacion.IdCabeceraCaracterizacion, _objContenidoTipoElemento.AsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento, _objContenidoTipoElemento.Contenido, _objContenidoTipoElemento.UrlRutaContenido, _objContenidoTipoElemento.FechaRegistro, _objContenidoTipoElemento.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario, _objContenidoTipoElemento.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int ModificarContenidoTipoElemento(ContenidoTipoElemento _objContenidoTipoElemento)
        {
            try
            {
                db.Sp_ContenidoTipoElementoModificar(_objContenidoTipoElemento.IdContenidoTipoElemento, _objContenidoTipoElemento.CabeceraCaracterizacion.IdCabeceraCaracterizacion, _objContenidoTipoElemento.AsignarDescripcionComponenteTipoElemento.IdAsignarDescripcionComponenteTipoElemento, _objContenidoTipoElemento.Contenido, _objContenidoTipoElemento.UrlRutaContenido, _objContenidoTipoElemento.FechaRegistro, _objContenidoTipoElemento.AsignarUsuarioTipoUsuario.IdAsignarUsuarioTipoUsuario, _objContenidoTipoElemento.Estado);
                return _objContenidoTipoElemento.IdContenidoTipoElemento;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarContenidoTipoElemento(int _idContenidoTipoElemento)
        {
            db.Sp_ContenidoTipoElementoEliminar(_idContenidoTipoElemento);
        }
        public List<ContenidoTipoElemento> ConsultarContenidoTipoElemento()
        {
            List<ContenidoTipoElemento> _lista = new List<ContenidoTipoElemento>();
            foreach (var item in db.Sp_ContenidoTipoElementoConsultar())
            {
                _lista.Add(new ContenidoTipoElemento()
                {
                    IdContenidoTipoElemento=item.IdContenidoTipoElemento,
                    IdContenidoTipoElementoEncriptado=_seguridad.Encriptar(item.IdContenidoTipoElemento.ToString()),
                    Contenido=item.ContenidoContenidoTipoElemento,
                    Estado=item.EstadoContenidoTipoElemento,
                    FechaRegistro= item.FechaRegistroContenidoTipoElemento,
                    UrlRutaContenido=item.UrlRutaContenidoContenidoTipoElemento,
                    AsignarDescripcionComponenteTipoElemento=new AsignarDescripcionComponenteTipoElemento()
                    {
                        IdAsignarDescripcionComponenteTipoElemento=item.IdAsignarDescripcionComponenteTipoElemento,
                        IdAsignarDescripcionComponenteTipoElementoEncriptado=_seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                        Obligatorio = item.ObligatorioAsignarDescripcionComponenteTipoElemento,
                        Orden=item.OrdenAsignarDescripcionComponenteTipoElemento,
                        TipoElemento = new TipoElemento()
                        {
                            IdTipoElemento=item.IdTipoElementoAsignarDescripcionComponenteTipoElemento,
                            IdTipoElementoEncriptado=_seguridad.Encriptar(item.IdTipoElementoAsignarDescripcionComponenteTipoElemento.ToString())
                        }       
                    },
                    AsignarUsuarioTipoUsuario=new AsignarUsuarioTipoUsuario()
                    {
                        IdAsignarUsuarioTipoUsuario=item.IdAsignarUsuarioTipoUsuarioAutor,
                        IdAsignarUsuarioTipoUsuarioEncriptado=_seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuarioAutor.ToString()),
                        Estado=item.EstadoAsignarUsuarioTipoUsuarioAutor,
                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario=item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor,
                            IdTipoUsuarioEncriptado=_seguridad.Encriptar(item.IdTipoUsuarioAsignarUsuarioTipoUsuarioAutor.ToString())
                        },
                        Usuario=new Usuario()
                        {
                            IdUsuario=item.IdUsuarioUsuarioAutor,
                            IdUsuarioEncriptado=_seguridad.Encriptar(item.IdUsuarioUsuarioAutor.ToString()),
                            Persona=new Persona()
                            {
                                IdPersona=item.IdPersonaAutor,
                                IdPersonaEncriptado=_seguridad.Encriptar(item.IdPersonaAutor.ToString()),
                                Direccion=item.DireccionPersonaAutor,
                                Estado=item.EstadoPersonaAutor,
                                NumeroIdentificacion=item.NumeroIdentificacionPersonaAutor,
                                PrimerApellido=item.PrimerApellidPersonaAutor,
                                SegundoApellido=item.SegundoApellidoPersonaAutor,
                                PrimerNombre=item.PrimerNombrePersonaAutor,
                                SegundoNombre=item.SegundoNombrePesonaAutor,
                                Parroquia=new Parroquia()
                                {
                                    IdParroquia = item.IdParroquiaPersonaAutor,
                                    IdParroquiaEncriptado=_seguridad.Encriptar(item.IdParroquiaPersonaAutor.ToString())
                                },
                                Sexo=new Sexo()
                                {
                                    IdSexo=item.IdSexoPersonaAutor,
                                    IdSexoEncriptado=_seguridad.Encriptar(item.IdSexoPersonaAutor.ToString())
                                },
                                TipoIdentificacion=new TipoIdentificacion()
                                {
                                    IdTipoIdentificacion=item.IdTipoIdentificacionPersonaAutor,
                                    IdTipoIdentificacionEncriptado=_seguridad.Encriptar(item.IdTipoIdentificacionPersonaAutor.ToString())
                                },
                                Telefono=item.TelefonoPersonaAutor
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
                        }
                    }
                });
            }
            return _lista;
        }
        public List<ContenidoTipoElemento> ConsultarContenidoTipoElementoPorId(int _idContenidoTipoElemento)
        {
            List<ContenidoTipoElemento> _lista = new List<ContenidoTipoElemento>();
            foreach (var item in db.Sp_ContenidoTipoElementoConsultarPorId(_idContenidoTipoElemento))
            {
                _lista.Add(new ContenidoTipoElemento()
                {
                    IdContenidoTipoElemento = item.IdContenidoTipoElemento,
                    IdContenidoTipoElementoEncriptado = _seguridad.Encriptar(item.IdContenidoTipoElemento.ToString()),
                    Contenido = item.ContenidoContenidoTipoElemento,
                    Estado = item.EstadoContenidoTipoElemento,
                    FechaRegistro = item.FechaRegistroContenidoTipoElemento,
                    UrlRutaContenido = item.UrlRutaContenidoContenidoTipoElemento,
                    AsignarDescripcionComponenteTipoElemento = new AsignarDescripcionComponenteTipoElemento()
                    {
                        IdAsignarDescripcionComponenteTipoElemento = item.IdAsignarDescripcionComponenteTipoElemento,
                        IdAsignarDescripcionComponenteTipoElementoEncriptado = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                        Obligatorio = item.ObligatorioAsignarDescripcionComponenteTipoElemento,
                        Orden = item.OrdenAsignarDescripcionComponenteTipoElemento,
                        TipoElemento = new TipoElemento()
                        {
                            IdTipoElemento = item.IdTipoElementoAsignarDescripcionComponenteTipoElemento,
                            IdTipoElementoEncriptado = _seguridad.Encriptar(item.IdTipoElementoAsignarDescripcionComponenteTipoElemento.ToString())
                        }
                    },
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
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
                        }
                    }
                });
            }
            return _lista;
        }

        public List<ContenidoTipoElemento> ConsultarContenidoTipoElementoPorIdAsignarDescripcionComponenteTipoElemento(int _idAsignarDescripcionComponenteTipoElemento)
        {
            List<ContenidoTipoElemento> _lista = new List<ContenidoTipoElemento>();
            foreach (var item in db.Sp_ContenidoTipoElementoConsultarPorIdAsignarDescripcionComponenteTipoElemento(_idAsignarDescripcionComponenteTipoElemento))
            {
                _lista.Add(new ContenidoTipoElemento()
                {
                    IdContenidoTipoElemento = item.IdContenidoTipoElemento,
                    IdContenidoTipoElementoEncriptado = _seguridad.Encriptar(item.IdContenidoTipoElemento.ToString()),
                    Contenido = item.ContenidoContenidoTipoElemento,
                    Estado = item.EstadoContenidoTipoElemento,
                    FechaRegistro = item.FechaRegistroContenidoTipoElemento,
                    UrlRutaContenido = item.UrlRutaContenidoContenidoTipoElemento,
                    AsignarDescripcionComponenteTipoElemento = new AsignarDescripcionComponenteTipoElemento()
                    {
                        IdAsignarDescripcionComponenteTipoElemento = item.IdAsignarDescripcionComponenteTipoElemento,
                        IdAsignarDescripcionComponenteTipoElementoEncriptado = _seguridad.Encriptar(item.IdAsignarDescripcionComponenteTipoElemento.ToString()),
                        Obligatorio = item.ObligatorioAsignarDescripcionComponenteTipoElemento,
                        Orden = item.OrdenAsignarDescripcionComponenteTipoElemento,
                        TipoElemento = new TipoElemento()
                        {
                            IdTipoElemento = item.IdTipoElementoAsignarDescripcionComponenteTipoElemento,
                            IdTipoElementoEncriptado = _seguridad.Encriptar(item.IdTipoElementoAsignarDescripcionComponenteTipoElemento.ToString())
                        }
                    },
                    AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
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
                        }
                    }
                });
            }
            return _lista;
        }
    }
}