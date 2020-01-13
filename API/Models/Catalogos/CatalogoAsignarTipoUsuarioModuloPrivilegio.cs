using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarTipoUsuarioModuloPrivilegio
    {
        List<AsignarTipoUsuarioModuloPrivilegio> ListAsignarTipoUsuarioModuloPrivilegio = new List<AsignarTipoUsuarioModuloPrivilegio>();
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        CatalogoAsignarModuloPrivilegio catAsignarModulosPrivilegios = new CatalogoAsignarModuloPrivilegio(); 

        public List<AsignarTipoUsuarioModuloPrivilegio> ConsultarUsuarios() {
            foreach (var item in db.Sp_UsuarioConsultar())
            {
                ListAsignarTipoUsuarioModuloPrivilegio.Add(new AsignarTipoUsuarioModuloPrivilegio()
                {
                    IdAsignarTipoUsuarioModuloPrivilegio = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_IdAsignarTipoUsuarioModuloPrivilegio,
                    Estado = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_Estado,
                    TipoUsuario = new TipoUsuario() {
                        IdTipoUsuario   = item.TIPOUSUARIO_IdTipoUsuario,
                        Identificador   = item.TIPOUSUARIO_Identificador,
                        Descripcion     = item.TIPOUSUARIO_Descripcion,
                        Estado          = item.TIPOUSUARIO_Estado,
                    },
                    AsignarModuloPrivilegio = new AsignarModuloPrivilegio() {
                        IdAsignarModuloPrivilegio = item.ASIGNARMODULOPRIVILEGIO_IdAsignarModuloPrivilegio,
                        Modulo = new Modulo() {
                            IdModulo        = item.MODULO_IdModulo,
                            Identificador   = item.MODULO_Identificador,
                            Descripcion     = item.MODULO_Descripcion,
                            Estado          = item.MODULO_Estado
                        }
                    } 
                });
            }
            return ListAsignarTipoUsuarioModuloPrivilegio;

        }

    }
}