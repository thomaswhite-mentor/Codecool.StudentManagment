using Codecool.StudentManagment.Application.Common;
using Codecool.StudentManagment.Domain.Common;
using Codecool.StudentManagment.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application
{
    public sealed class StudentCreatedEvent : IDomainEvent
    {
        public long StudentId { get; }
        public Email NewEmail { get; }
        public StudentCreatedEvent(long studentId, Email newEmail)
        {
            StudentId = studentId;
            NewEmail = newEmail;
        }
        internal sealed class StudentCreatedEventHandler : IDomainEventHandler<StudentCreatedEvent>
        {
            public void Handle(StudentCreatedEvent domainEvent)
            {
                Console.WriteLine("Called StudentCreatedEvent");
            }
        }
    }
}
