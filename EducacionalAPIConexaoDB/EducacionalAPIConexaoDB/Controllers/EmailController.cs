using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmailPersistence _emailPersistency;
        public EmailController(AppDbContext context, IEmailPersistence emailPersistency)
        {
            _context = context;
            _emailPersistency = emailPersistency;
        }

        [HttpPost]
        public ActionResult<Email> AddEmail(string nome, string emailParaCadastrar, string emailResponsavel)
        {
            
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(emailParaCadastrar))
            {
                return BadRequest();
            }
            return Ok(_emailPersistency.AddEmail(nome, emailParaCadastrar, emailResponsavel));
        }
    }
}
