using MassTransit;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace FeedMessages.Application.Notifications
{
    public class CommandMessageConsumer:IConsumer<FeedCreateNotification>
    {

        public async Task Consume(ConsumeContext<FeedCreateNotification> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Message from Producer : {message}");
            // Do something useful with the message
        }
    }
}
