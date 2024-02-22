using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.Persistency
{
    public interface IEmailPersistence
    {
        public Email AddEmail(string nome, string emailParaCadastrar, string emailResponsavel);
    }
}
