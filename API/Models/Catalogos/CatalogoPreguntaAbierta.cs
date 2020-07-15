using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;


namespace API.Models.Catalogos
{
    public class CatalogoPreguntaAbierta
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public int InsertarPreguntaAbierta (PreguntaAbierta _objPreguntaAbierta)
        {
            try
            {
                return int.Parse(db.Sp_PreguntaAbiertaInsertar(_objPreguntaAbierta.Pregunta.IdPregunta, _objPreguntaAbierta.TipoDato.IdTipoDato, _objPreguntaAbierta.EspecificaRango, _objPreguntaAbierta.ValorMinimo, _objPreguntaAbierta.ValorMaximo, _objPreguntaAbierta.Estado).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarPreguntaAbierta(int _idPreguntaAbierta)
        {
            db.Sp_PreguntaAbiertaEliminar(_idPreguntaAbierta);
        }

        public List<PreguntaAbierta> ConsultarPreguntaAbierta()
        {
            List<PreguntaAbierta> _lista = new List<PreguntaAbierta>();
            foreach (var item in db.Sp_PreguntaAbiertaConsultar())
            {
                _lista.Add(new PreguntaAbierta()
                {
                    IdPreguntaAbierta = item.IdPreguntaAbierta,
                    IdPreguntaAbiertaEncriptado = _seguridad.Encriptar(item.IdPreguntaAbierta.ToString()),
                    EspecificaRango = item.EspecificaRangoPreguntaAbierta,
                    ValorMaximo = item.ValorMaximoPreguntaAbierta,
                    ValorMinimo = item.ValorMinimoPreguntaAbierta,
                    Estado = item.EstadoPreguntaAbierta,
                    Utilizado = item.UtilizadoPreguntaAbierta,
                    Encajonamiento = item.EncajonamientoPreguntaAbierta,
                    TipoDato = new TipoDato()
                    {
                        IdTipoDato = item.IdTipoDato,
                        IdTipoDatoEncriptado = _seguridad.Encriptar(item.IdTipoDato.ToString()),
                        Identificador = item.IdentificadorTipoDato,
                        Descripcion = item.DescripcionTipoDato,
                        Estado = item.EstadoTipoDato,
                        TipoHTML = item.TipoHTMLTipoDato
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


        public List<PreguntaAbierta> ConsultarPreguntaAbiertaPorId(int _idPreguntaAbierta)
        {
            List<PreguntaAbierta> _lista = new List<PreguntaAbierta>();
            foreach (var item in db.Sp_PreguntaAbiertaConsultar().Where(c=>c.IdPreguntaAbierta == _idPreguntaAbierta).ToList())
            {
                _lista.Add(new PreguntaAbierta()
                {
                    IdPreguntaAbierta = item.IdPreguntaAbierta,
                    IdPreguntaAbiertaEncriptado = _seguridad.Encriptar(item.IdPreguntaAbierta.ToString()),
                    EspecificaRango = item.EspecificaRangoPreguntaAbierta,
                    ValorMaximo = item.ValorMaximoPreguntaAbierta,
                    ValorMinimo = item.ValorMinimoPreguntaAbierta,
                    Estado = item.EstadoPreguntaAbierta,
                    Utilizado = item.UtilizadoPreguntaAbierta,
                    Encajonamiento = item.EncajonamientoPreguntaAbierta,
                    TipoDato = new TipoDato()
                    {
                        IdTipoDato = item.IdTipoDato,
                        IdTipoDatoEncriptado = _seguridad.Encriptar(item.IdTipoDato.ToString()),
                        Identificador = item.IdentificadorTipoDato,
                        Descripcion = item.DescripcionTipoDato,
                        Estado = item.EstadoTipoDato,
                        TipoHTML = item.TipoHTMLTipoDato
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

        public List<PreguntaAbierta> ConsultarPreguntaAbiertaPorIdPregunta(int _idPregunta)
        {
            List<PreguntaAbierta> _lista = new List<PreguntaAbierta>();
            foreach (var item in db.Sp_PreguntaAbiertaConsultar().Where(c => c.IdPregunta == _idPregunta).ToList())
            {
                _lista.Add(new PreguntaAbierta()
                {
                    IdPreguntaAbierta = item.IdPreguntaAbierta,
                    IdPreguntaAbiertaEncriptado = _seguridad.Encriptar(item.IdPreguntaAbierta.ToString()),
                    EspecificaRango = item.EspecificaRangoPreguntaAbierta,
                    ValorMaximo = item.ValorMaximoPreguntaAbierta,
                    ValorMinimo = item.ValorMinimoPreguntaAbierta,
                    Estado = item.EstadoPreguntaAbierta,
                    Utilizado = item.UtilizadoPreguntaAbierta,
                    Encajonamiento = item.EncajonamientoPreguntaAbierta,
                    TipoDato = new TipoDato()
                    {
                        IdTipoDato = item.IdTipoDato,
                        IdTipoDatoEncriptado = _seguridad.Encriptar(item.IdTipoDato.ToString()),
                        Identificador = item.IdentificadorTipoDato,
                        Descripcion = item.DescripcionTipoDato,
                        Estado = item.EstadoTipoDato,
                        TipoHTML = item.TipoHTMLTipoDato
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