using DespesasApi.Domain.Interfaces;
using DespesasApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DespesasApi.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        //Injeção do contexto
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
                _context = context;
        }

        public Task CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            return Task.CompletedTask;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).Property("UpdatedAt").CurrentValue = DateTime.Now;
            _context.Update(entity);
            return entity;
        }
    }
}
;