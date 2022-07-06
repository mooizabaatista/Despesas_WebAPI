using DespesasApi.Domain.Validation;

namespace DespesasApi.Domain.Entities
{
    public class Categoria : EntityBase
    {
        //Propriedades
        public string? Nome { get; set; }

        //Construtores parametrizados
        public Categoria()
        {

        }

        public Categoria(string nome)
        {
            ValidateDomain(nome);
        }

        public Categoria(Guid id, string nome)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "O campo id é obrigatório.");
            Id = id;
            ValidateDomain(nome);
        }

        //Relacionamentos
        public virtual IEnumerable<Lancamento>? Lancamentos { get; set; }


        //Validações
        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O campo nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "O campo nome precisa ter no mínimo (03) caracteres.");

            Nome = nome;
        }

    }
}
