using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

namespace Petiza.Core.Services
{
    public class QueueHostedService : IHostedService
    {
        public QueueHostedService()
        {
            
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var policy = Policy.Handle<Exception>().WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(5), onRetry: (exception, timespan) =>
                Console.WriteLine("Falha ao realizar migration: " + exception.Message));

            policy.Execute(() => Executar());
            return Task.CompletedTask;
        }

        private void Executar()
        {
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
