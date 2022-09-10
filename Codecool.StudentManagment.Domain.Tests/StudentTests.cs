using Codecool.StudentManagment.Domain.Common;
using Codecool.StudentManagment.Domain.Students;

namespace Codecool.StudentManagment.Domain.Tests
{
    public class StudentTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Email_EmptyEmailIsNotAllow_ResultFailure()
        {
            Result<Email> emailresult = Email.Create("");

            bool actual = emailresult.Failure;
            bool expect = true;
            Assert.That(actual, Is.EqualTo(expect));
        }
        [Test]
        public void Email_EmailIsNotEmptyAllow_ResultSuccess()
        {
            Result<Email> emailresult = Email.Create("tamas.feher@codecool.com");
            bool actual = emailresult.Success;
            Assert.That(actual, Is.True);
        }
    }
}