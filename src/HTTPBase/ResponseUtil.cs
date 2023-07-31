using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HTTPBase
{
    public class ResponseUtil : IResponseUtil
    {
        #region Public Methods

        public IActionResult GetErrorResponse(string message, Exception exception)
        {
            return GetResponse(new ErroResponse(new MessageData(message)), HttpStatusCode.BadRequest);
        }

        public IActionResult GetErrorResponse(Exception exception)
        {
            return GetErrorResponse(exception.Message, exception);
        }

        public IActionResult GetResponse(BaseResponse response, HttpStatusCode statusCode)
        {
            var result = new ObjectResult(response)
            {
                StatusCode = (int)statusCode
            };

            return result;
        }

        public IActionResult GetResponse(BaseResponse response)
        {
            if (response.Valid)
            {
                return GetResponse(response, HttpStatusCode.OK);
            }

            return GetResponse(response, HttpStatusCode.BadRequest);
        }

        #endregion Public Methods
    }
}