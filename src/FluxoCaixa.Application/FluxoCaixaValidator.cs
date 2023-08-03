using HTTPBase;
using System.Security.Cryptography;

namespace FluxoCaixa.Application
{
    //Validação usando o conceito de Fail Fast
    public class FluxoCaixaValidator: IFluxoCaixaAppService
    {
        private IFluxoCaixaAppService _service;

        public FluxoCaixaValidator(IFluxoCaixaAppService service)
        {
            _service = service;
        }

        public BaseResponse Creditar(CreditarRequest creditarRequest)
        {
            if (creditarRequest.Valor <= 0)
            {
                throw new ApplicationException("O valor do credito não pode ser 0 ou negativo");
            }

            return _service.Creditar(creditarRequest);
        }

        public BaseResponse Debitar(DebitarRequest debitarRequest)
        {
            if (debitarRequest.Valor <= 0)
            {
                throw new ApplicationException("O valor do debito não pode ser 0 ou negativo");
            }

            return _service.Debitar(debitarRequest);
        }

        public BaseResponse GerarConsolidado(ConsolidadoRequest consolidadoRequest)
        {
            int ano = consolidadoRequest.Data.Year;

            if (ano > 2100)
            {
                throw new ApplicationException("ano invalido!");
            }

            if (ano < 1900)
            {
                throw new ApplicationException("ano invalido!");
            }

            return _service.GerarConsolidado(consolidadoRequest);
        }
    }
}
