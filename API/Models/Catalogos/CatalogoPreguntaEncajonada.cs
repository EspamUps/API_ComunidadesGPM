using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoPreguntaEncajonada
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        
        public int InsertarPreguntaEncajonada(PreguntaEncajonada _objPreguntaEncajonada)
        {
            try
            {
                return int.Parse(db.Sp_PreguntaEncajonadaInsertar(_objPreguntaEncajonada.Pregunta.IdPregunta,_objPreguntaEncajonada.OpcionPreguntaSeleccion.IdOpcionPreguntaSeleccion,_objPreguntaEncajonada.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarPreguntaEncajonada(int _idPreguntaEncajonada)
        {
            db.Sp_PreguntaEncajonadaEliminar(_idPreguntaEncajonada);
        }

        public List<PreguntaEncajonada> ConsultarPreguntaEncajonada()
        {
            List<PreguntaEncajonada> _lista = new List<PreguntaEncajonada>();
            foreach (var item in db.Sp_PreguntaEncajonadaConsultar())
            {
                _lista.Add(new PreguntaEncajonada()
                {
                    IdPreguntaEncajonada=item.IdPreguntaEncajonada,
                    IdPreguntaEncajonadaEncriptado = _seguridad.Encriptar(item.IdPreguntaEncajonada.ToString()),
                    Estado = item.EstadoPreguntaEncajonada,
                    Utilizado=item.UtilizadoPreguntaEncajonada,
                    OpcionPreguntaSeleccion=new OpcionPreguntaSeleccion()
                    {
                        IdOpcionPreguntaSeleccion=item.IdOpcionPreguntaSeleccion,
                        IdOpcionPreguntaSeleccionEncriptado = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                        Descripcion =item.DescripcionOpcionPreguntaSeleccion,
                        Estado=item.EstadoOpcionPreguntaSeleccion,
                        Pregunta = new Pregunta()
                        {
                            IdPregunta=item.IdPreguntaOpcionPreguntaSeleccion,
                            IdPreguntaEncriptado=_seguridad.Encriptar(item.IdPreguntaOpcionPreguntaSeleccion.ToString())
                        }
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Descripcion = item.DescripcionPregunta,
                        Estado = item.EstadoPregunta,
                        Obligatorio = item.ObligatorioPregunta,
                        Orden = item.OrdenPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta,
                            Identificador = item.IdentificadorTipoPregunta
                        },
                        Seccion = new Seccion()
                        {
                            IdSeccion = item.IdSeccion,
                            IdSeccionEncriptado = _seguridad.Encriptar(item.IdSeccion.ToString()),
                            Descripcion = item.DescripcionSeccion,
                            Estado = item.EstadoSeccion,
                            Orden = item.OrdenSeccion,
                            Componente = new Componente()
                            {
                                IdComponente = item.IdComponente,
                                IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString()),
                                Descripcion = item.DescripcionComponente,
                                Estado = item.EstadoComponente,
                                Orden = item.OrdenComponente,
                                CuestionarioGenerico = new CuestionarioGenerico()
                                {
                                    IdCuestionarioGenerico = item.IdCuestionarioGenerico,
                                    IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.IdCuestionarioGenerico.ToString()),
                                    Descripcion = item.DescripcionCuestionarioGenerico,
                                    Estado = item.EstadoCuestionarioGenerico,
                                    Nombre = item.NombreCuestionarioGenerico
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }

        public List<PreguntaEncajonada> ConsultarPreguntaEncajonadaPorIdOpcionSeleccionUnica(int _idOpcionPreguntaSeleccion)
        {
            List<PreguntaEncajonada> _lista = new List<PreguntaEncajonada>();
            foreach (var item in db.Sp_PreguntaEncajonadaConsultar().Where(c=>c.IdOpcionPreguntaSeleccion== _idOpcionPreguntaSeleccion).ToList())
            {
                _lista.Add(new PreguntaEncajonada()
                {
                    IdPreguntaEncajonada = item.IdPreguntaEncajonada,
                    IdPreguntaEncajonadaEncriptado = _seguridad.Encriptar(item.IdPreguntaEncajonada.ToString()),
                    Estado = item.EstadoPreguntaEncajonada,
                    Utilizado = item.UtilizadoPreguntaEncajonada,
                    OpcionPreguntaSeleccion = new OpcionPreguntaSeleccion()
                    {
                        IdOpcionPreguntaSeleccion = item.IdOpcionPreguntaSeleccion,
                        IdOpcionPreguntaSeleccionEncriptado = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                        Descripcion = item.DescripcionOpcionPreguntaSeleccion,
                        Estado = item.EstadoOpcionPreguntaSeleccion,
                        Pregunta = new Pregunta()
                        {
                            IdPregunta = item.IdPreguntaOpcionPreguntaSeleccion,
                            IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPreguntaOpcionPreguntaSeleccion.ToString())
                        }
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Descripcion = item.DescripcionPregunta,
                        Estado = item.EstadoPregunta,
                        Obligatorio = item.ObligatorioPregunta,
                        Orden = item.OrdenPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta,
                            Identificador = item.IdentificadorTipoPregunta
                        },
                        Seccion = new Seccion()
                        {
                            IdSeccion = item.IdSeccion,
                            IdSeccionEncriptado = _seguridad.Encriptar(item.IdSeccion.ToString()),
                            Descripcion = item.DescripcionSeccion,
                            Estado = item.EstadoSeccion,
                            Orden = item.OrdenSeccion,
                            Componente = new Componente()
                            {
                                IdComponente = item.IdComponente,
                                IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString()),
                                Descripcion = item.DescripcionComponente,
                                Estado = item.EstadoComponente,
                                Orden = item.OrdenComponente,
                                CuestionarioGenerico = new CuestionarioGenerico()
                                {
                                    IdCuestionarioGenerico = item.IdCuestionarioGenerico,
                                    IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.IdCuestionarioGenerico.ToString()),
                                    Descripcion = item.DescripcionCuestionarioGenerico,
                                    Estado = item.EstadoCuestionarioGenerico,
                                    Nombre = item.NombreCuestionarioGenerico
                                }
                            }
                        }
                    }
                });
            }
            return _lista;
        }

        public List<PreguntaEncajonada> ConsultarPreguntaEncajonadaPorId(int _idPreguntaEncajonada)
        {
            List<PreguntaEncajonada> _lista = new List<PreguntaEncajonada>();
            foreach (var item in db.Sp_PreguntaEncajonadaConsultar().Where(c => c.IdPreguntaEncajonada == _idPreguntaEncajonada).ToList())
            {
                _lista.Add(new PreguntaEncajonada()
                {
                    IdPreguntaEncajonada = item.IdPreguntaEncajonada,
                    IdPreguntaEncajonadaEncriptado = _seguridad.Encriptar(item.IdPreguntaEncajonada.ToString()),
                    Estado = item.EstadoPreguntaEncajonada,
                    Utilizado = item.UtilizadoPreguntaEncajonada,
                    OpcionPreguntaSeleccion = new OpcionPreguntaSeleccion()
                    {
                        IdOpcionPreguntaSeleccion = item.IdOpcionPreguntaSeleccion,
                        IdOpcionPreguntaSeleccionEncriptado = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                        Descripcion = item.DescripcionOpcionPreguntaSeleccion,
                        Estado = item.EstadoOpcionPreguntaSeleccion,
                        Pregunta = new Pregunta()
                        {
                            IdPregunta = item.IdPreguntaOpcionPreguntaSeleccion,
                            IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPreguntaOpcionPreguntaSeleccion.ToString())
                        }
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString()),
                        Descripcion = item.DescripcionPregunta,
                        Estado = item.EstadoPregunta,
                        Obligatorio = item.ObligatorioPregunta,
                        Orden = item.OrdenPregunta,
                        TipoPregunta = new TipoPregunta()
                        {
                            IdTipoPregunta = item.IdTipoPregunta,
                            IdTipoPreguntaEncriptado = _seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                            Descripcion = item.DescripcionTipoPregunta,
                            Estado = item.EstadoTipoPregunta,
                            Identificador = item.IdentificadorTipoPregunta
                        },
                        Seccion = new Seccion()
                        {
                            IdSeccion = item.IdSeccion,
                            IdSeccionEncriptado = _seguridad.Encriptar(item.IdSeccion.ToString()),
                            Descripcion = item.DescripcionSeccion,
                            Estado = item.EstadoSeccion,
                            Orden = item.OrdenSeccion,
                            Componente = new Componente()
                            {
                                IdComponente = item.IdComponente,
                                IdComponenteEncriptado = _seguridad.Encriptar(item.IdComponente.ToString()),
                                Descripcion = item.DescripcionComponente,
                                Estado = item.EstadoComponente,
                                Orden = item.OrdenComponente,
                                CuestionarioGenerico = new CuestionarioGenerico()
                                {
                                    IdCuestionarioGenerico = item.IdCuestionarioGenerico,
                                    IdCuestionarioGenericoEncriptado = _seguridad.Encriptar(item.IdCuestionarioGenerico.ToString()),
                                    Descripcion = item.DescripcionCuestionarioGenerico,
                                    Estado = item.EstadoCuestionarioGenerico,
                                    Nombre = item.NombreCuestionarioGenerico
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