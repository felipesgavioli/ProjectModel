using MediatR;

namespace ProjectModel.Application.Commands.User
{
    public record class UserDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}