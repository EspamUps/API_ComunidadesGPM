using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models.Catalogos;
using API.Models.Entidades;
using API.Models.Metodos;
using Rotativa.Core.Options;
using IronPdf;
using System.IO;
using System.Net.Http;

namespace API.Controllers
{
    public class ReporteCuestionarioController : Controller
    {
        CatalogoCuestionarioGenerico _objCatalogoCuestionarioGenerico = new CatalogoCuestionarioGenerico();
        Seguridad _seguridad = new Seguridad();
        //CatalogoOpcionPreguntaSeleccion _objCatalogoOpcionPreguntaSeleccion = new CatalogoOpcionPreguntaSeleccion();
        //CatalogoConfigurarMatriz _objCatalogoConfigurarMatriz = new CatalogoConfigurarMatriz();
        //CatalogoPregunta _objCatalogoPregunta = new CatalogoPregunta();
        public ActionResult Cuestionario(string CuestionarioGenericoEncriptado, string VersionEncriptado, string ComunidadEncriptado)
        {
            int _idCuestionario = Convert.ToInt32(_seguridad.DesEncriptar(CuestionarioGenericoEncriptado));
            int _idVersion = Convert.ToInt32(VersionEncriptado);
            int _idComunidad = Convert.ToInt32(_seguridad.DesEncriptar(ComunidadEncriptado));
            var _objCuestionario = _objCatalogoCuestionarioGenerico.ConsultarPreguntasRandomCopia(_idCuestionario, _idVersion, _idComunidad).Where(c => c.Estado == true).FirstOrDefault();
            ViewBag.Cuestionario = _objCuestionario;
            //return View("Cuestionario");
            string footer = "--footer-center \"Impreso el: " + DateTime.Now.Date.ToString("MM/dd/yyyy") + " Página: [page]/[toPage]\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
            return new Rotativa.MVC.PartialViewAsPdf("Cuestionario")
            {
                RotativaOptions = new Rotativa.Core.DriverOptions()
                {
                    PageOrientation = Orientation.Portrait,
                    PageSize = Rotativa.Core.Options.Size.A4,
                    IsLowQuality = true,
                    CustomSwitches = footer
                }
            };
        }
        //[HttpPost]
        //public JsonResult opcionPreguntaSeleccions(string _idPreguntaEnctriptada)
        //{
        //    //return _informacion._idPreguntaEnctriptada;
        //    return Json(_objCatalogoOpcionPreguntaSeleccion.ConsultarOpcionPreguntaSeleccionPorIdPregunta(int.Parse(_seguridad.DesEncriptar(_idPreguntaEnctriptada))).Where(c => c.Estado == true).ToList());
        //}
        //[HttpPost]
        //public JsonResult configurarmatriz_consultarporidpregunta(string _idPreguntaEnctriptada)
        //{
        //    var _objPregunta = _objCatalogoPregunta.ConsultarPreguntaPorId(int.Parse(_seguridad.DesEncriptar(_idPreguntaEnctriptada))).Where(c => c.Estado == true).FirstOrDefault();
        //    var _objConfigurarMatriz =_objCatalogoConfigurarMatriz.ConsultarConfigurarMatrizPorIdPregunta(int.Parse(_seguridad.DesEncriptar(_idPreguntaEnctriptada))).Where(c => c.Estado == true);
        //    return Json(new { Pregunta = _objPregunta, Matriz = _objConfigurarMatriz });
        //}

    }
}