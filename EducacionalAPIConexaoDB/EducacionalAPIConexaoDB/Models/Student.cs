using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EducacionalAPIConexaoDB.Models;

[Table("Aluno")]

public class Student
{
    [Key]
    public int StudentId { get; set; }
    [Required] 
    [StringLength(80)]
    public string? Name { get; set; }
    public int ClassRoomId { get; set; }
    [JsonIgnore]
    public Classroom? ClassRoom { get;set; }
    public ICollection<Email>? Email { get; set; }
    
}
