using MediatR;

namespace ProjectModel.Application.Commands.User
{
    public class UserDeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}