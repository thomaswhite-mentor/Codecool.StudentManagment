using Codecool.StudentManagment.Application;
using Codecool.StudentManagment.Application.Common;
using Codecool.StudentManagment.Application.Dtos;
using Codecool.StudentManagment.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.StudentManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Messages _messages;

        public StudentController(Messages messages)
        {
            _messages = messages;
        }
        [HttpPost]
        public ActionResult Register([FromBody] StudentDto dto)
        {
            var command = new CreateNewStudentCommand(dto.Name, dto.Email);

            Result result = _messages.Send(command);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }  
            return Ok();
        }
    }
}
