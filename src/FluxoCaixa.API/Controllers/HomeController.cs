using FluxoCaixa.API.Routes;
using HTTPBase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FluxoCaixa.API.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region Private Fields

        private IConfiguration _config;

        #endregion Private Fields

        #region Public Constructors

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Verifica se a API esta em execução. Exibe o código da versão
        /// </summary>
        /// <returns></returns>
        [Route(RouteConst.Home)]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Index()
        {
            ObjectResult result;

            try
            {
                string serviceName = _config["SERVICE_NAME"];
                string serviceVersion = _config["SERVICE_VERSION"];
                string environment = _config["ASPNETCORE_ENVIRONMENT"];

                result = new ObjectResult($"{serviceName} em execução! - " +
                    $"Versão: {serviceVersion} - " +
                    $"Ambiente: {environment}")
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (ApplicationException exception)
            {
                return this.GetErrorResponse(exception);
            }
            catch (Exception exception)
            {
                return this.GetErrorResponse($"Não foi possível acessar a pagina base", exception);
            }

            return result;
        }

        #endregion Public Methods
    }
}