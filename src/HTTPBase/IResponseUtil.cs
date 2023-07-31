using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HTTPBase
{
    public interface IResponseUtil
    {
        #region Public Methods

        IActionResult GetResponse(BaseResponse response);

        IActionResult GetResponse(BaseResponse response, HttpStatusCode statusCode);

        IActionResult GetErrorResponse(string message, Exception exception);

        IActionResult GetErrorResponse(Exception exception);

        #endregion Public Methods
    }
}