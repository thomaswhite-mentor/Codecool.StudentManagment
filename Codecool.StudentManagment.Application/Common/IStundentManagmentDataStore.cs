using Codecool.StudentManagment.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application.Common
{
    public interface IStundentManagmentDataStore
    {
        List<Student> Students { get; set; }
        void SaveChanges();
    }
}
