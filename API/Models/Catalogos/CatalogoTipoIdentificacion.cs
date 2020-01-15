using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoTipoIdentificacion
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        List<TipoIdentificacion> lista = new List<TipoIdentificacion>();
        Seguridad _seguridad = new Seguridad();

        public List<TipoIdentificacion> ConsultarTipoIdentificacion() {
            foreach (var item in db.Sp_TipoIdentificacionConsultar())
            {
                lista.Add(new TipoIdentificacion() {
                    IdTipoIdentificacionEncriptado = _seguridad.Encriptar(item.IdTipoIdentificacion.ToString()),
                    Identificador = item.Identificador,
                    Descripcion = item.Descripcion,
                    Estado = item.Estado
                });
            }
            return lista;
        }
    }
}