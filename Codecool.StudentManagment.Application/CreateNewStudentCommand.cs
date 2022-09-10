using Codecool.StudentManagment.Application.Common;
using Codecool.StudentManagment.Application.Decorators;
using Codecool.StudentManagment.Domain;
using Codecool.StudentManagment.Domain.Common;
using Codecool.StudentManagment.Domain.Students;

namespace Codecool.StudentManagment.Application
{
    public class CreateNewStudentCommand : ICommand
    {
        public string Name { get; }
        public string EmailAddress { get; }

        public CreateNewStudentCommand(string name, string email)
        {
            this.Name = name;
            this.EmailAddress = email;
        }
        [Log]
        internal sealed class CreateNewStudentCommandHandler : ICommandHandler<CreateNewStudentCommand>
        {
            private IStundentManagmentDataStore _stundentManagmentDataStore;
            public CreateNewStudentCommandHandler(IStundentManagmentDataStore stundentManagmentDataStore)
            {
                _stundentManagmentDataStore = stundentManagmentDataStore;
            }

            public Result Handle(CreateNewStudentCommand command)
            {
                Result<Email> emailResult = Email.Create(command.EmailAddress);
                Result<StudentName> studentName = StudentName.Create(command.Name);
                if (emailResult.Failure)
                {
                    return Result.Fail(emailResult.Error);
                }
                if (studentName.Failure)
                {
                    return Result.Fail(studentName.Error);
                }
                Student student = new Student(studentName.Value, emailResult.Value);
                _stundentManagmentDataStore.Students.Add(student);
                student.RaiseDomainEvent(new StudentCreatedEvent(1, student.Email));
                _stundentManagmentDataStore.SaveChanges();




                return Result.Ok();
            }
        }
    }
}