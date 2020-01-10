using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
namespace API.Models.Catalogos
{
    public class CatalogoTokens
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        List<Token> ListaTokens = new List<Token>();
        
        Seguridad _seguridad = new Seguridad();

        public List<Token> Consultar() {
            foreach (var item in db.Sp_TokenConsultar())
            {
                ListaTokens.Add(new Token() {
                    IdToken         = item.TOKEN_IdToken,
                    IdClave         = item.TOKEN_IdClave,
                    Identificador   = item.TOKEN_Identificador,
                    Descripcion     = item.TOKEN_Descripcion,
                    Estado          = item.TOKEN_Estado,

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

        public object GenerarTokens()
        {

            /*
             *  1	INSERTAR
                2	MODIFICAR
                3	ELIMINAR
                4	CONSULTAR
             */

            Consultar();
            Token token;

            //insertar
            token = ListaTokens.Where(x => x.Identificador == 1).FirstOrDefault();
            string _insertar = _seguridad.EncryptStringAES(token.Descripcion, token.objClave.Descripcion);
            ////modificar
            token = ListaTokens.Where(x => x.Identificador == 2).FirstOrDefault();
            string _modificar = _seguridad.EncryptStringAES(token.Descripcion, token.objClave.Descripcion);
            ////eliminar
            token = ListaTokens.Where(x => x.Identificador == 3).FirstOrDefault();
            string _eliminar = _seguridad.EncryptStringAES(token.Descripcion, token.objClave.Descripcion);
            ////consultar
            token = ListaTokens.Where(x => x.Identificador == 4).FirstOrDefault();
            string _consultar = _seguridad.EncryptStringAES(token.Descripcion, token.objClave.Descripcion);

            return new { _insertar, _modificar, _eliminar, _consultar };
            //return new { token };
        }

    }
}