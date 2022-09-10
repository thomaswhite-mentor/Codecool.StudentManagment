using Codecool.StudentManagment.Application.Common;
using Codecool.StudentManagment.Domain.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application.Decorators
{
    public sealed class LoggingDecorator<TCommand> : ICommandHandler<TCommand>
       where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly ILogger<ICommandHandler<TCommand>> _logger;

        public LoggingDecorator(ICommandHandler<TCommand> handler, ILogger<ICommandHandler<TCommand>> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public Result Handle(TCommand command)
        {
            string commandJson = JsonConvert.SerializeObject(command);

            // Use proper logging here
            _logger.LogInformation($"Command of type {command.GetType().Name}: {commandJson}");

            Result result = _handler.Handle(command);
            if (result.Failure)
            {
                _logger.LogWarning($"Result  is failure: {result.Error}");
            }
            return result;
        }
    }
}
