using HTTPBase;

namespace FluxoCaixa.Application
{
    public interface IFluxoCaixaAppService
    {
        #region Public Methods

        BaseResponse Creditar(CreditarRequest creditarRequest);

        BaseResponse Debitar(DebitarRequest debitarRequest);

        BaseResponse GerarConsolidado(ConsolidadoRequest consolidadoRequest);

        #endregion Public Methods
    }
}