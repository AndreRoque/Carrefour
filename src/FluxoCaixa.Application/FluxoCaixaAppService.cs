﻿using HTTPBase;

namespace FluxoCaixa.Application
{
    public class FluxoCaixaAppService : IFluxoCaixaAppService
    {
        #region Public Methods

        public BaseResponse Creditar(CreditarRequest creditarRequest)
        {
            var fluxoCaixa = new Domain.Entity.FluxoCaixa();
            fluxoCaixa.Credito(creditarRequest.Valor);

            var response = new CreditarResponse();

            response.SetSuccess();
            return response;
        }

        public BaseResponse Debitar(DebitarRequest debitarRequest)
        {
            var fluxoCaixa = new Domain.Entity.FluxoCaixa();
            fluxoCaixa.Debito(debitarRequest.Valor);

            var response = new DebitarResponse();

            response.SetSuccess();
            return response;
        }

        public BaseResponse GerarConsolidado()
        {
            var fluxoCaixa = new Domain.Entity.FluxoCaixa();

            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;

            decimal saldo = fluxoCaixa.SaldoConsolidado(dia, mes, ano);

            var response = new SaldoConsolidadoResponse();
            response.SaldoConsolidado = saldo;

            response.SetSuccess();
            return response;
        }

        #endregion Public Methods
    }
}