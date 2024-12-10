using DapperWebAPI.Dtos.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebAPI.Features.Student
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest req)
        {
            var response = await _studentService.CreateStudent(req);
            return StatusCode(response.StatusCodes, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentRequest req)
        {
            var response = await _studentService.UpdateStudent(req);
            return StatusCode(response.StatusCodes, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var response = await _studentService.DeleteStudent(id);
            return StatusCode(response.StatusCodes, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _studentService.GetStudentList();
            return StatusCode(response.StatusCodes, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetail(string id)
        {
            var response = await _studentService.GetStudentDetail(id);
            return StatusCode(response.StatusCodes, response);
        }
    }
}
