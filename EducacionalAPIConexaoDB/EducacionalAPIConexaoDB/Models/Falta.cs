using System.Text.Json.Serialization;

namespace EducacionalAPIConexaoDB.Models
{
    public class Falta
    {
        public int FaltaId { get; set; }
        public DateTime? DiaFalta { get; set;}
        public int AlunoId { get; set; }
        [JsonIgnore]
        public Aluno? Aluno { get; set; }

        public int TurmaId { get; set; }
        [JsonIgnore]
        public Turma? Turma { get;set; }
        public bool Atestado { get; set; }
        public bool Ativa { get; set; }

    }
}
