using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Interfaces;
using DespesasApi.Infra.Context;

namespace DespesasApi.Infra.Repositories
{
    public class LancamentoRepository : RepositoryBase<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
