using FeedMessages.Application.Notifications;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Consumer
{
    public class SubmitFeedConsumerDefinition : ConsumerDefinition<CommandMessageConsumer>
    {
        public SubmitFeedConsumerDefinition()
        {
            EndpointName = "feed-service";
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        
        IConsumerConfigurator<CommandMessageConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}
