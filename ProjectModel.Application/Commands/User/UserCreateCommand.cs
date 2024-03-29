﻿using MediatR;

namespace ProjectModel.Application.Commands.User
{
    public record class UserCreateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Domain.User FromDto() =>
            new Domain.User
            {
                Name = Name,
                Email = Email,
                Password = Password
            };
    }
}