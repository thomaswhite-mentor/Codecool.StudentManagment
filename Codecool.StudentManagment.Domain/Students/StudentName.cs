using Codecool.StudentManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Domain.Students
{
    public class StudentName
    {
        private readonly string _value;
        public string Value
        {
            get { return _value; }
        }
        private StudentName(string value)
        {
            _value = value;
        }
        public static Result<StudentName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Fail<StudentName>("Name can't be empty");

            if (name.Length > 50)
                return Result.Fail<StudentName>("Name is too long");

            return Result.Ok(new StudentName(name));
        }
        public static implicit operator string(StudentName studentName)
        {
            return studentName._value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not StudentName studentName)
                return false;

            return _value == studentName._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
