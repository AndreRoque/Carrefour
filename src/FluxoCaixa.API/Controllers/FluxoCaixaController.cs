using FluxoCaixa.API.Routes;
using FluxoCaixa.Application;
using HTTPBase;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    /// <summary>
    /// Endpoints de Fluxo de caixa
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class FluxoCaixaController : ControllerBase
    {
        #region Private Fields

        private readonly IFluxoCaixaAppService _service;

        #endregion Private Fields

        #region Public Constructors

        public FluxoCaixaController(IFluxoCaixaAppService service)
        {
            _service = service;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Creditar um valor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(RouteConst.Creditar)]
        [ProducesResponseType(200, Type = typeof(CreditarResponse))]
        [ProducesResponseType(400, Type = typeof(ErroResponse))]
        public IActionResult Creditar(CreditarRequest creditarRequest)
        {
            BaseResponse response;

            try
            {
                response = _service.Creditar(creditarRequest);
            }
            catch (ApplicationException exception)
            {
                return this.GetErrorResponse(exception);
            }
            catch (Exception exception)
            {
                return this.GetErrorResponse($"Não foi possível creditar", exception);
            }

            return this.GetResponse(response);
        }

        /// <summary>
        /// Debitar um valor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(RouteConst.Debitar)]
        [ProducesResponseType(200, Type = typeof(DebitarResponse))]
        [ProducesResponseType(400, Type = typeof(ErroResponse))]
        public IActionResult Debitar(DebitarRequest debitarRequest)
        {
            BaseResponse response;

            try
            {
                response = _service.Debitar(debitarRequest);
            }
            catch (ApplicationException exception)
            {
                return this.GetErrorResponse(exception);
            }
            catch (Exception exception)
            {
                return this.GetErrorResponse($"Não foi possível debitar", exception);
            }

            return this.GetResponse(response);
        }

        /// <summary>
        /// Creditar um valor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(RouteConst.MostrarSaldoConsolidado)]
        [ProducesResponseType(200, Type = typeof(SaldoConsolidadoResponse))]
        [ProducesResponseType(400, Type = typeof(ErroResponse))]
        public IActionResult GerarConsolidado(ConsolidadoRequest consolidadoRequest)
        {
            BaseResponse response;

            try
            {
                response = _service.GerarConsolidado(consolidadoRequest);
            }
            catch (ApplicationException exception)
            {
                return this.GetErrorResponse(exception);
            }
            catch (Exception exception)
            {
                return this.GetErrorResponse($"Não foi possível gerar o saldo consolidado", exception);
            }

            return this.GetResponse(response);
        }

        #endregion Public Methods
    }
}