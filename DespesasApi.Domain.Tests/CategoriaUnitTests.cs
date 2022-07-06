using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace DespesasApi.Domain.Tests
{
    public class CategoriaUnitTests
    {
        [Fact]
        public void CriandoCategoria_ComValoresValidos_ResultaObjetoValido()
        {
            Action action = () => new Categoria(Guid.NewGuid(), "Alimentação");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CriandoCategoria_ComIdInvalido_ResultaObjetoInvalido()
        {
            Action action = () => new Categoria(Guid.Empty, "Alimentação");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo id é obrigatório.");
        }

        [Fact]
        public void CriandoCategoria_ComNomeEmBranco_ResultaObjetoInvalido()
        {
            Action action = () => new Categoria(Guid.NewGuid(), "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo nome é obrigatório.");
        }

        [Fact]
        public void CriandoCategoria_ComNomeMenosCaracteres_ResultaObjetoInvalido()
        {
            Action action = () => new Categoria(Guid.NewGuid(), "Al");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo nome precisa ter no mínimo (03) caracteres.");
        }
    }
}
