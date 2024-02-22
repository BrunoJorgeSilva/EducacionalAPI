using EducacionalAPIConexaoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace EducacionalAPIConexaoDB.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ReqAvisoController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly string connectionString;

        public ReqAvisoController(IConfiguration config)
        {
            this.config = config;
            connectionString = this.config.GetValue<string>("AzureServiceBus");
        }
        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            await EnviaParaFilaServiceBus(aluno);
            return Ok("Ok");
        }

        private async Task EnviaParaFilaServiceBus(Aluno aluno)
        {
            string queueName = "profissional";
            var client = new QueueClient(connectionString, queueName, ReceiveMode.PeekLock);
            string messageBody = JsonConvert.SerializeObject(aluno);

            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
            await client.CloseAsync();
        }
        [HttpPost("falta")]
        public async Task<IActionResult> Post(Falta falta)
        {
            await EnviaParaFilaServiceBusFalta(falta);
            return Ok("Ok");
        }

        private async Task EnviaParaFilaServiceBusFalta(Falta falta)
        {
            string queueName = "profissional";
            var client = new QueueClient(connectionString, queueName, ReceiveMode.PeekLock);
            string messageBody = JsonConvert.SerializeObject(falta);

            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
            await client.CloseAsync();
        }
    }
}
