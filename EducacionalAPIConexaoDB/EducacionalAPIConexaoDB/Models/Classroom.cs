using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducacionalAPIConexaoDB.Models;

[Table("Turma")]

public class Classroom
{
    public Classroom()
    { 
        Students = new Collection<Student>();
    }
    [Key]
    public int ClassroomId { get; set; }
    public int YearGrade { get; set; }
    public int GradeClassRoom { get; set; }
    [Required]
    [StringLength(10)]
    public string? LetterGrade { get; set; } 
    public ICollection<Student>? Students { get; set; }
    public bool? Active { get; set; } 

}
