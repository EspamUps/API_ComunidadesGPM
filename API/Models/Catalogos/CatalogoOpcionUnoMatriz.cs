using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoOpcionUnoMatriz
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int InsertarOpcionUnoMatriz(OpcionUnoMatriz _objOpcionUnoMatriz)
        {
            try
            {
                return int.Parse(db.Sp_OpcionUnoMatrizInsertar(_objOpcionUnoMatriz.Pregunta.IdPregunta, _objOpcionUnoMatriz.Descripcion, _objOpcionUnoMatriz.Estado).Select(c => c.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void EliminarOpcionUnoMatriz(int _idOpcionUnoMatriz)
        {
            db.Sp_OpcionUnoMatrizEliminar(_idOpcionUnoMatriz);
        }
        public List<OpcionUnoMatriz> ConsultarOpcionUnoMatriz()
        {
            List<OpcionUnoMatriz> _lista = new List<OpcionUnoMatriz>();
            foreach (var item in db.Sp_OpcionUnoMatrizConsultar())
            {
                _lista.Add(new OpcionUnoMatriz()
                {
                    IdOpcionUnoMatriz = item.IdOpcionUnoMatriz,
                    IdOpcionUnoMatrizEncriptado = _seguridad.Encriptar(item.IdOpcionUnoMatriz.ToString()),
                    Descripcion = item.DescripcionOpcionUnoMatriz,
                    Estado = item.EstadoOpcionOpcionUnoMatriz,
                    Utilizado = item.UtilizadoOpcionUnoMatriz,
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
        public List<OpcionUnoMatriz> ConsultarOpcionUnoMatrizPorId(int _idOpcionUnoMatriz)
        {
            List<OpcionUnoMatriz> _lista = new List<OpcionUnoMatriz>();
            foreach (var item in db.Sp_OpcionUnoMatrizConsultar().Where(c=>c.IdOpcionUnoMatriz==_idOpcionUnoMatriz).ToList())
            {
                _lista.Add(new OpcionUnoMatriz()
                {
                    IdOpcionUnoMatriz = item.IdOpcionUnoMatriz,
                    IdOpcionUnoMatrizEncriptado = _seguridad.Encriptar(item.IdOpcionUnoMatriz.ToString()),
                    Descripcion = item.DescripcionOpcionUnoMatriz,
                    Estado = item.EstadoOpcionOpcionUnoMatriz,
                    Utilizado = item.UtilizadoOpcionUnoMatriz,
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
        public List<OpcionUnoMatriz> ConsultarOpcionUnoMatrizPorIdPregunta(int _idPregunta)
        {
            List<OpcionUnoMatriz> _lista = new List<OpcionUnoMatriz>();
            foreach (var item in db.Sp_OpcionUnoMatrizConsultar().Where(c => c.IdPregunta == _idPregunta).ToList())
            {
                _lista.Add(new OpcionUnoMatriz()
                {
                    IdOpcionUnoMatriz = item.IdOpcionUnoMatriz,
                    IdOpcionUnoMatrizEncriptado = _seguridad.Encriptar(item.IdOpcionUnoMatriz.ToString()),
                    Descripcion = item.DescripcionOpcionUnoMatriz,
                    Estado = item.EstadoOpcionOpcionUnoMatriz,
                    Utilizado = item.UtilizadoOpcionUnoMatriz,
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