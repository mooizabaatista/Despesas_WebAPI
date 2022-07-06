using DespesasApi.Domain.Entities;
using FluentValidation;

namespace DespesasApi.Application.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório.");

            RuleFor(x => x.Nome)
                .Length(3, 50).WithMessage("O nome deve conter entre 3 e 50 caracteres.");
        }
    }
}
