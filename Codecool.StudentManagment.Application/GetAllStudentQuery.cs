using Codecool.StudentManagment.Application.Common;
using Codecool.StudentManagment.Application.Dtos;
using Codecool.StudentManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.StudentManagment.Application
{
    public sealed class GetAllStudentQuery : IQuery<List<StudentDto>>
    {
        internal sealed class GetListQueryHandler : IQueryHandler<GetAllStudentQuery, List<StudentDto>>
        {
            readonly IStundentManagmentDataStore _stundentManagment;
            public GetListQueryHandler(IStundentManagmentDataStore stundentManagment)
            {
                this._stundentManagment = stundentManagment;
            }
            public List<StudentDto> Handle(GetAllStudentQuery query)
            {
                List<StudentDto> all = _stundentManagment.Students
                    .Select(x => new StudentDto { Id = x.Id, Name = x.Name.Value, Email = x.Email.Value })
                    .ToList();
                return all;
            }
        }
    }
}
