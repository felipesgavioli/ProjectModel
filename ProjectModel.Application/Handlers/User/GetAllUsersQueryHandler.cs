using MediatR;
using ProjectModel.Application.Dto.User;
using ProjectModel.Application.Queries.User;
using ProjectModel.Infrastructure.Repositories;

namespace ProjectModel.Application.Handlers.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        public readonly UserRepository _repository;

        public GetAllUsersQueryHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll();

            if (users == null)
                return null;

            return UserDto.FromDomain(users);
        }
    }
}