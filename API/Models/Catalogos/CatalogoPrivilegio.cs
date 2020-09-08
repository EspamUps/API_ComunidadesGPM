using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoPrivilegio
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        public List<Privilegio> ListPrivilegios { get; set; }

        public List<Privilegio> Consultar() {
            foreach (var item in db.Sp_PrivilegioConsultar())
            {
                ListPrivilegios.Add(new Privilegio() {
                    IdPrivilegio = item.IdPrivilegio,
                    Identificador = item.Identificador,
                    Descripcion     = item.Descripcion,
                    Estado          = item.Estado
                });
            }
            return ListPrivilegios;
        }

    }
}