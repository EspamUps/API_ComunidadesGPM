using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoPresidenteJuntaParroquial
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public List<PresidenteJuntaParroquial> ConsultarPresidenteJuntaParroquial()
        {
            List<PresidenteJuntaParroquial> _lista = new List<PresidenteJuntaParroquial>();
            foreach (var item in db.Sp_PresidenteJuntaParroquialConsultar())
            {
                _lista.Add(new PresidenteJuntaParroquial()
                {
                    IdPresidenteJuntaParroquial = item.IdPresidenteJuntaParroquial,
                    IdPresidenteJuntaParroquialEncriptado = _seguridad.Encriptar(item.IdPresidenteJuntaParroquial.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoPresidenteJuntaParroquial,
                    Utilizado = item.UtilizadoPresidenteJuntaParroquial,
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
                });
            }
            return _lista;
        }

        public List<PresidenteJuntaParroquial> ConsultarPresidenteJuntaParroquialPorId(int _idPresidenteJuntaParroquial)
        {
            List<PresidenteJuntaParroquial> _lista = new List<PresidenteJuntaParroquial>();
            foreach (var item in db.Sp_PresidenteJuntaParroquialConsultar().Where(c=>c.IdPresidenteJuntaParroquial==_idPresidenteJuntaParroquial).ToList())
            {
                _lista.Add(new PresidenteJuntaParroquial()
                {
                    IdPresidenteJuntaParroquial = item.IdPresidenteJuntaParroquial,
                    IdPresidenteJuntaParroquialEncriptado = _seguridad.Encriptar(item.IdPresidenteJuntaParroquial.ToString()),
                    Representante = item.Representante,
                    FechaIngreso = item.FechaIngreso,
                    FechaSalida = Convert.ToDateTime(item.FechaSalida),
                    Estado = item.EstadoPresidenteJuntaParroquial,
                    Utilizado = item.UtilizadoPresidenteJuntaParroquial,
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
                });
            }
            return _lista;
        }


        public int InsertarPresidenteJuntaParroquial(PresidenteJuntaParroquial _objPresidenteJuntaParroquial)
        {
            try
            {
                return int.Parse(db.Sp_PresidenteJuntaParroquialInsertar(_objPresidenteJuntaParroquial.Parroquia.IdParroquia,_objPresidenteJuntaParroquial.Representante,_objPresidenteJuntaParroquial.FechaIngreso,_objPresidenteJuntaParroquial.FechaSalida, _objPresidenteJuntaParroquial.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarPresidenteJuntaParroquial(PresidenteJuntaParroquial _objPresidenteJuntaParroquial)
        {
            try
            {
                db.Sp_PresidenteJuntaParroquialModificar(_objPresidenteJuntaParroquial.IdPresidenteJuntaParroquial ,_objPresidenteJuntaParroquial.Parroquia.IdParroquia, _objPresidenteJuntaParroquial.Representante, _objPresidenteJuntaParroquial.FechaIngreso, _objPresidenteJuntaParroquial.FechaSalida, _objPresidenteJuntaParroquial.Estado);
                return _objPresidenteJuntaParroquial.IdPresidenteJuntaParroquial;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarPresidenteJuntaParroquial(int _idPresidenteJuntaParroquial)
        {
            db.Sp_PresidenteJuntaParroquialEliminar(_idPresidenteJuntaParroquial);
        }
    }
}