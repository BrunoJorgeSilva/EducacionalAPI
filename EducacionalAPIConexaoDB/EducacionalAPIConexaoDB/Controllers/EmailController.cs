using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmailController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Email> AddEmail(string nome, string emailParaCadastrar)
        {
            
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(emailParaCadastrar))
            {
                return BadRequest();
            }
            Email email = new Email()
            {
                EmailPrincipal = emailParaCadastrar,
                AlunoId = 1
            };

            _context.Email.Add(email);
            _context.SaveChanges();

            Email emailRetorno = _context.Email.Where(x => x.EmailId == email.EmailId).Include("Aluno").FirstOrDefault();

            return new CreatedAtRouteResult("ObterAluno", new { id = emailRetorno.EmailId }, email);
        }
    }
}
