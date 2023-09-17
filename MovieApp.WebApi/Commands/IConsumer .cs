using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace MovieApp.WebApi.Commands
{
    public interface IConsumer<in TMessage> : IConsumer
   where TMessage : class
    {
        Task Consume(ConsumeContext<TMessage> context);
    }
    public interface IConsumer { }
}