using Codecool.StudentManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application.Common
{
    public interface IDomainEventHandler<TDomainEvent>
      where TDomainEvent : IDomainEvent
    {
        void Handle(TDomainEvent domainEvent);
    }
}
