using System.ComponentModel.DataAnnotations;

namespace EducacionalAPIConexaoDB.Models
{
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
        [EmailAddress]
        public string MainEmail { get; set; }
        [EmailAddress]
        public string? ResponsibleEmail { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
