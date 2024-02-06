using System.ComponentModel.DataAnnotations;

namespace EducacionalAPIConexaoDB.Models
{
    public class Email
    {
        public int EmailId { get; set; }
        [EmailAddress]
        public string EmailPrincipal { get; set; }
        [EmailAddress]
        public string? EmailResponsavel { get; set; }

        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
    }
}
