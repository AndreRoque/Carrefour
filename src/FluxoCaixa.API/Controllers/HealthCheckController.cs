using FluxoCaixa.API.Routes;
using HTTPBase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FluxoCaixa.API.Controllers
{
    /// <summary>
    /// Healthcheck
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        #region Private Fields

        private IConfiguration _config;

        #endregion Private Fields

        #region Public Constructors

        public HealthCheckController(IConfiguration config)
        {
            _config = config;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Endpoint para HealthCheck
        /// </summary>
        /// <returns></returns>
        [Route(RouteConst.HealthCheck)]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult HealthCheck()
        {
            long memoryUsed;

            try
            {
                string env = _config["MAX_MEMORY"];

                if (env == null)
                {
                    return new ObjectResult($"healthy")
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }

                memoryUsed = GC.GetTotalMemory(false);
                long maxMemory;

                maxMemory = Convert.ToInt64(env);

                if (memoryUsed <= maxMemory)
                {
                    return new ObjectResult($"healthy: memory = {memoryUsed}")
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
            }
            catch (ApplicationException exception)
            {
                return this.GetErrorResponse(exception);
            }
            catch (Exception exception)
            {
                return this.GetErrorResponse($"Erro ao acessar o healthcheck", exception);
            }

            return new ObjectResult($"unhealthy: memory = {memoryUsed}")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        #endregion Public Methods
    }
}