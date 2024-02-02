using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EducacionalAPIConexaoDB.Models;

[Table("Aluno")]

public class Aluno
{
    [Key]
    public int AlunoId { get; set; }
    [Required] 
    [StringLength(80)]
    public string? Nome { get; set; }
    public int TurmaId { get; set; }
    [JsonIgnore]
    public Turma? Turma { get;set; }
    
}
