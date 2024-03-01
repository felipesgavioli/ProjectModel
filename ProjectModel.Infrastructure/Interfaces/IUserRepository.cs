using ProjectModel.Domain;

namespace ProjectModel.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);

        Task<List<User>> GetAll();

        Task<int> Create(User user);

        Task Update(User user);

        Task Delete(int id);
    }
}