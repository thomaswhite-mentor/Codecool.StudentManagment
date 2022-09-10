using Codecool.StudentManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application.Common
{
    public sealed class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Send(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            Result result = handler.Handle((dynamic)command);

            return result;
        }

        public T Send<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
        public void Send(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent ev in events)
            {
                Send(ev);
            }
        }
        private void Send(IDomainEvent domainEvent)
        {
            Type type = typeof(IDomainEventHandler<>);
            Type[] typeArgs = { domainEvent.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            handler.Handle((dynamic)domainEvent);
        }
    }
}
