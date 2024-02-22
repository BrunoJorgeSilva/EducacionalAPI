using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using EducacionalAPIConexaoDB.Models;
using EducacionalAPIConexaoDB.Persistency;
using EducacionalAPIConexaoDB.Service;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(AppDbContext context, IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public ActionResult<Email> AddEmail(string nome, string emailParaCadastrar, string emailResponsavel)
        {
            
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(emailParaCadastrar))
            {
                return BadRequest();
            }
            return Ok(_emailService.AddEmail(nome, emailParaCadastrar, emailResponsavel));
        }
    }
}
