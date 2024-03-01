using MediatR;

using Microsoft.AspNetCore.Mvc;

using ProjectModel.Application.Commands;
using ProjectModel.Application.Commands.User;

namespace ProjectModel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand command)
        {
            try
            {
                var user = await _mediator.Send(command);
                return CreatedAtAction(nameof(Create), user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar usuário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("O ID do usuário na URL não corresponde ao ID do usuário no corpo da solicitação.");
            }

            try
            {
                await _mediator.Send(command);
                return NoContent(); // Retorna 204 No Content se a atualização for bem-sucedida
            }
            catch (Exception ex)
            {
                // Trate o erro de acordo com as suas necessidades
                return StatusCode(500, $"Erro ao atualizar usuário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new UserDeleteCommand { Id = id };
                await _mediator.Send(command);
                return NoContent(); // Retorna 204 No Content se a exclusão for bem-sucedida
            }
            catch (Exception ex)
            {
                // Trate o erro de acordo com as suas necessidades
                return StatusCode(500, $"Erro ao excluir usuário: {ex.Message}");
            }
        }
    }
}