namespace API.Models.Entidades
{
    public class TipoDato
    {
        public int IdTipoDato { get; set; }
        public string IdTipoDatoEncriptado { get; set; }
        public int Identificador { get; set; }
        public string TipoHTML { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}