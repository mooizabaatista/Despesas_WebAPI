namespace DespesasApi.UnitOfWork
{
    public interface IUoW
    {
        public Task Commit();
        public Task RollBack();
    }
}
