using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducacionalAPIConexaoDB.Persistency
{
    public class AlunosPersistence : IAlunosPersistence
    {
        private readonly AppDbContext _context;

        public AlunosPersistence(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            IEnumerable<Aluno> alunos = _context.Alunos.AsNoTracking().ToList();
            return alunos;
        }

        public IEnumerable<Aluno> GetAlunoPorNome(string nome)
        {
            var alunos = _context.Alunos.Where(x => x.Nome.Contains(nome)).ToList();

            if (alunos == null)
            {
                throw new Exception("Aluno não encontrado");
            }

            return alunos;
        }
    }
}
