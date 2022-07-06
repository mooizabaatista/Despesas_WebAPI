using DespesasApi.Application.Interfaces;
using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Interfaces;

namespace DespesasApi.Application.Services
{
    public class LancamentoService : ServiceBase<Lancamento>, ILancamentoService
    {
        public LancamentoService(ILancamentoRepository repository) : base(repository)
        {
        }
    }
}
