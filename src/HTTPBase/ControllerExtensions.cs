using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace HTTPBase
{
    public static class ControllerExtensions
    {
        #region Public Methods

        public static IActionResult GetResponse(this ControllerBase controller, BaseResponse response)
        {
            IResponseUtil util = new ResponseUtil();
            return util.GetResponse(response);
        }

        public static IActionResult GetErrorResponse(this ControllerBase controller, string message, Exception exception)
        {
            IResponseUtil util = new ResponseUtil();
            return util.GetErrorResponse(message, exception);
        }

        public static IActionResult GetErrorResponse(this ControllerBase controller, ApplicationException exception)
        {
            IResponseUtil util = new ResponseUtil();
            return util.GetErrorResponse(exception);
        }

        #endregion Public Methods
    }
}