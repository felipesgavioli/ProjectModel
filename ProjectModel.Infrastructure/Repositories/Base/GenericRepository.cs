using Microsoft.EntityFrameworkCore;

using ProjectModel.Infrastructure.Data;
using ProjectModel.Infrastructure.Interfaces.Base;

namespace ProjectModel.Infrastructure.Repositories.Base
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ProjectModelDbContext _context;

        public GenericRepository(ProjectModelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"Entidade com ID {id} não foi encontrada.");
            }
            return entity;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}