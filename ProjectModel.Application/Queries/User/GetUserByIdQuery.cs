using MediatR;
using ProjectModel.Application.Dto.User;

namespace ProjectModel.Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}