namespace FluxoCaixa.Domain.Entity
{
    public class Movimentacao
    {
        #region Public Constructors

        public Movimentacao(decimal valor, decimal saldoAtual, DateTime dataHora)
        {
            SaldoAtual = saldoAtual;
            Valor = valor;
            DataHora = dataHora;
        }

        #endregion Public Constructors

        #region Public Properties

        public decimal SaldoAtual { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }

        #endregion Public Properties
    }
}