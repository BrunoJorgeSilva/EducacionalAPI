using System.Text.Json.Serialization;

namespace RegistroDeFaltas.Models
{
    public class Falta
    {
        public int FaltaId { get; set; }
        public DateTime? DiaFalta { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public bool Atestado { get; set; }
        public bool Ativa { get; set; }
    }
}
