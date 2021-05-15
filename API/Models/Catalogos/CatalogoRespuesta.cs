using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoRespuesta
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();


        public List<RespuestaPreguntaAbierta> mostrarRespuestasAbierta(string _IdPregunta, string _IdAsignarEncuestado)
        {
            List<RespuestaPreguntaAbierta> _lista = new List<RespuestaPreguntaAbierta>();
            foreach (var item in db.Sp_RespuestaPreguntaAbierta(Convert.ToInt32(_IdPregunta), Convert.ToInt32(_IdAsignarEncuestado)))
            {
                _lista.Add(new RespuestaPreguntaAbierta(
                    _seguridad.Encriptar(item.IdPregunta.ToString()),
                     item.DescripcionPregunta,
                    _seguridad.Encriptar(item.IdPreguntaAbierta.ToString()),
                    item.TipoHTML,
                     _seguridad.Encriptar(item.IdRespuesta.ToString()),
                    _seguridad.Encriptar(item.IdRespuestaLogica.ToString()),
                    item.DescripcionRespuestaAbierta,
                    _seguridad.Encriptar(item.IdAsignarEncuestado.ToString())

                 ));
            }
            return _lista;

        }
        public List<RespuestasPregunta> mostrarRespuestas(string _IdAsignarEncuestado, string _IdPregunta)
        {
            List<RespuestasPregunta> _lista = new List<RespuestasPregunta>();
            foreach (var item in db.Sp_ShowRespuestaPorPregunta(Convert.ToInt32(_IdAsignarEncuestado), Convert.ToInt32(_IdPregunta)))
            {
                _lista.Add(new RespuestasPregunta()
                {
                    IdRespuesta = _seguridad.Encriptar(item.IdRespuesta.ToString()),
                    IdAsignarEncuestado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                    IdPregunta = _seguridad.Encriptar(item.IdPregunta.ToString()),
                    DescripcionRespuestaAbierta = item.DescripcionRespuestaAbierta,
                    IdRespuestaLogica = _seguridad.Encriptar(item.IdRespuestaLogica.ToString()),
                });
            }
            return _lista;

        }

        public List<RespuestasPregunta> mostrarRespuestasArbol(int _idCuestionario, int _idVersion, int _idComunidad, int _idPregunta, int _idTipoPregunta)
        {

            List<RespuestasPregunta> _lista = new List<RespuestasPregunta>();

            if (_idTipoPregunta == 2)
            {

                foreach (var item2 in db.Sp_ConsultarRespuestasSeleccion(_idCuestionario, _idVersion, _idComunidad, _idPregunta))
                {
                    _lista.Add(new RespuestasPregunta()
                    {
                        IdPregunta = _seguridad.Encriptar(_idPregunta.ToString()),
                        DescripcionRespuestaSeleccion = item2.Item.Substring(2),
                        VecesRepetidas= item2.VecesRepetidas.ToString()
                    });
                }

            }
            else if (_idTipoPregunta == 3)
            {

                foreach (var item3 in db.Sp_ConsultarRespuestasSeleccion(_idCuestionario, _idVersion, _idComunidad, _idPregunta))
                {
                    _lista.Add(new RespuestasPregunta()
                    {
                        IdPregunta = _seguridad.Encriptar(_idPregunta.ToString()),
                        DescripcionRespuestaSeleccion = item3.Item,
                        VecesRepetidas = item3.VecesRepetidas.ToString()
                    });
                }

            }
            else if (_idTipoPregunta == 4)
            {
               
                foreach (var item4 in db.Sp_ConsultarRespuestasMatrizSeleccion(_idCuestionario, _idVersion, _idComunidad, _idPregunta))
                {
                    _lista.Add(new RespuestasPregunta()
                    {
                        IdPregunta = _seguridad.Encriptar(_idPregunta.ToString()),
                        DescripcionRespuestaAbierta = item4.Item,
                        VecesRepetidas = item4.VecesRepetidas.ToString()
                    });
                }
                
            }
            else
            {
                foreach (var item in db.Sp_ConsultarRespuestasArbol(_idCuestionario, _idVersion, _idComunidad, _idPregunta))
                {
                    if (_idTipoPregunta == 6)
                    {

                        _lista.Add(new RespuestasPregunta()
                        {
                            IdPregunta = _seguridad.Encriptar(item.IdPregunta.ToString()),
                            DescripcionRespuestaAbierta = item.DescripcionRespuestaAbierta.Substring(2)
                        });
                    }
                    else
                    {
                        _lista.Add(new RespuestasPregunta()
                        {
                            IdPregunta = _seguridad.Encriptar(item.IdPregunta.ToString()),
                            DescripcionRespuestaAbierta = item.DescripcionRespuestaAbierta
                        });
                    }
                }
            }

            
            return _lista;

        }


        public List<RespuestaPreguntaSeleccion> mostrarPreguntaRespuestasPorSeleccion(string _IdPregunta, string _IdAsignarEncuestado)
        {
            List<RespuestaPreguntaSeleccion> _lista = new List<RespuestaPreguntaSeleccion>();
            foreach (var item in db.Sp_OpcionPreguntaSeleccionConsultar2(Convert.ToInt32(_IdPregunta), Convert.ToInt32(_IdAsignarEncuestado)))
            {
                _lista.Add(new RespuestaPreguntaSeleccion()
                {


                    IdOpcionPreguntaSeleccion = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                    DescripcionOpcionPreguntaSeleccion = item.DescripcionOpcionPreguntaSeleccion,
                    IdPreguntaHIja = _seguridad.Encriptar(item.IdPreguntaHIja.ToString()),
                    DescripcionPreguntaHIja = item.DescripcionPreguntaHIja,
                    IdPregunta = _seguridad.Encriptar(item.IdPregunta.ToString()),
                    DescripcionPregunta = item.DescripcionPregunta,
                    OrdenPregunta = Convert.ToString(item.OrdenPregunta),
                    EncajonamientoOpcionPreguntaSeleccion = item.EncajonamientoOpcionPreguntaSeleccion,
                    IdRespuesta = _seguridad.Encriptar(item.IdRespuesta.ToString()),
                    IdRespuestaLogica = _seguridad.Encriptar(item.IdRespuestaLogica.ToString()),
                    DescripcionRespuestaAbierta = item.DescripcionRespuestaAbierta,
                    IdAsignarEncuestado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                    TotalOpciones = Convert.ToInt32(item.TotalOpciones),

                });
            }
            return _lista;

        }
        public int InsertarRespuesta2(Respuesta _objRespuesta)
        {
            try
            {
                return db.RespuestaPreguntaInsertAndUpdate(_objRespuesta.Pregunta.IdPregunta, _objRespuesta.Pregunta.TipoPregunta.Identificador, _objRespuesta.CabeceraRespuesta.IdCabeceraRespuesta, _objRespuesta.IdRespuestaLogica, _objRespuesta.DescripcionRespuestaAbierta, _objRespuesta.FechaRegistro, _objRespuesta.CabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestado, _objRespuesta.CabeceraRespuesta.FechaRegistro);
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public int InsertarRespuesta(Respuesta _objRespuesta)
        {
            try
            {
                return int.Parse(db.Sp_RespuestaInsertar(_objRespuesta.CabeceraRespuesta.IdCabeceraRespuesta, _objRespuesta.FechaRegistro, _objRespuesta.Pregunta.IdPregunta, _objRespuesta.IdRespuestaLogica, _objRespuesta.DescripcionRespuestaAbierta, _objRespuesta.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarRespuesta(Respuesta _objRespuesta)
        {
            try
            {
                db.Sp_RespuestaModificar(_objRespuesta.IdRespuesta, _objRespuesta.CabeceraRespuesta.IdCabeceraRespuesta, _objRespuesta.FechaRegistro, _objRespuesta.Pregunta.IdPregunta, _objRespuesta.IdRespuestaLogica, _objRespuesta.DescripcionRespuestaAbierta, _objRespuesta.Estado);
                return _objRespuesta.IdRespuesta;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarRespuesta(int _idRespuesta)
        {
            db.Sp_RespuestaEliminar(_idRespuesta);
        }

        public List<Respuesta> ConsultarRespuestaPorId(int _idRespuesta)
        {
            List<Respuesta> _lista = new List<Respuesta>();
            foreach (var item in db.Sp_RespuestaConsultarPorId(_idRespuesta))
            {
                _lista.Add(new Respuesta()
                {
                    IdRespuesta = item.IdRespuesta,
                    IdRespuestaEncriptado = _seguridad.Encriptar(item.IdRespuesta.ToString()),
                    IdRespuestaLogicaEncriptado = _seguridad.Encriptar(item.IdRespuestaLogica.ToString()),
                    Estado = item.Estado,
                    CabeceraRespuesta = new CabeceraRespuesta()
                    {
                        IdCabeceraRespuesta = item.IdCabeceraRespuesta,
                        IdCabeceraRespuestaEncriptado = _seguridad.Encriptar(item.IdCabeceraRespuesta.ToString())
                    },
                    DescripcionRespuestaAbierta = item.DescripcionRespuestaAbierta,
                    FechaRegistro = item.FechaRegistro,
                    Pregunta = new Pregunta() { IdPregunta = item.IdPregunta, IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()) },
                    IdRespuestaLogica = item.IdRespuestaLogica
                });
            }
            return _lista;
        }


        public List<Respuesta> ConsultarRespuestaPorIdCabeceraRespuesta(int _idCabeceraRespuesta)
        {
            List<Respuesta> _lista = new List<Respuesta>();
            foreach (var item in db.Sp_RespuestaConsultarPorCabeceraRespuesta(_idCabeceraRespuesta))
            {
                _lista.Add(new Respuesta()
                {
                    IdRespuesta = item.IdRespuesta,
                    IdRespuestaEncriptado = _seguridad.Encriptar(item.IdRespuesta.ToString()),
                    IdRespuestaLogicaEncriptado = _seguridad.Encriptar(item.IdRespuestaLogica.ToString()),
                    Estado = item.EstadoRespuesta,
                    CabeceraRespuesta = new CabeceraRespuesta()
                    {
                        IdCabeceraRespuesta = item.IdCabeceraRespuesta,
                        IdCabeceraRespuestaEncriptado = _seguridad.Encriptar(item.IdCabeceraRespuesta.ToString()),
                        Estado = item.EstadoCabeceraRespuesta,
                        FechaFinalizado = Convert.ToDateTime(item.FechaFinalizadoCabeceraRespuesta),
                        FechaRegistro = item.FechaRegistroCabeceraRespuesta,
                        Finalizado = item.FinalizadoCabeceraRespuesta,
                        AsignarEncuestado = new AsignarEncuestado()
                        {
                            IdAsignarEncuestado = item.IdAsignarEncuestado,
                            IdAsignarEncuestadoEncriptado = _seguridad.Encriptar(item.IdAsignarEncuestado.ToString()),
                            FechaInicio = item.FechaInicioAsignarEncuestado,
                            FechaFin = item.FechaFinAsignarEncuestado,
                            Estado = item.EstadoAsignarEncuestado,
                            Obligatorio = item.ObligatorioAsignarEncuestado,
                            Comunidad = new Comunidad()
                            {
                                IdComunidad = item.IdComunidad,
                                IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                                CodigoComunidad = item.CodigoComunidad,
                                DescripcionComunidad = item.DescripcionComunidad,
                                EstadoComunidad = item.EstadoComunidad,
                                NombreComunidad = item.NombreComunidad,
                                //RutaLogoComunidad = item.RutaLogoComunidad,
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
                                }
                            },
                            CuestionarioPublicado = new CuestionarioPublicado()
                            {
                                IdCuestionarioPublicado = item.IdCuestionarioPublicado,
                                IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.IdCuestionarioPublicado.ToString()),
                                Estado = item.EstadoCuestionarioPublicado,
                                FechaPublicacion = item.FechaPublicacionCuestionarioPublicado,
                                AsignarUsuarioTipoUsuario = new AsignarUsuarioTipoUsuario()
                                {
                                    IdAsignarUsuarioTipoUsuario = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario,
                                    IdAsignarUsuarioTipoUsuarioEncriptado = _seguridad.Encriptar(item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_IdAsignarUsuarioTipoUsuario.ToString()),
                                    Estado = item.ASIGNARUSUARIOTIPOUSUARIOPUBLICADO_Estado,
                                },
                                Periodo = new Periodo()
                                {
                                    IdPeriodo = item.IdPeriodo,
                                    IdPeriodoEncriptado = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                                    Estado = item.EstadoPeriodo,
                                    FechaInicio = item.FechaInicioPeriodo,
                                    FechaFin = item.FechaFinPeriodo
                                },
                                CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                                {
                                    IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                                    IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString()),
                                    Caracteristica = item.CaracteristicaCabeceraVersionCuestionario,
                                    Version = item.VersionCabeceraVersionCuestionario,
                                    Estado = item.EstadoCabeceraVersionCuestionario,
                                    AsignarResponsable = new AsignarResponsable()
                                    {
                                        IdAsignarResponsable = item.ASIGNARRESPONSABLE_IdAsignarResponsable,
                                        IdAsignarResponsableEncriptado = _seguridad.Encriptar(item.ASIGNARRESPONSABLE_IdAsignarResponsable.ToString()),
                                        Estado = item.ASIGNARRESPONSABLE_Estado,
                                        FechaAsignacion = item.ASIGNARRESPONSABLE_FechaAsignacion,
                                        CuestionarioGenerico = new CuestionarioGenerico()
                                        {
                                            IdCuestionarioGenerico = item.CUESTIONARIOGENERICO_IdCuestionarioGenerico,
                                            IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.CUESTIONARIOGENERICO_IdCuestionarioGenerico.ToString()),
                                            Descripcion = item.CUESTIONARIOGENERICO_Descripcion,
                                            Estado = item.CUESTIONARIOGENERICO_Estado,
                                            Nombre = item.CUESTIONARIOGENERICO_Nombre,
                                        },
                                    },
                                    FechaCreacion = item.FechaCreacionCabeceraVersionCuestionario
                                }
                            }
                        }
                    },
                    DescripcionRespuestaAbierta = item.DescripcionRespuestaAbierta,
                    FechaRegistro = item.FechaRegistro,
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Obligatorio = item.ObligatorioPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            Identificador = item.IdentificadorTipoPregunta,
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta
                        }
                    },
                    IdRespuestaLogica = item.IdRespuestaLogica
                });
            }
            return _lista;
        }
    }
}