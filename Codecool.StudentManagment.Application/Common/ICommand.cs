using Codecool.StudentManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application.Common
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
