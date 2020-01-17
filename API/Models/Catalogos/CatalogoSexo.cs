using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using API.Models.Entidades;
using API.Conexion;
using API.Models.Metodos;


namespace API.Models.Catalogos
{
    public class CatalogoSexo
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public List<Sexo> ConsultarSexos() {
            List<Sexo> lista = new List<Sexo>();
            foreach (var item in db.Sp_SexoConsultar())
            {
                lista.Add( new Sexo() {
                    IdSexo          = item.IdSexo,
                    IdSexoEncriptado = _seguridad.Encriptar(item.IdSexo.ToString()),
                    Identificador   = item.Identificador,
                    Descripcion     = item.Descripcion,
                    Estado          = item.Estado
                });
            }
            return lista;
        }
    }
}
