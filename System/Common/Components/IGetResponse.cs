using Microsoft.AspNetCore.Mvc;

namespace Components
{
    public interface IGetResponse
    {
        IActionResult CreateResponse(int code, string message, object data);
    }
}
