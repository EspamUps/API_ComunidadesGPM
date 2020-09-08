using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoModulo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public List<Modulo> Consultar()
        {
          List<Modulo> ListModulos = new List<Modulo>();

            foreach (var item in db.Sp_ModuloConsultar())
            {
                ListModulos.Add(new Modulo()
                {
                    IdModulo = item.IdModulo,
                    IdModuloEncriptado= _seguridad.Encriptar(item.IdModulo.ToString()),
                    Identificador = item.Identificador,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado
                });
            }
            return ListModulos;
        }
    }
}