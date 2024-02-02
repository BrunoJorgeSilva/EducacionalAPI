namespace EducacionalAPIConexaoDB.Models
{
    public class Educacional
    {
        public int EducacionalId { get; set; }
        public int EducacionalCod { get; set; }
        public string? NomeInstituicao { get; set; }  
        public int? CodInstituicao { get; set; }
        public string? Comentario { get; set; }
    }
}
