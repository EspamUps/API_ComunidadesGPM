using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Conexion;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoVersionamientoPregunta
    {
        ComunidadesGPMEntities db = new ComunidadesGPMEntities();
        Seguridad _seguridad = new Seguridad();

        public int InsertarVersionamientoPregunta(VersionamientoPregunta _objVersionamientoPregunta )
        {
            try
            {
                return int.Parse(db.Sp_VersionamientoPreguntaInsertar(_objVersionamientoPregunta.CabeceraVersionCuestionario.IdCabeceraVersionCuestionario,_objVersionamientoPregunta.Pregunta.IdPregunta,_objVersionamientoPregunta.Estado).Select(x=>x.Value.ToString()).FirstOrDefault());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void EliminarVersionamientoPregunta(int _idVersionamientoPregunta)
        {
            db.Sp_VersionamientoPreguntaEliminar(_idVersionamientoPregunta);
        }

        public List<VersionamientoPregunta> ConsultarVersionamientoPregunta()
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_VersionamientoPreguntaConsultar())
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.Estado,
                    CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                    {
                        IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                        IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString())
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString())
                    }
                });
            }
            return _lista;
        }

        public List<VersionamientoPregunta> ConsultarVersionamientoPreguntaPorIdCabeceraVersionCuestionario(int _idCabeceraVersionCuestionario)
        {
            List<VersionamientoPregunta> _lista = new List<VersionamientoPregunta>();
            foreach (var item in db.Sp_VersionamientoPreguntaConsultar().Where(c=>c.IdCabeceraVersionCuestionario==_idCabeceraVersionCuestionario).ToList())
            {
                _lista.Add(new VersionamientoPregunta()
                {
                    IdVersionamientoPregunta = item.IdVersionamientoPregunta,
                    IdVersionamientoPreguntaEncriptado = _seguridad.Encriptar(item.IdVersionamientoPregunta.ToString()),
                    Estado = item.Estado,
                    CabeceraVersionCuestionario = new CabeceraVersionCuestionario()
                    {
                        IdCabeceraVersionCuestionario = item.IdCabeceraVersionCuestionario,
                        IdCabeceraVersionCuestionarioEncriptado = _seguridad.Encriptar(item.IdCabeceraVersionCuestionario.ToString())
                    },
                    Pregunta = new Pregunta()
                    {
                        IdPregunta = item.IdPregunta,
                        IdPreguntaEncriptado = _seguridad.Encriptar(item.IdPregunta.ToString())
                    }
                });
            }
            return _lista;
        }
    }
}