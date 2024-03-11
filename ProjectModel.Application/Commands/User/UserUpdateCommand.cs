using MediatR;

namespace ProjectModel.Application.Commands.User
{
    public record class UserUpdateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Domain.User FromDto() =>
             new Domain.User
             {
                 Id = Id,
                 Name = Name,
                 Email = Email,
                 Password = Password
             };
    }
}