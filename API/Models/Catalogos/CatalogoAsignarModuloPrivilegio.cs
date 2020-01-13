using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarModuloPrivilegio
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        List<AsignarModuloPrivilegio> Lista = new List<AsignarModuloPrivilegio>();
        CatalogoModulo catModulos = new CatalogoModulo();
        CatalogoPrivilegio catPrivilegios = new CatalogoPrivilegio();

        

    }
}