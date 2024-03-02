using System.ComponentModel.DataAnnotations;
using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.ViewModel;

public class StudentViewModel
{
    [Required] 
    [StringLength(80)]
    public string? Name { get; set; }
    public int ClassRoomId { get; set; }
    //public ICollection<EmailViewModel>? Email { get; set; }
    public bool? Active { get; set; }
}
