using DespesasApi.Infra.Context;

namespace DespesasApi.UnitOfWork
{
    public class UoW : IUoW
    {
        private readonly ApplicationDbContext _context;

        public UoW(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Task RollBack()
        {
            return Task.CompletedTask;
        }
    }
}
