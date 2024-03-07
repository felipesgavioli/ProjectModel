using MediatR;

namespace ProjectModel.Application.Commands.User
{
    public class UserCreateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Domain.User FromDto()
        {
            return new Domain.User(Name, Email, Password);
        }
    }
}