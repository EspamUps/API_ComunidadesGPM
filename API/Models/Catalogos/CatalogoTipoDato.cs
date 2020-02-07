using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoTipoDato
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<TipoDato> ConsultarTipoDato()
        {
            List<TipoDato> _lista = new List<TipoDato>();
            foreach (var item in db.Sp_TipoDatoConsultar())
            {
                _lista.Add(new TipoDato()
                {
                    IdTipoDato = item.IdTipoDato,
                    IdTipoDatoEncriptado = _seguridad.Encriptar(item.IdTipoDato.ToString()),
                    Identificador = item.Identificador,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado,
                    TipoHTML = item.TipoHTML
                });
            }
            return _lista;
        }
    }
}