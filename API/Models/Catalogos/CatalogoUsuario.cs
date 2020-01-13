using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
namespace API.Models.Catalogos
{

    public class CatalogoUsuario
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        List<Usuario> listaUsuariosSinRepetir = new List<Usuario>();
        List<Sp_UsuarioConsultar_Result> consulta = new List<Sp_UsuarioConsultar_Result>();
        Seguridad _seguridad = new Seguridad();
        string _llave = "GobiernoProvincialManabi";
     
        public Usuario ValidarCorreo(Usuario _item)
        {
            //Usuario _objUsuario = new Usuario();
            foreach (var item in db.Sp_UsuarioValidar(_item.Correo))
            {
                Usuario _objUsuario = new Usuario()
                {
                    IdUsuario = item.IdUsuario,
                    Persona = new Persona() { IdPersona = item.IdPersona },
                    Correo = item.Correo,
                    Clave = item.Clave,
                    Estado = item.Estado
                };
                return _objUsuario;
                

            }
            return new Usuario() { Correo = null };                      
        }

        //ingresar Usuario
        public int InsertarUsuario(Usuario _objUsuario) {
            try
            {
                _objUsuario.Clave = _seguridad.EncryptStringAES(_objUsuario.Clave, _llave);
                return int.Parse( db.Sp_UsuarioInsertar(
                    _objUsuario.Persona.IdPersona,
                    _objUsuario.Correo,
                    _objUsuario.Clave,
                    _objUsuario.Estado
                ).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //modificar usuario
        public int ModificarUsuario(Usuario _objUsuario) {
            try
            {
                _objUsuario.Clave = _seguridad.EncryptStringAES(_objUsuario.Clave, _llave);
                db.Sp_UsuarioModificar(_objUsuario.IdUsuario, _objUsuario.Persona.IdPersona, _objUsuario.Correo, _objUsuario.Clave);
                return _objUsuario.IdUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
                
        }
        //eliminar usuario
        public int EliminarUsuario(Usuario _objUsuario)
        {
            try
            {
                db.Sp_UsuarioCambiarEstado(_objUsuario.IdUsuario, _objUsuario.Estado);
                return _objUsuario.IdUsuario;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string DesenciptarClaveUsuario(string _clave) {
            string clave = _seguridad.DecryptStringAES(_clave, _llave);
            return clave;
        }


    }
}