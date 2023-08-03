namespace FluxoCaixa.Domain.Entity
{
    public class Consolidado
    {
        #region Private Fields

        private int _dia;
        private int _mes;
        private int _ano;

        #endregion Private Fields

        #region Public Constructors

        public Consolidado(int dia, int mes, int ano)
        {
            if (dia > 31)
            {
                throw new ApplicationException("dia não pode ser maior que 31!");
            }

            if (dia < 1)
            {
                throw new ApplicationException("dia não pode ser menor que 1!");
            }

            if (mes > 12)
            {
                throw new ApplicationException("mes não pode ser maior que 12!");
            }

            if (mes < 1)
            {
                throw new ApplicationException("mes não pode ser menor que 1!");
            }

            if (ano > 2100)
            {
                throw new ApplicationException("ano invalido!");
            }

            if (ano < 1900)
            {
                throw new ApplicationException("ano invalido!");
            }

            _dia = dia;
            _mes = mes;
            _ano = ano;
        }

        #endregion Public Constructors

        #region Public Methods

        public decimal GerarSaldo(IList<Movimentacao> lista)
        {
            return lista.Where(p => p.DataHora.Day == _dia && p.DataHora.Month == _mes && p.DataHora.Year == _ano)
                .OrderBy(p => p.DataHora)
                .Last().SaldoAtual;
        }

        #endregion Public Methods
    }
}