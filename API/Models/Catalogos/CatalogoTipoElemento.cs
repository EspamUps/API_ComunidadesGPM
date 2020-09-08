using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoTipoElemento
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<TipoElemento> ConsultarTipoElemento()
        {
            List<TipoElemento> _lista = new List<TipoElemento>();
            foreach (var item in db.Sp_TipoElementoConsultar())
            {
                _lista.Add(new TipoElemento()
                {
                    IdTipoElemento = item.IdTipoElemento,
                    //IdTipoElemento = 0,
                    IdTipoElementoEncriptado = _seguridad.Encriptar(item.IdTipoElemento.ToString()),
                    Descripcion = item.Descripcion,
                    Identificador = item.Identificador,
                });
            }
            return _lista;
        }

    }
}