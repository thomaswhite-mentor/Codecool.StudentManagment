using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.StudentManagment.Application.Common;
using Codecool.StudentManagment.Domain.Students;

namespace Codecool.StudentManagment.Domain
{
    public class StundentManagmentDataStore : IStundentManagmentDataStore
    {
        private readonly Messages _messages;
        public StundentManagmentDataStore(Messages messages)
        {
            _messages = messages;
        }
        public List<Student> Students { get; set; } = new List<Student>();
        public void SaveChanges()
        {
            foreach (var student in Students)
            {
                _messages.Send(student.DomainEvents);
                student.ClearDomainEvents();
            }
        }
    }
}
