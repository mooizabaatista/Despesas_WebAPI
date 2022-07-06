using DespesasApi.Domain.Entities;
using FluentValidation;

namespace DespesasApi.Application.Validators
{
    public class LancamentoValidator : AbstractValidator<Lancamento>
    {
        public LancamentoValidator()
        {
            RuleFor(x => x.Local)
                .NotEmpty().WithMessage("O campo local é obrigatório.")
                .Length(3, 50).WithMessage("O campo local deve conter entre 3 e 50 caracteres.");

            RuleFor(x => x.Data)
                .NotEmpty().WithMessage("Data inválida");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo descrição é obrigatório.")
                .Length(5, 50).WithMessage("O campo descrição deve conter entre 5 e 50 caracteres.");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O campo valor é obrigatório.")
                .GreaterThanOrEqualTo(1).WithMessage("O campo valor deve ser maior que 0");
        }
    }
}
