using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducacionalAPIConexaoDB.ViewModel;
public class ClassroomViewModel
{
    public ClassroomViewModel()
    { 
        Students = new Collection<StudentViewModel>();
    }
    [Key]
    public int ClassroomId { get; set; }
    public int YearGrade { get; set; }
    public int GradeClassRoom { get; set; }
    [Required]
    [StringLength(10)]
    public string? LetterGrade { get; set; } 
    public ICollection<StudentViewModel>? Students { get; set; }
    public bool? Active { get; set; } 

}
