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
            var ListaPeriodos = _objPeriodo.ConsultarPeriodo();
            var ListaUsuarioTipoUsuario = _objUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloGenericoParroquia = _objModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquia();
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoConsultar())
            {
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicado = item.IdModeloPublicado,
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                    FechaPublicacion = item.FechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.Estado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = ListaPeriodos.Where(p=>p.IdPeriodo == item.IdPeriodo).FirstOrDefault(),
                    AsignarUsuarioTipoUsuario = ListaUsuarioTipoUsuario.Where(p=>p.IdAsignarUsuarioTipoUsuario == item.IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    AsignarModeloGenericoParroquia = ListaModeloGenericoParroquia.Where(p=>_seguridad.DesEncriptar(p.IdModeloPublicado) == item.IdModeloPublicado.ToString()).ToList()
                });
            }
            return _lista;
        }

        public List<ModeloPublicado> ConsultarModeloPublicadoPorId(int _idModeloPublicado)
        {
            var ListaPeriodos = _objPeriodo.ConsultarPeriodo();
            var ListaUsuarioTipoUsuario = _objUsuarioTipoUsuario.ConsultarAsignarUsuarioTipoUsuario();
            var ListaModeloGenericoParroquia = _objModeloGenericoParroquia.ConsultarAsignarModeloGenericoParroquia();
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_CabeceraModeloPublicadoConsultar().Where(p=>p.IdModeloPublicado == _idModeloPublicado).ToList())
            {
                _lista.Add(new ModeloPublicado()
                {
                    IdModeloPublicado = item.IdModeloPublicado,
                    IdModeloPublicadoEncriptado = _seguridad.Encriptar(item.IdModeloPublicado.ToString()),
                    FechaPublicacion = item.FechaPublicacion,
                    IdCabeceraVersionModelo = _seguridad.Encriptar(item.IdCabeceraVersionModelo.ToString()),
                    IdPeriodo = _seguridad.Encriptar(item.IdPeriodo.ToString()),
                    IdAsignarUsuarioTipoUsuario = _seguridad.Encriptar(item.IdAsignarUsuarioTipoUsuario.ToString()),
                    Estado = item.Estado,
                    Utilizado = item.ModeloPublicadoUtilizado,
                    Periodo = ListaPeriodos.Where(p => p.IdPeriodo == item.IdPeriodo).FirstOrDefault(),
                    AsignarUsuarioTipoUsuario = ListaUsuarioTipoUsuario.Where(p => p.IdAsignarUsuarioTipoUsuario == item.IdAsignarUsuarioTipoUsuario).FirstOrDefault(),
                    AsignarModeloGenericoParroquia = ListaModeloGenericoParroquia.Where(p => _seguridad.DesEncriptar(p.IdModeloPublicado) == item.IdModeloPublicado.ToString()).ToList()
                });
            }
            return _lista;
        }

        public List<ModeloPublicado> ConsultarModeloPublicadoPorIdDHBD(int _idModeloPublicado)
        {
            List<ModeloPublicado> _lista = new List<ModeloPublicado>();
            foreach (var item in db.Sp_ModeloPublicadoConsultarPorId(_idModeloPublicado))
            {
                _lista.Add(new ModeloPublicado()
                {
                    Utilizado=item.UtilizadoModeloPublicado,
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
                });
            }
            return _lista;
        }


    }
}