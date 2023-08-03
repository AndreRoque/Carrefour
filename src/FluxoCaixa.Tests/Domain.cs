using FluxoCaixa.Application;
using FluxoCaixa.Domain.Entity;

namespace FluxoCaixa.Tests
{
    public class Domain
    {
        [Theory]
        [InlineData(0, 0, 2000)]
        [InlineData(32, 1, 2000)]
        [InlineData(0, 1, 2000)]
        [InlineData(1, 0, 2000)]
        [InlineData(1, 13, 2000)]
        [InlineData(1, 1, 1899)]
        [InlineData(1, 1, 2101)]
        public void Consolidado_DeveGerarExceptionSeADataForInvalida(int dia, int mes, int ano)
        {
            Assert.Throws<ApplicationException>(() => new Consolidado(dia, mes, ano));
        }
    }
}