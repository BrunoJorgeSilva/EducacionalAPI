namespace EducacionalAPIConexaoDB.Models
{
    public class Educational
    {
        public int EducationalId { get; set; }
        public int EducationalCod { get; set; }
        public string? NameInstituition { get; set; }  
        public int? CodInstitution { get; set; }
        public string? Comment { get; set; }
    }
}
