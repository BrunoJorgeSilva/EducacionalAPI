using RegistroDeFaltas.Models;
using RegistroDeFaltas.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System.Text;
using RegistroDeFaltas.Servico.Interface;

namespace RegistroDeFaltas.Servico
{
    public class ServicoIntermediario : IServicoIntermediario
    {
        
        private readonly IConfiguration config;
        private readonly string connectionString;
        
        public ServicoIntermediario(IConfiguration config)
        { 
            this.config = config;
            connectionString = this.config.GetValue<string>("AzureServiceBus");
        }
        public async static void ChamaResponsaveis(Falta falta, string connectionString)
        {
            string topicName = "evento";
            var client = new TopicClient(connectionString, topicName);
            string messageBody = "Atenção identificamos que o aluno XXXX faltou na data" + falta.DiaFalta.Value.Date + ". Caso não esteja ciente da causa da falta, entre em contato com a direção da Educacional";

            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

             await client.SendAsync(message);
             await client.CloseAsync();
             EnviaTopicoServiceBus(falta, connectionString);
        }

        private async static Task EnviaTopicoServiceBus(Falta falta, string connectionString)
        {
            string topicName = "evento";
            var client = new TopicClient(connectionString, topicName);
            string messageBody = "Atenção identificamos que o aluno XXXX faltou na data" + falta.DiaFalta.Value.Date + ". Caso não esteja ciente da causa da falta, entre em contato com a direção da Educacional";

            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
            await client.CloseAsync();
        }
    }
}
