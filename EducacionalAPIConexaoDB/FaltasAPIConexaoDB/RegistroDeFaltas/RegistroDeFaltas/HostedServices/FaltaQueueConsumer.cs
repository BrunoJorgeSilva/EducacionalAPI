using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RegistroDeFaltas.Models;
using RegistroDeFaltas.Controllers;
using RegistroDeFaltas.Servico;
using RegistroDeFaltas.Servico.Interface;

namespace RegistroDeFaltas.HostedServices
{
    public class FaltaQueueConsumer : IHostedService
    {
        static IQueueClient queueClient;
        private readonly IConfiguration _config;
        public string serviceBusConnection;
        //private readonly IServicoIntermediario _servicoIntermediario;


        public FaltaQueueConsumer(IConfiguration config)//, IServicoIntermediario servicoIntermediario)
        {
            _config = config;
            serviceBusConnection = _config.GetValue<string>("AzureServiceBus");
            queueClient = new QueueClient(serviceBusConnection, "profissional");
            //_servicoIntermediario = servicoIntermediario;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("############## Starting Consumer - Queue ####################");
            ProcessMessageHandler();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("############## Stopping Consumer - Queue ####################");
            await queueClient.CloseAsync();
            await Task.CompletedTask;
        }

        private void ProcessMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine("### Processing Message - Queue ###");
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            Falta _falta = JsonSerializer.Deserialize<Falta>(message.Body);

            ChamaServicoIntermediario(_falta, serviceBusConnection);

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        public void ChamaServicoIntermediario(Falta _falta, string connectionString)
        {
            ServicoIntermediario.ChamaResponsaveis(_falta, connectionString);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
