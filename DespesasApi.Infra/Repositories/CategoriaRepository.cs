using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Interfaces;
using DespesasApi.Infra.Context;

namespace DespesasApi.Infra.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
