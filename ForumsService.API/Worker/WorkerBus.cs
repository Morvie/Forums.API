using ForumsService.Application.Consumer;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace ForumsService.Application.Worker
{
    public class WorkerBus : BackgroundService
    {
        readonly IBus _bus;

        public WorkerBus(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new Subscriber { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }

        public record Subscriber
        {
            public string Value { get; init; }
        }
    }
}
