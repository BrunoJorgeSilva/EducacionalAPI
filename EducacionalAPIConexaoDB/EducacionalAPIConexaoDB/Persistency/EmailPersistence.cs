using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EducacionalAPIConexaoDB.Persistency
{
    public class EmailPersistence : IEmailPersistence
    {
        private readonly AppDbContext _context;
        private readonly IAlunosPersistence _alunosPersistence;
        public EmailPersistence(AppDbContext context, IAlunosPersistence alunosPersistence) 
        {
            _context = context;
            _alunosPersistence = alunosPersistence;
        }
        public Email AddEmail (string nome, string emailParaInserir, string emailResponsavel)
        {
            var alunos = _alunosPersistence.GetAlunoPorNome(nome);
            if(alunos.Count() == 0)
            {
                throw new Exception("Falha ao Inserir Email, aluno não encontrado, verifique a digitação.");
            }
            Email email = new Email()
            {
                EmailPrincipal = emailParaInserir,
                AlunoId = alunos.FirstOrDefault().AlunoId,
                EmailResponsavel = emailResponsavel
            };
            try
            {
                _context.Email.Add(email);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Falha ao Inserir Email");
            }
            
            return email;
        }
    }
}
