using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Interfaces;
using AcademyApp.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            try
            {
                return Ok(await _studentService.CreateAsync(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
