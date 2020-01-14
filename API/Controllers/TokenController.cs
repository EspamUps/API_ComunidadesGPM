using API.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class TokenController : Controller
    {
        CatalogoTokens CatTokens = new CatalogoTokens();
        /*
         *  1	INSERTAR
            2	MODIFICAR
            3	ELIMINAR
            4	CONSULTAR
         */
        [HttpGet]
        [Route("api/tokens")]
        public object tokens()
        {

            return CatTokens.GenerarTokens();
        }
    }
}