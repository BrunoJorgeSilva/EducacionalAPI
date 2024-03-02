using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.ViewModel;

public class EducationalViewModel
{
    public int EducationalId { get; set; }
    public int EducationalCod { get; set; }
    public string? NameInstituition { get; set; }  
    public int? CodInstitution { get; set; }
    public string? Comment { get; set; }
}
