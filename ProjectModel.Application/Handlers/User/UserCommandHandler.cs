using MediatR;

using ProjectModel.Application.Commands.User;
using ProjectModel.Infrastructure.Interfaces;

namespace ProjectModel.Application.Handlers.User
{
    public class UserCommandHandler :
        IRequestHandler<UserCreateCommand, int>,
        IRequestHandler<UserUpdateCommand, Unit>,
        IRequestHandler<UserDeleteCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var newUser = new Domain.User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };
            var result = await _userRepository.Create(newUser);
            return result.Id;
        }

        public async Task<Unit> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var updateUser = new Domain.User
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };
            await _userRepository.Update(updateUser);
            return Unit.Value;
        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}