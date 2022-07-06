using DespesasApi.Application.Interfaces;
using DespesasApi.Domain.Interfaces;

namespace DespesasApi.Application.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        //Injeção do repositório
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }        
    }
}
