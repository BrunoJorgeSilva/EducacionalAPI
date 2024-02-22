using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.Service
{
    public interface IEmailService
    {
        public Email AddEmail(string nome, string emailParaCadastrar, string emailResponsavel);
    }
}
