namespace DespesasApi.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(Guid id);
        public Task CreateAsync(TEntity entity);
        public TEntity Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
