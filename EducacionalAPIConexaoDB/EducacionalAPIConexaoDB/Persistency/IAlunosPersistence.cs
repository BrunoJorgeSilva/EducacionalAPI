using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.Persistency
{
    public interface IAlunosPersistence
    {
        public IEnumerable<Aluno> GetAlunos();
        public IEnumerable<Aluno> GetAlunoPorNome(string nome);
    }
}
