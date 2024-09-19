using EducaTesting.Application.Courses;
using EducaTesting.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducaTesting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> Get()
        {
            return await _mediator.Send(new GetCourseQuery.GetCourseQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCourseCommand.CreateCourseCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
