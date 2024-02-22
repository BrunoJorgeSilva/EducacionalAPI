using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;

namespace EducacionalAPIConexaoDB.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailPersistence _emailPersistence;
        public EmailService(IEmailPersistence emailPersistence)
        {
            _emailPersistence = emailPersistence;
        }

        public Email AddEmail(string nome, string emailParaInserir, string emailResponsavel)
        {
            return _emailPersistence.AddEmail(nome, emailParaInserir, emailResponsavel);
        }
    } 
}
