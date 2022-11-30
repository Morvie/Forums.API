using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Consumer
{
    public class FeedConsumer:IConsumer<MessageModel>
    {
        readonly ILogger<FeedConsumer> _logger;

        public FeedConsumer(ILogger<FeedConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<MessageModel> context)
        {
            _logger.LogInformation("Received test:", context.Message);
            var data = context.Message;
            await context.Publish<MessageModel>(new
            {
                context.Message.TopicName,
            });
        } 
    }
}
