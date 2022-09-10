using Codecool.StudentManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Domain.Students
{
    public class Student : Entity
    {
        public StudentName Name { get; private set; }
        public Email Email { get; private set; }
        public Student(StudentName studentName, Email email)
        {
            Name = studentName;
            Email = email;
        }
    }
}
