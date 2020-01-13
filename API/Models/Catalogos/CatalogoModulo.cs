using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoModulo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        public List<Modulo> ListModulos { get; set; }

        public List<Modulo> Consultar()
        {
            foreach (var item in db.Sp_ModuloConsultar())
            {
                ListModulos.Add(new Modulo()
                {
                    IdModulo = item.IdModulo,
                    Identificador = item.Identificador,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado
                });
            }
            return ListModulos;
        }
    }
}