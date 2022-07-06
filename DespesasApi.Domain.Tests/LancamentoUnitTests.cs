using DespesasApi.Domain.Entities;
using DespesasApi.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace DespesasApi.Domain.Tests
{
    public class LancamentoUnitTests
    {
        [Fact]
        public void CriandoLancamento_ComValoresValidos_ResultaObjetoValido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", DateTime.Now, "Passeio com a familia", 172.50m);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }


        [Fact]
        public void CriandoLancamento_ComIdInvalido_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.Empty, "Mc Donalds", DateTime.Parse("05/07-2022"), "Passeio com a familia", 172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo id é obrigatório.");
        }

        [Fact]
        public void CriandoLancamento_ComLocalEmBranco_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "", DateTime.Parse("05/07-2022"), "Passeio com a familia", 172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo local é obrigatório.");
        }

        [Fact]
        public void CriandoLancamento_ComLocalMenosCaracteres_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc", DateTime.Parse("05/07-2022"), "Passeio com a familia", 172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo local precisa ter no mínimo (03) caracteres.");
        }

        [Fact]
        public void CriandoLancamento_ComDataInvalida_ResultaObjetoInvalido()
        {

            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", null, "Passeio com a familia", 172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Data inválida.");
        }


        [Fact]
        public void CriandoLancamento_ComDescricaoEmBranco_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", DateTime.Parse("05/07-2022"), "", 172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo descrição é obrigatório.");
        }


        [Fact]
        public void CriandoLancamento_ComDescricaoMenosCaracteres_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", DateTime.Now, "Pass", 172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo descrição precisa ter no mínimo (05) caracteres.");
        }

        [Fact]
        public void CriandoLancamento_ComValorNullo_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", DateTime.Now, "Passeio com a familia", null);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo valor é obrigatório.");
        }

        [Fact]
        public void CriandoLancamento_ComValorNegativo_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", DateTime.Now, "Passeio com a familia", -172.50m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo valor não pode ser igual o menor que (0).");
        }

        [Fact]
        public void CriandoLancamento_ComValorZero_ResultaObjetoInvalido()
        {
            Action action = () => new Lancamento(Guid.NewGuid(), "Mc Donalds", DateTime.Now, "Passeio com a familia", 0m);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O campo valor não pode ser igual o menor que (0).");
        }
    }
}
