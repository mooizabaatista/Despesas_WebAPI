namespace DespesasApi.Application.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity?> GetById(Guid id);
        public Task Create(TEntity entity);
        public TEntity Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
