using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;
using System.IO;
using System.Drawing;

namespace API.Models.Catalogos
{
    public class CatalogoComunidad
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Comunidad> ConsultarComunidad()
        {
            List<Comunidad> _lista = new List<Comunidad>();
            foreach (var item in db.Sp_ComunidadConsultar())
            {
                _lista.Add(new Comunidad()
                {
                    IdComunidad = item.IdComunidad,
                    IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                    CodigoComunidad = item.CodigoComunidad,
                    DescripcionComunidad = item.DescripcionComunidad,
                    EstadoComunidad = item.EstadoComunidad,
                    NombreComunidad = item.NombreComunidad,
                 //   RutaLogoComunidad = item.RutaLogoComunidad,
                    Utilizado = item.UtilizadoComunidad,
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

        public List<Comunidad> ConsultarComunidadPorId(int _idComunidad)
        {
            List<Comunidad> _lista = new List<Comunidad>();
            foreach (var item in db.Sp_ComunidadConsultar().Where(c=>c.IdComunidad==_idComunidad).ToList())
            {
                _lista.Add(new Comunidad()
                {
                    IdComunidad = item.IdComunidad,
                    IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                    CodigoComunidad = item.CodigoComunidad,
                    DescripcionComunidad = item.DescripcionComunidad,
                    EstadoComunidad = item.EstadoComunidad,
                    NombreComunidad = item.NombreComunidad,
                //    RutaLogoComunidad = item.RutaLogoComunidad,
                    Utilizado = item.UtilizadoComunidad,
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

        public List<Comunidad> ConsultarComunidadPorIdParroquia(int _idParroquia)
        {
            List<Comunidad> _lista = new List<Comunidad>();
            foreach (var item in db.Sp_ComunidadConsultar().Where(c => c.IdParroquia == _idParroquia).ToList())
            {
                _lista.Add(new Comunidad()
                {
                    IdComunidad = item.IdComunidad,
                    IdComunidadEncriptado = _seguridad.Encriptar(item.IdComunidad.ToString()),
                    CodigoComunidad = item.CodigoComunidad,
                    DescripcionComunidad = item.DescripcionComunidad,
                    EstadoComunidad = item.EstadoComunidad,
                    NombreComunidad = item.NombreComunidad,
                  //  RutaLogoComunidad = item.RutaLogoComunidad,
                    Utilizado = item.UtilizadoComunidad,
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

        public int InsertarComunidad(Comunidad _objComunidad)
        {
            try
            {


               // Image bitmap = Image.FromFile("C:\\MyFile.bmp");
                //itmap.Save("~/Uploads/Photo/");
              //  var filename = Path.GetFileName(_objComunidad.RutaLogoComunidad);
                // System.Drawing.Image img =
                //  System.Drawing.Image.FromFile(System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/Photo/"), true);
                //var filename = Path.GetFileName(_objComunidad.RutaLogoComunidad.FileName);
               //var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Imagenes/"), filename);
               //  _objComunidad.RutaLogoComunidad.SaveAs(path);
                // Add avatar reference to model and save
                //model.AvatarUrl = string.Concat("Uploads/Photo/", filename);
                //_db.EventModels.AddObject(model);
                //_db.SaveChanges();


                byte[] myByte = System.Text.Encoding.UTF8.GetBytes(_objComunidad.RutaLogoComunidad);
                string myBase64 = Convert.ToBase64String(myByte);
                return int.Parse(db.Sp_ComunidadInsertar(_objComunidad.Parroquia.IdParroquia, _objComunidad.CodigoComunidad, _objComunidad.NombreComunidad, _objComunidad.DescripcionComunidad, myBase64, _objComunidad.EstadoComunidad).Select(x => x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public int ModificarComunidad(Comunidad _objComunidad)
        {
            try
            {
                db.Sp_ComunidadModificar(_objComunidad.IdComunidad, _objComunidad.Parroquia.IdParroquia, _objComunidad.CodigoComunidad, _objComunidad.NombreComunidad, _objComunidad.DescripcionComunidad, _objComunidad.RutaLogoComunidad, _objComunidad.EstadoComunidad);
                return _objComunidad.IdComunidad;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarComunidad(int _idComunidad)
        {
            db.Sp_ComunidadEliminar(_idComunidad);
        }
    }
}