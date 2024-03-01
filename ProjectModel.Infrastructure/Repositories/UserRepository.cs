using Microsoft.EntityFrameworkCore;

using ProjectModel.Domain;
using ProjectModel.Infrastructure.Data;
using ProjectModel.Infrastructure.Interfaces;

namespace ProjectModel.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectModelDbContext _context;

        public UserRepository(ProjectModelDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
            //if (entity == null)
            //{
            //    throw new Exception($"Entidade com ID {id} não foi encontrada.");
            //}
            //return entity;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> Create(User user)
        {
            _context.Users.Add(user);
            return user.Id;
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }
    }
}