using MediatR;
using ProjectModel.Application.Dto.User;

namespace ProjectModel.Application.Queries.User
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}