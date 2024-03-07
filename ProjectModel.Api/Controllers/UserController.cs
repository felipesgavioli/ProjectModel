using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProjectModel.Application.Commands.User;
using ProjectModel.Application.Queries.User;
using ProjectModel.Infrastructure.Resources;
using System.Globalization;
using System.Resources;

namespace ProjectModel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IResources _resources;

        public UserController(IMediator mediator, IResources resources)
        {
            _mediator = mediator;
            _resources = resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound(_resources.UserIDNotFound());
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand command)
        {
            var test = _resources.UserIDNotFound(1);

            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("O ID do usuário na URL não corresponde ao ID do usuário no corpo da solicitação.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new UserDeleteCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}