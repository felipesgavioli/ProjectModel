using ProjectModel.Domain;
using ProjectModel.Infrastructure.Data;
using ProjectModel.Infrastructure.Interfaces;
using ProjectModel.Infrastructure.Repositories.Base;

namespace ProjectModel.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectModelDbContext context) : base(context)
        {
        }
    }
}