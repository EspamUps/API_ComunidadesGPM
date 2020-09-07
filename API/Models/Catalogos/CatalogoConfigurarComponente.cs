using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Catalogos
{
    public class CatalogoConfigurarComponente
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();
        public ConfigurarComponente InsertarConfigurarComponente(ConfigurarComponente _ConfigurarComponente)
        {
            try
            {
                foreach (var item in db.Sp_ConfigurarComponenteInsertar(_ConfigurarComponente.Contenido,int.Parse(_ConfigurarComponente.IdAsignarComponenteGenerico), int.Parse(_ConfigurarComponente.IdAsignacionTU),_ConfigurarComponente.Imagen))
                {
                    _ConfigurarComponente.IdConfigurarComponente = _seguridad.Encriptar(item.IdConfigurarComponente.ToString());
                    _ConfigurarComponente.IdAsignacionTU = _seguridad.Encriptar(item.IdAsignacionTU.ToString());
                    _ConfigurarComponente.IdAsignarComponenteGenerico = _seguridad.Encriptar(item.IdAsignarComponenteGenerico.ToString());
                    _ConfigurarComponente.Contenido = item.Contenido;
                }
                return _ConfigurarComponente;
            }
            catch (Exception)
            {
                _ConfigurarComponente.IdConfigurarComponente = "0";
                return _ConfigurarComponente;
            }
        }
        public ConfigurarComponente ModificarConfigurarComponente(ConfigurarComponente _ConfigurarComponente)
        {
            try
            {
                foreach (var item in db.Sp_ConfigurarComponenteModificar(int.Parse(_ConfigurarComponente.IdConfigurarComponente),_ConfigurarComponente.Contenido, int.Parse(_ConfigurarComponente.IdAsignarComponenteGenerico), int.Parse(_ConfigurarComponente.IdAsignacionTU), _ConfigurarComponente.Imagen))
                {
                    _ConfigurarComponente.IdConfigurarComponente = _seguridad.Encriptar(item.IdConfigurarComponente.ToString());
                    _ConfigurarComponente.IdAsignacionTU = _seguridad.Encriptar(item.IdAsignacionTU.ToString());
                    _ConfigurarComponente.IdAsignarComponenteGenerico = _seguridad.Encriptar(item.IdAsignarComponenteGenerico.ToString());
                    _ConfigurarComponente.Contenido = item.Contenido;
                }
                return _ConfigurarComponente;
            }
            catch (Exception)
            {
                _ConfigurarComponente.IdConfigurarComponente = "0";
                return _ConfigurarComponente;
            }
        }
        public List<ConfigurarComponente> ConsultarConfigurarComponentePorIdAsignarComponente(string IdAsignarComponenteGenerico)
        {
            List<ConfigurarComponente> ConfigurarComponente = new List<ConfigurarComponente>();
            foreach (var item in db.Sp_ConfigurarComponentePorIdAsignarComponente(int.Parse(IdAsignarComponenteGenerico)))
            {
                int imagen = 0;
                if (item.Imagen)
                {
                    imagen = 1;
                }
                else
                {
                    imagen = 0;
                }
                ConfigurarComponente.Add(new ConfigurarComponente()
                {
                    IdConfigurarComponente = _seguridad.Encriptar(item.IdConfigurarComponente.ToString()),
                    IdAsignacionTU = _seguridad.Encriptar(item.IdAsignacionTU.ToString()),
                    IdAsignarComponenteGenerico = _seguridad.Encriptar(item.IdAsignarComponenteGenerico.ToString()),
                    Contenido = item.Contenido,
                    Imagen = imagen
                });
            }
            return ConfigurarComponente;
        }
    }
}