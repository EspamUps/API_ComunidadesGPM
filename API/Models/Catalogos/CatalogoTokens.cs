using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoTokens
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        List<Token> ListaTokens = new List<Token>();
        public List<Token> Consultar() {
            foreach (var item in db.Sp_TokenConsultar())
            {
                ListaTokens.Add(new Token() {
                    IdToken     = item.TOKEN_IdToken,
                    IdClave     = item.TOKEN_IdClave,
                    Descripcion = item.TOKEN_Descripcion,
                    Estado      = item.TOKEN_Estado,

                    objClave = new Clave() {
                        IdClave         = item.CLAVE_IdClave,
                        Identificador   = item.CLAVE_Identificador,
                        Descripcion     = item.CLAVE_Descripcion,
                        Estado          = item.CLAVE_Estado
                    }

                });
            }
            return ListaTokens;
        }
    }
}