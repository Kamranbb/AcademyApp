using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_groupService.GetAll());
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(GroupCreateDto dto)
        {
            return Ok(await _groupService.CreateAsync(dto));
        }
    }
}
