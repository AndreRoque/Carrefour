namespace FluxoCaixa.Domain.Entity
{
    public class FluxoCaixa
    {
        #region Public Constructors

        public FluxoCaixa()
        {
            if (Lista == null)
            {
                Lista = new List<Movimentacao>();
                SaldoAtual = 0;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public static IList<Movimentacao> Lista { get; private set; } //Estatico para funcionar como um banco de dados
        public static decimal SaldoAtual { get; set; } //Estatico para funcionar como um banco de dados

        #endregion Public Properties

        #region Public Methods

        public void Credito(decimal valor)
        {
            SaldoAtual += valor;
            Lista.Add(new Movimentacao(valor, SaldoAtual, DateTime.Now));
        }

        public void Debito(decimal valor)
        {
            Credito(-valor);
        }

        public decimal SaldoConsolidado(int dia, int mes, int ano)
        {
            return new Consolidado(dia, mes, ano).GerarSaldo(Lista);
        }

        #endregion Public Methods
    }
}