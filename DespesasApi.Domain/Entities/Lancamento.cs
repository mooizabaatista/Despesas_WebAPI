using DespesasApi.Domain.Validation;

namespace DespesasApi.Domain.Entities
{
    public class Lancamento : EntityBase
    {
        //Propriedades
        public string? Local { get; set; }
        public DateTime? Data { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }


        public Lancamento()
        {

        }

        //Construtores parametrizados
        public Lancamento(string local, DateTime? data, string descricao, decimal? valor)
        {
            ValidateDomain(local, data, descricao, valor);
        }

        public Lancamento(Guid id, string local, DateTime? data, string descricao, decimal? valor)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "O campo id é obrigatório.");

            Id = id;

            ValidateDomain(local, data, descricao, valor);
        }

        //Relacionamentos
        public Guid CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }


        //Validações
        private void ValidateDomain(string local, DateTime? data, string descricao, decimal? valor)
        {
            //local
            DomainExceptionValidation.When(string.IsNullOrEmpty(local), "O campo local é obrigatório.");
            DomainExceptionValidation.When(local.Length < 3, "O campo local precisa ter no mínimo (03) caracteres.");

            //Data
            DomainExceptionValidation.When(!data.HasValue , "Data inválida.");

            //Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "O campo descrição é obrigatório.");
            DomainExceptionValidation.When(descricao.Length < 5, "O campo descrição precisa ter no mínimo (05) caracteres.");

            //Valor
            DomainExceptionValidation.When(valor == null, "O campo valor é obrigatório.");
            DomainExceptionValidation.When(valor <= 0, "O campo valor não pode ser igual o menor que (0).");

            Local = local;
            Data = data;
            Descricao = descricao;
            Valor = valor;
        }
    }
}
