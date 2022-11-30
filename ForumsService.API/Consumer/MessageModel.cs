using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Consumer
{
    public class MessageModel
    {
        public Guid Id { get; init; }
        public Guid ForumId { get; init; }
        public string TopicName { get; init; } = "Default Topic";
        public string Content { get; init; } = "Default Content";
        public string Author { get; init; } = "Default Author";
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime LastEdited { get; init; }
    }
}
