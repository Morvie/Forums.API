using Forums.Models;
using ForumsService.Application.Command.CreateForum;
using ForumsService.Application.Command.DeleteForum;
using ForumsService.Application.Command.UpdateForum;
using ForumsService.Application.Query.GetAllForums;
using ForumsService.Application.Query.GetForum;
using ForumsService.Domain.Entities;
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
        [HttpGet("/test")]
        public string TestMethod()
        {
            return "Test Alive!";
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumsViewModel>>> GetAll()
        {
            var query = new GetAllForumsQuery();
            var result = await _mediator.Send(query);
            List<ForumsViewModel> forums = new();
            if (result == null) return BadRequest();
            foreach (var forum in result)
            {
                forums.Add(new ForumsViewModel(forum.Id,forum.Title,forum.Description,forum.Ownership,forum.DateOfAdded,forum.Reported,forum.Amountoflikes,forum.MovieId));
            }
            

            return Ok(forums);
        }

        [HttpGet("{forumId}")]
        public async Task<ActionResult> Get(Guid forumId)
        {
            var forum = await _mediator.Send(new GetForumQuery(forumId));
            if (forum != null)
            {
                var result = new ForumsViewModel(forum.Id, forum.Title, forum.Description, forum.Ownership, forum.DateOfAdded, forum.Reported, forum.Amountoflikes, forum.MovieId);
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(POSTViewModel forumViewModel)
        {
            var command = new CreateForumCommand(
                forumViewModel.Title,
                forumViewModel.Description,
                forumViewModel.OwnerId,
                forumViewModel.Dateofadded,
                forumViewModel.Reported, 
                forumViewModel.Amountoflikes,
                forumViewModel.MovieId
            );
            var result = await _mediator.Send(command);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ForumsViewModel forum)
        {
            var dto = new ForumsDTO() { Id = forum.Id, Title = forum.Title, Description = forum.Description, Amountoflikes = forum.Amountoflikes, DateOfAdded = forum.DateOfAdded, MovieId = forum.MovieId, Ownership = forum.Ownership, Reported = forum.Reported};
            var command = new UpdateForumCommand(dto);
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{forumId}")]
        public async Task<ActionResult> Delete(Guid forumId)
        {
            var command = new DeleteForumCommand(forumId);
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
