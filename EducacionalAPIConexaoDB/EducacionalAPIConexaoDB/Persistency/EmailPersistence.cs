using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EducacionalAPIConexaoDB.Persistency
{
    public class EmailPersistence : IEmailPersistence
    {
        private readonly AppDbContext _context;
        private readonly IStudentPersistence _studentsPersistence;
        public EmailPersistence(AppDbContext context, IStudentPersistence studentsPersistence) 
        {
            _context = context;
            _studentsPersistence = studentsPersistence;
        }
        public Email AddEmail (string nome, string emailParaInserir, string emailResponsavel)
        {
            var Students = _studentsPersistence.GetStudentByName(nome);
            if(Students.Count() == 0)
            {
                throw new Exception("Falha ao Inserir Email, Student não encontrado, verifique a digitação.");
            }
            Email email = new Email()
            {
                MainEmail = emailParaInserir,
                StudentId = Students.FirstOrDefault().StudentId,
                ResponsibleEmail = emailResponsavel
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
