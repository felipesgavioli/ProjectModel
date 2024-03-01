using MediatR;

using ProjectModel.Domain;

namespace ProjectModel.Application.Commands.User
{
    public class UserUpdateCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}