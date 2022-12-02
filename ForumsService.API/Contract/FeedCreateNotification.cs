using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMessages.Application.Notifications
{
    public record FeedCreateNotification : INotification
    { 
        public Guid Id { get; init; }
        public Guid ForumId { get; init; }
    }
}
