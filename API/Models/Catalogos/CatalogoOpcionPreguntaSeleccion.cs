using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoOpcionPreguntaSeleccion
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarOpcionPreguntaSeleccion(OpcionPreguntaSeleccion _objOpcionPreguntaSeleccion)
        {
            try
            {
                return int.Parse(db.Sp_OpcionPreguntaSeleccionInsertar(_objOpcionPreguntaSeleccion.Pregunta.IdPregunta,_objOpcionPreguntaSeleccion.Descripcion,_objOpcionPreguntaSeleccion.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EditarOpcionPreguntaSeleccion(OpcionPreguntaSeleccion _objOpcionPreguntaSeleccion)
        {
            try
            {
                return int.Parse(db.Sp_OpcionPreguntaSeleccionEditar(_objOpcionPreguntaSeleccion.Pregunta.IdPregunta, _objOpcionPreguntaSeleccion.IdOpcionPreguntaSeleccion, _objOpcionPreguntaSeleccion.Descripcion, _objOpcionPreguntaSeleccion.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarOpcionPreguntaSeleccion(int _idOpcionPreguntaSeleccion)
        {
            db.Sp_OpcionPreguntaSeleccionEliminar(_idOpcionPreguntaSeleccion);
        }
        public List<OpcionPreguntaSeleccion> ConsultarOpcionPreguntaSeleccion()
        {
            List<OpcionPreguntaSeleccion> _lista = new List<OpcionPreguntaSeleccion>();
            foreach (var item in db.Sp_OpcionPreguntaSeleccionConsultar())
            {
                _lista.Add(new OpcionPreguntaSeleccion()
                {
                    IdOpcionPreguntaSeleccion=item.IdOpcionPreguntaSeleccion,
                    IdOpcionPreguntaSeleccionEncriptado = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                    Descripcion=item.DescripcionOpcionPreguntaSeleccion,
                    Estado=item.EstadoOpcionPreguntaSeleccion,
                    Utilizado=item.UtilizadoOpcionPreguntaSeleccion,
                    Encajonamiento = item.EncajonamientoOpcionPreguntaSeleccion,
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
        public List<OpcionPreguntaSeleccion> ConsultarOpcionPreguntaSeleccionPorId(int _idOpcionPreguntaSeleccion)
        {
            List<OpcionPreguntaSeleccion> _lista = new List<OpcionPreguntaSeleccion>();
            foreach (var item in db.Sp_OpcionPreguntaSeleccionConsultar().Where(c=>c.IdOpcionPreguntaSeleccion== _idOpcionPreguntaSeleccion).ToList())
            {
                _lista.Add(new OpcionPreguntaSeleccion()
                {
                    IdOpcionPreguntaSeleccion = item.IdOpcionPreguntaSeleccion,
                    IdOpcionPreguntaSeleccionEncriptado = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                    Descripcion = item.DescripcionOpcionPreguntaSeleccion,
                    Estado = item.EstadoOpcionPreguntaSeleccion,
                    Utilizado = item.UtilizadoOpcionPreguntaSeleccion,
                    Encajonamiento = item.EncajonamientoOpcionPreguntaSeleccion,
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
        public List<OpcionPreguntaSeleccion> ConsultarOpcionPreguntaSeleccionPorIdPregunta(int _idPregunta)
        {
            List<OpcionPreguntaSeleccion> _lista = new List<OpcionPreguntaSeleccion>();
            foreach (var item in db.Sp_OpcionPreguntaSeleccionConsultar().Where(c=>c.IdPregunta== _idPregunta).ToList())
            {
                _lista.Add(new OpcionPreguntaSeleccion()
                {
                    IdOpcionPreguntaSeleccion = item.IdOpcionPreguntaSeleccion,
                    IdOpcionPreguntaSeleccionEncriptado = _seguridad.Encriptar(item.IdOpcionPreguntaSeleccion.ToString()),
                    Descripcion = item.DescripcionOpcionPreguntaSeleccion,
                    Estado = item.EstadoOpcionPreguntaSeleccion,
                    Utilizado = item.UtilizadoOpcionPreguntaSeleccion,
                    Encajonamiento = item.EncajonamientoOpcionPreguntaSeleccion,
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