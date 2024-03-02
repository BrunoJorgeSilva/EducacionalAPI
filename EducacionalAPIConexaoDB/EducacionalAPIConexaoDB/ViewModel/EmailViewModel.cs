using System.ComponentModel.DataAnnotations;
using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.ViewModel
{
    public class EmailViewModel
    {
        [Key]
        public int EmailId { get; set; }
        [EmailAddress]
        public string MainEmail { get; set; }
        [EmailAddress]
        public string? ResponsibleEmail { get; set; }

        public int StudentId { get; set; }
        public StudentViewModel? Student { get; set; }
    }
}
