using MediatR;

using ProjectModel.Application.Commands.User;
using ProjectModel.Infrastructure.Data;
using ProjectModel.Infrastructure.Interfaces;

namespace ProjectModel.Application.Handlers.User
{
    public class UserCommandHandler :
        IRequestHandler<UserCreateCommand, int>,
        IRequestHandler<UserUpdateCommand, Unit>,
        IRequestHandler<UserDeleteCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var newUser = request.FromDto();
            var id = await _userRepository.Create(newUser);
            await _unitOfWork.CommitAsync();

            return id;
        }

        public async Task<Unit> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetById(request.Id);
            if (existingUser == null)
            {
                throw new Exception($"O usuário com o ID {request.Id} não foi encontrado.");
            }

            existingUser = request.FromDto();
            await _userRepository.Update(existingUser);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetById(request.Id);
            if (existingUser == null)
            {
                throw new Exception($"O usuário com o ID {request.Id} não foi encontrado.");
            }

            await _userRepository.Delete(request.Id);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}