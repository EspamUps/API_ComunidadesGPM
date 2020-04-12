using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Catalogos;
using API.Models.Metodos;
using API.Models.Entidades;

namespace API.Controllers
{
    public class ContenidoTipoElementoController : ApiController
    {
        CatalogoRespuestasHTTP _objCatalogoRespuestasHTTP = new CatalogoRespuestasHTTP();
        CatalogoContenidoTipoElemento _objCatalogoContenidoTipoElemento = new CatalogoContenidoTipoElemento();
        CatalogoAsignarDescripcionComponenteTipoElemento _objCatalogoAsignarDescripcionComponenteTipoElemento = new CatalogoAsignarDescripcionComponenteTipoElemento();
        Seguridad _seguridad = new Seguridad();

    }
}
