//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Conexion
{
    using System;
    
    public partial class Sp_UsuarioConsultar_Result2
    {
        public int USUARIO_IdUsuario { get; set; }
        public int USUARIO_IdPersona { get; set; }
        public string USUARIO_Correo { get; set; }
        public string USUARIO_Clave { get; set; }
        public bool USUARIO_Estado { get; set; }
        public int PERSONA_IdPersona { get; set; }
        public string PERSONA_PrimerNombre { get; set; }
        public string PERSONA_SegundoNombre { get; set; }
        public string PERSONA_PrimerApellido { get; set; }
        public string PERSONA_SegundoApellido { get; set; }
        public string PERSONA_NumeroIdentificacion { get; set; }
        public int PERSONA_IdTipoIdentificacion { get; set; }
        public string PERSONA_Telefono { get; set; }
        public int PERSONA_IdSexo { get; set; }
        public int PERSONA_IdParroquia { get; set; }
        public string PERSONA_Direccion { get; set; }
        public bool PERSONA_Estado { get; set; }
        public int SEXO_IdSexo { get; set; }
        public int SEXO_Identificador { get; set; }
        public string SEXO_Descripcion { get; set; }
        public bool SEXO_Estado { get; set; }
        public int TIPOIDENTIFICACION_IdTipoIdentificacion { get; set; }
        public int TIPOIDENTIFICACION_Identificador { get; set; }
        public string TIPOIDENTIFICACION_Descripcion { get; set; }
        public bool TIPOIDENTIFICACION_Estado { get; set; }
    }
}
