using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application.Common
{
    public interface IQuery<TResult>
    {
    }

    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
