using Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[action]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IGetResponse _responseService;

        public ApiController(IServiceManager ServiceManager, IGetResponse responseService)
        {
            _serviceManager = ServiceManager;
            _responseService = responseService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewData()
        {
            var response = await _serviceManager.ApiService.View();
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> SendData()
        {
            var response = await _serviceManager.ApiService.SendData();
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Rekap()
        {
            var response = await _serviceManager.ApiService.Rekap();
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }

    }
}
