using MediatR;

namespace ProjectModel.Application.Commands.User
{
    public class UserDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}