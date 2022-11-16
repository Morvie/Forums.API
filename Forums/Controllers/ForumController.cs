using Forums.Models;
using ForumsService.Application.Query.GetAllForums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forums.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : Controller
    {
        private readonly IMediator _mediator;

        public ForumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumsViewModel>>> GetAll()
        {
            var query = new GetAllForumsQuery();
            var result = await _mediator.Send(query);
            List<ForumsViewModel> forums = new();
            
            foreach (var forum in result)
            {
                forums.Add(new ForumsViewModel(forum.Id,forum.Title,forum.Description,forum.Ownership,forum.DateOfAdded,forum.Reported,forum.Amountoflikes,forum.MovieId));
            }

            return Ok(forums);
        }
    }
}
