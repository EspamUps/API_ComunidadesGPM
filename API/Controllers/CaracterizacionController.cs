using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using Rotativa.Core.Options;
using API.Models.Entidades;
using API.Models.Catalogos;
using API.Models.Metodos;

namespace API.Controllers
{
    public class CaracterizacionController : Controller
    {
        Seguridad _seguridad = new Seguridad();
        CatalogoModeloPublicado _objModeloPublico = new CatalogoModeloPublicado();
        CatalogoCabeceraVersionModelo _objCabeceraVersionModelo = new CatalogoCabeceraVersionModelo();
        public ActionResult Caracterizacion(string Encuesta, string Caracterizacion)
        {
            CabeceraRespuesta _CabeceraRespuesta = new CabeceraRespuesta();
            _CabeceraRespuesta = _objModeloPublico.ConsultarEncuestasFinalizadasPorId(int.Parse(_seguridad.DesEncriptar(Encuesta))).FirstOrDefault();
            ViewBag.Encuesta = _CabeceraRespuesta;
            ViewBag.Caracterizacion = _objCabeceraVersionModelo.ConsultarInformacionVersion(int.Parse(_seguridad.DesEncriptar(Caracterizacion)), int.Parse(_seguridad.DesEncriptar(_CabeceraRespuesta.AsignarEncuestado.IdAsignarEncuestadoEncriptado)));
            return new Rotativa.MVC.PartialViewAsPdf("Caracterizacion")
            {
                RotativaOptions = new Rotativa.Core.DriverOptions()
                {
                    PageOrientation = Orientation.Portrait,
                    PageSize = Rotativa.Core.Options.Size.A4,
                    IsLowQuality = true,
                }
            };
        }
    }
}