using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;

namespace API.Models.Catalogos
{
    public class CatalogoTipoUsuarios
    {
        
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        List<TipoUsuario> ListaTipoUsuarios = new List<TipoUsuario>();

        CatalogoAsignarTipoUsuarioModuloPrivilegio catAsignarTipoUsuarioModuloPrivilegio = new CatalogoAsignarTipoUsuarioModuloPrivilegio();

        public int Insertar(TipoUsuario _item)
        {
            try
            {
                return int.Parse( db.Sp_TipoUsuarioInsertar(_item.Identificador, _item.Descripcion, _item.Estado).Select(x=>x.Value).ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Modificar(TipoUsuario _item)
        {
            try
            {
                db.Sp_TipoUsuarioModificar(_item.IdTipoUsuario,_item.Identificador, _item.Descripcion);
                return _item.IdTipoUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Eliminar(TipoUsuario _item)
        {
            try
            {
                db.Sp_TipoUsuarioCambiarEstado(_item.IdTipoUsuario, _item.Estado);
                return _item.IdTipoUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<TipoUsuario> Consultar() {
            foreach (var item in db.Sp_TipoUsuarioConsultar())
            {
                ListaTipoUsuarios.Add( new TipoUsuario() {
                    IdTipoUsuario   = item.IdTipoUsuario,
                    Identificador   = item.Identificador,
                    Descripcion     = item.Descripcion,
                    Estado          = item.Estado
                });
            }
            return ListaTipoUsuarios;
        }

      

    }
}