using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.WebApi.Commands
{
    public class CommandMessageConsumer : IConsumer<CommandMessage>
    {
        public async Task Consume(ConsumeContext<CommandMessage> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Message from Producer : {message.MessageString}");
            // Do something useful with the message
        }
    }
}