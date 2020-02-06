using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoTipoPregunta
    {

        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<TipoPregunta> ConsultarTipoPregunta()
        {
            List<TipoPregunta> _lista = new List<TipoPregunta>();
            foreach (var item in db.Sp_TipoPreguntaConsultar())
            {
                _lista.Add(new TipoPregunta()
                {
                    IdTipoPregunta=item.IdTipoPregunta,
                    IdTipoPreguntaEncriptado=_seguridad.Encriptar(item.IdTipoPregunta.ToString()),
                    Descripcion=item.Descripcion,
                    Estado=item.Estado,
                    Identificador=item.Identificador
                });
            }
            return _lista;
        }
    }
}