using Components;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public class ServiceGetResponse : IGetResponse
    {
        public IActionResult CreateResponse(int code, string message, object data)
        {
            switch (code)
            {
                case 200:
                    return new ObjectResult(new { message, data }) { StatusCode = StatusResponse.OK };
                case 201:
                    return new ObjectResult(new { message, data }) { StatusCode = StatusResponse.Created };
                case 204:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.OK };


                case 400:
                    return new BadRequestObjectResult(new { message }) { StatusCode = StatusResponse.BadRequest };
                case 401:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.Unauthorized };
                case 403:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.Forbidden };
                case 404:
                    return new NotFoundObjectResult(new { message });


                case 500:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.InternalServerError };
                case 502:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.BadGateway };
                case 503:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.ServiceUnavailable };
                case 504:
                    return new ObjectResult(new { message }) { StatusCode = StatusResponse.GatewayTimeout };
                default:
                    throw new ArgumentOutOfRangeException(nameof(code), "Invalid status code.");
            }
        }
    }
}
