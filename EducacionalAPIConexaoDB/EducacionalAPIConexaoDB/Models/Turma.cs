using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducacionalAPIConexaoDB.Models;

[Table("Turma")]

public class Turma
{
    public Turma()
    { 
        Alunos = new Collection<Aluno>();
    }
    [Key]
    public int TurmaId { get; set; }
    public int AnoTurma { get; set; }
    public int SerieTurma { get; set; }
    [Required]
    [StringLength(10)]
    public string? LetraTurma { get; set; } 
    public ICollection<Aluno>? Alunos { get; set; }

}
