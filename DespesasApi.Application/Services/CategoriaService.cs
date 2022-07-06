using DespesasApi.Application.Interfaces;
using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Interfaces;

namespace DespesasApi.Application.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
        }
    }
}
