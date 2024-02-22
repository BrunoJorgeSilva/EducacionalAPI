using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.ServiceBus;
using System.Text;
using EmailHub.Services;
using System.Text.Json;
using EmailHub.ViewModel;

namespace EmailHub.HostedService
{
    public class EmailTopicConsumer : IHostedService
    {
        static SubscriptionClient subscriptionClient;
        private readonly IConfiguration _config;
        public string serviceBusConnection;

        public EmailTopicConsumer(IConfiguration config)
        {
            _config = config;
            serviceBusConnection = _config.GetValue<string>("AzureServiceBus");
            subscriptionClient = new SubscriptionClient(serviceBusConnection, "evento", "EmailService");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("############## Starting Topic - Queue ####################");
            ProcessMessageHandler();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("############## Stopping Topic - Queue ####################");
            await subscriptionClient.CloseAsync();
            await Task.CompletedTask;
        }

        private void ProcessMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine("### Processing Message - Queue ###");
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            EmailModel email = JsonSerializer.Deserialize<EmailModel>(message.Body);
            
            EnviaEmail.EnviaEmailParaResponsavel(email);

            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
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
