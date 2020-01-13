using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using API.Models.Entidades;
using API.Conexion;


namespace API.Models.Catalogos
{
    public class CatalogoSexo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        public List<Sexo> ConsultarSexos() {
            List<Sexo> lista = new List<Sexo>();
            foreach (var item in db.Sp_SexoConsultar())
            {
                lista.Add( new Sexo() {
                    IdSexo          = item.IdSexo,
                    Identificador   = item.Identificador,
                    Descripcion     = item.Descripcion,
                    Estado          = item.Estado
                });
            }
            return lista;
        }
    }
}
