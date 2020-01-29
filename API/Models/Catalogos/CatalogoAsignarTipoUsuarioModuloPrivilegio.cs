using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;
using API.Conexion;

namespace API.Models.Catalogos
{
    public class CatalogoAsignarTipoUsuarioModuloPrivilegio
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();

        Seguridad _seguridad = new Seguridad();
        public List<AsignarTipoUsuarioModuloPrivilegio> ConsultarAsignarTipoUsuarioModuloPrivilegio()
        {
            List<AsignarTipoUsuarioModuloPrivilegio> _lista = new List<AsignarTipoUsuarioModuloPrivilegio>();
            foreach (var item in db.Sp_AsignarTipoUsuarioModuloPrivilegioConsultar())
            {
                _lista.Add(new AsignarTipoUsuarioModuloPrivilegio()
                {
                    IdAsignarTipoUsuarioModuloPrivilegio = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_IdAsignarTipoUsuarioModuloPrivilegio,
                    IdAsignarTipoUsuarioModuloPrivilegioEncriptado = _seguridad.Encriptar(item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_IdAsignarTipoUsuarioModuloPrivilegio.ToString()),
                    Estado = item.ASIGNARTIPOUSUARIOMODULOPRIVILEGIO_Estado,
                    TipoUsuario = new TipoUsuario()
                    {
                        IdTipoUsuario   = item.TIPOUSUARIO_IdTipoUsuario,
                        IdTipoUsuarioEncriptado=_seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                        Identificador   = item.TIPOUSUARIO_Identificador,
                        Descripcion     = item.TIPOUSUARIO_Descripcion,
                        Estado          = item.TIPOUSUARIO_Estado,
                    },
                    AsignarModuloPrivilegio = new AsignarModuloPrivilegio() {
                        IdAsignarModuloPrivilegio = item.ASIGNARMODULOPRIVILEGIO_IdAsignarModuloPrivilegio,
                        IdAsignarModuloPrivilegioEncriptado = _seguridad.Encriptar(item.ASIGNARMODULOPRIVILEGIO_IdAsignarModuloPrivilegio.ToString()),
                        Modulo = new Modulo()
                        {
                            IdModulo        = item.MODULO_IdModulo,
                            IdModuloEncriptado = _seguridad.Encriptar(item.MODULO_IdModulo.ToString()),
                            Identificador   = item.MODULO_Identificador,
                            Descripcion     = item.MODULO_Descripcion,
                            Estado          = item.MODULO_Estado
                        },
                        Estado = item.ASIGNARMODULOPRIVILEGIO_Estado,
                        Privilegio = new Privilegio()
                        {
                            IdPrivilegio = item.PRIVILEGIO_IdPrivilegio,
                            IdPrivilegioEncriptado = _seguridad.Encriptar(item.TIPOUSUARIO_IdTipoUsuario.ToString()),
                            Descripcion = item.PRIVILEGIO_Descripcion,
                            Identificador=item.PRIVILEGIO_Identificador,
                            Estado=item.PRIVILEGIO_Estado
                        }
                    } 
                });
            }
            return _lista;

        }

    }
}