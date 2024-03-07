using MediatR;
using ProjectModel.Application.Dto.User;
using ProjectModel.Application.Queries.User;
using ProjectModel.Infrastructure.Repositories;

namespace ProjectModel.Application.Handlers.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        public readonly UserRepository _repository;

        public GetUserByIdQueryHandler(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            if (user == null)
                return null;

            return UserDto.MapFromDomain(user);
        }
    }
}