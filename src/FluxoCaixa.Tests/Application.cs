using FluxoCaixa.Application;

namespace FluxoCaixa.Tests
{
    public class Application
    {
        [Fact]
        public void Creditar_DeveGerarExceptionSeOValorDoCreditoForNulo()
        {
            CreditarRequest creditarRequest = new CreditarRequest();
            creditarRequest.Valor = 0;

            FluxoCaixaValidator validator = new FluxoCaixaValidator(new FluxoCaixaAppService());

            Assert.Throws<ApplicationException>(() => validator.Creditar(creditarRequest));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.000001)]
        [InlineData(-10)]
        [InlineData(-3)]
        [InlineData(-2.5)]
        [InlineData(-100.609)]
        public void Creditar_DeveGerarExceptionSeOValorDoCreditoForNegativo(decimal valor)
        {
            CreditarRequest creditarRequest = new CreditarRequest();
            creditarRequest.Valor = valor;

            FluxoCaixaValidator validator = new FluxoCaixaValidator(new FluxoCaixaAppService());

            Assert.Throws<ApplicationException>(() => validator.Creditar(creditarRequest));
        }

        [Fact]
        public void Debitar_DeveGerarExceptionSeOValorDoDebitoForNulo()
        {
            DebitarRequest debitarRequest = new DebitarRequest();
            debitarRequest.Valor = 0;

            FluxoCaixaValidator validator = new FluxoCaixaValidator(new FluxoCaixaAppService());

            Assert.Throws<ApplicationException>(() => validator.Debitar(debitarRequest));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.000001)]
        [InlineData(-10)]
        [InlineData(-3)]
        [InlineData(-2.5)]
        [InlineData(-100.609)]
        public void Debitar_DeveGerarExceptionSeOValorDoDebitoForNegativo(decimal valor)
        {
            DebitarRequest debitarRequest = new DebitarRequest();
            debitarRequest.Valor = valor;

            FluxoCaixaValidator validator = new FluxoCaixaValidator(new FluxoCaixaAppService());

            Assert.Throws<ApplicationException>(() => validator.Debitar(debitarRequest));
        }

        [Theory]
        [InlineData("10/10/1899")]
        [InlineData("10/10/2101")]
        public void Consolidado_DeveGerarExceptionSeOAnoForInvalido(string data)
        {
            ConsolidadoRequest consolidadoRequest = new ConsolidadoRequest();
            consolidadoRequest.Data = Convert.ToDateTime(data);

            FluxoCaixaValidator validator = new FluxoCaixaValidator(new FluxoCaixaAppService());

            Assert.Throws<ApplicationException>(() => validator.GerarConsolidado(consolidadoRequest));
        }
    }
}