using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace API.Models.Catalogos
{
    public class CatalogoModeloPublicado
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        CatalogoPeriodo _objPeriodo = new CatalogoPeriodo();
        CatalogoAsignarUsuarioTipoUsuario _objUsuarioTipoUsuario = new CatalogoAsignarUsuarioTipoUsuario();
        CatalogoAsignarModeloGenericoParroquia _objModeloGenericoParroquia = new CatalogoAsignarModeloGenericoParroquia();
        public int InsertarModeloPublicado(ModeloPublicado _objModeloPublicado)
        {
            try
            {
                foreach (var item in db.Sp_CabeceraModeloPublicadoInsertar(int.Parse(_objModeloPublicado.IdCabeceraVersionModelo),int.Parse(_objModeloPublicado.IdPeriodo),int.Parse(_objModeloPublicado.IdAsignarUsuarioTipoUsuario)))
                {
                    _objModeloPublicado.IdModeloPublicado = item.IdModeloPublicado;
                }
                return _objModeloPublicado.IdModeloPublicado;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void EliminarModeloPublicado(int _idModeloPublicado)
        {
            db.Sp_CabeceraModeloPublicadoEliminar(_idModeloPublicado);
        }
        public List<ModeloPublicado> ConsultarModeloPublicado()
        {
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoConsultar())
            {
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.ModeloPublicadoIdModeloPublicado.ToString()),
                    FechaPublicacion = item.ModeloPublicadoFechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.ModeloPublicadoIdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.ModeloPublicadoIdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.ModeloPublicadoIdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ModeloPublicadoEstado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = new Periodo()
                    {
                        IdPeriodoEncriptado = _seguridad.Encriptar(item.PeriodoIdPeriodo.ToString()),
                        Descripcion = item.PeriodoDescripcion,
                        Estado = item.PeriodoEstado,
                        FechaFin = item.PeriodoFechaFin,
                        FechaInicio = item.PeriodoFechaInicio
                    },
                    CabeceraVersionModelo = new CabeceraVersionModelo()
                    {
                        IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.CabeceraVersionModeloIdCabeceraVersionModelo.ToString()),
                        Version = item.CabeceraVersionModeloVersion,
                        Caracteristica = item.CabeceraVersionModeloCaracteristica,
                        Estado = item.CabeceraVersionModeloEstado,
                        FechaCreacion = item.CabeceraVersionModeloFechaCreacion,
                        IdModeloGenerico = _seguridad.Encriptar(item.CabeceraVersionModeloIdModeloGenerico.ToString()),
                        ModeloGenerico = new ModeloGenerico()
                        {
                            IdModeloGenericoEncriptado = _seguridad.Encriptar(item.ModeloGenericoIdModeloGenerico.ToString()),
                            Descripcion = item.ModeloGenericoDescripcion,
                            Estado = item.ModeloGenericoEstado,
                            Nombre = item.ModeloGenericoNombre
                        }
                    }
                });
            }
            return _lista;
        }
        public List<ModeloPublicado> ConsultarModeloPublicadoPorId(int _idModeloPublicado)
        {
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoPorIdConsultar(_idModeloPublicado))
            {
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.ModeloPublicadoIdModeloPublicado.ToString()),
                    FechaPublicacion = item.ModeloPublicadoFechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.ModeloPublicadoIdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.ModeloPublicadoIdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.ModeloPublicadoIdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ModeloPublicadoEstado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = new Periodo()
                    {
                        IdPeriodoEncriptado = _seguridad.Encriptar(item.PeriodoIdPeriodo.ToString()),
                        Descripcion = item.PeriodoDescripcion,
                        Estado = item.PeriodoEstado,
                        FechaFin = item.PeriodoFechaFin,
                        FechaInicio = item.PeriodoFechaInicio
                    },
                    CabeceraVersionModelo = new CabeceraVersionModelo()
                    {
                        IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.CabeceraVersionModeloIdCabeceraVersionModelo.ToString()),
                        Version = item.CabeceraVersionModeloVersion,
                        Caracteristica = item.CabeceraVersionModeloCaracteristica,
                        Estado = item.CabeceraVersionModeloEstado,
                        FechaCreacion = item.CabeceraVersionModeloFechaCreacion,
                        IdModeloGenerico = _seguridad.Encriptar(item.CabeceraVersionModeloIdModeloGenerico.ToString()),
                        ModeloGenerico = new ModeloGenerico()
                        {
                            IdModeloGenericoEncriptado = _seguridad.Encriptar(item.ModeloGenericoIdModeloGenerico.ToString()),
                            Descripcion = item.ModeloGenericoDescripcion,
                            Estado = item.ModeloGenericoEstado,
                            Nombre = item.ModeloGenericoNombre
                        }
                    }
                });
            }
            return _lista;
        }
        public void HabilitarModeloPublicado(int _idModeloPublicado)
        {
            db.Sp_HabilitarModeloPublicado(_idModeloPublicado);
        }
        public void DesHabilitarModeloPublicad(int _idModeloPublicado)
        {
            db.Sp_DesHabilitarModeloPublicado(_idModeloPublicado);
        }
        public List<ModeloPublicado> ConsultarVersionesPublicadoActivos(int _idModeloGenerico)
        {
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoActivoConsultar(_idModeloGenerico))
            {
                List<AsignarCuestionarioModelo> CuestionarioModelo = new List<AsignarCuestionarioModelo>();
                CuestionarioModelo.Add(new AsignarCuestionarioModelo()
                {
                    IdAsignarCuestionarioModelo = 0,
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.CuestionarioPublicadoIdCuestionarioPublicado.ToString()),
                        Estado = item.CuestionarioPublicadoEstado,
                        FechaPublicacion = item.CuestionarioPublicadoFechaPublicacion,
                        CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                        {
                            Caracteristica = item.CabeceraVersionCuestionarioCaracteristica,
                            FechaCreacion = item.CabeceraVersionCuestionarioFechaCreacion,
                            Version = item.CabeceraVersionCuestionarioVersion
                        }
                    }
                });
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.ModeloPublicadoIdModeloPublicado.ToString()),
                    FechaPublicacion = item.ModeloPublicadoFechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.ModeloPublicadoIdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.ModeloPublicadoIdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.ModeloPublicadoIdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.ModeloPublicadoEstado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = new Periodo()
                    {
                        IdPeriodoEncriptado = _seguridad.Encriptar(item.PeriodoIdPeriodo.ToString()),
                        Descripcion = item.PeriodoDescripcion,
                        Estado = item.PeriodoEstado,
                        FechaFin = item.PeriodoFechaFin,
                        FechaInicio = item.PeriodoFechaInicio
                    },
                    CabeceraVersionModelo = new CabeceraVersionModelo()
                    {
                        IdCabeceraVersionModeloEncriptado = _seguridad.Encriptar(item.CabeceraVersionModeloIdCabeceraVersionModelo.ToString()),
                        Version = item.CabeceraVersionModeloVersion,
                        Caracteristica = item.CabeceraVersionModeloCaracteristica,
                        Estado = item.CabeceraVersionModeloEstado,
                        FechaCreacion = item.CabeceraVersionModeloFechaCreacion,
                        IdModeloGenerico = _seguridad.Encriptar(item.CabeceraVersionModeloIdModeloGenerico.ToString()),
                        ModeloGenerico = new ModeloGenerico()
                        {
                            IdModeloGenericoEncriptado = _seguridad.Encriptar(item.ModeloGenericoIdModeloGenerico.ToString()),
                            Descripcion = item.ModeloGenericoDescripcion,
                            Estado = item.ModeloGenericoEstado,
                            Nombre = item.ModeloGenericoNombre,
                            AsignarCuestionarioModelo = CuestionarioModelo
                        }
                    }
                });
            }
            return _lista;
        }
        public List<ModeloGenerico> ModeloGenericoConVersionesActivas()
        {
            List<ModeloGenerico> _lista = new List<ModeloGenerico>();
            foreach (var item in db.Sp_ModeloGenericoConVersionesActivas())
            {
                List<AsignarCuestionarioModelo> CuestionarioModelo = new List<AsignarCuestionarioModelo>();
                CuestionarioModelo.Add(new AsignarCuestionarioModelo()
                {
                    IdAsignarCuestionarioModelo = 0,
                    CuestionarioPublicado = new CuestionarioPublicado()
                    {
                        IdCuestionarioPublicadoEncriptado = _seguridad.Encriptar(item.CuestionarioPublicadoIdCuestionarioPublicado.ToString()),
                        Estado = item.CuestionarioPublicadoEstado,
                        FechaPublicacion = item.CuestionarioPublicadoFechaPublicacion,
                        CuestionarioGenerico = new CuestionarioGenerico()
                        {
                            Nombre = item.CuestionarioGenericoNombre,
                            Descripcion = item.CuestionarioGenericoDescripcion,
                        },
                        CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                        {
                            Caracteristica = item.CabeceraVersionCuestionarioCaracteristica,
                            FechaCreacion = item.CabeceraVersionCuestionarioFechaCreacion,
                            Version = item.CabeceraVersionCuestionarioVersion,
                        }
                    },
                });
                _lista.Add(new ModeloGenerico()
                {
                    IdModeloGenericoEncriptado = _seguridad.Encriptar(item.ModeloGenericoIdModeloGenerico.ToString()),
                    Nombre = item.ModeloGenericoNombre,
                    Descripcion = item.ModeloGenericoDescripcion,
                    Estado = item.ModeloGenericoEstado,
                    AsignarCuestionarioModelo = CuestionarioModelo
                });
            }
            return _lista;
        }
    }
}