using Components;
using Entities.Request;
using Microsoft.AspNetCore.Mvc;

namespace MasterLookup.Controllers
{
    [Route("api/v1/lookup/[action]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IGetResponse _responseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenManager _tokenService;


        public LookupController(IServiceManager ServiceManager, IGetResponse getResponse, IHttpContextAccessor httpContextAccessor, ITokenManager tokenManager)
        {
            _serviceManager = ServiceManager;
            _responseService = getResponse;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenManager;
        }

        //[HttpPost]
        [HttpPost]
        public async Task<IActionResult> create([FromBody] LookupRequest req)
        {
            var context = _httpContextAccessor.HttpContext;
            var accesstoken = context.Request.Cookies["access_token"];
            //decrypt token 
            var decryptToken = _tokenService.DecryptToken(accesstoken);
            var user = _tokenService.GetPrincipalFromToken(decryptToken);
            var response = await _serviceManager.LookupService.Create(req, user);
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> update(UpdateLookup req)
        {
            var context = _httpContextAccessor.HttpContext;
            var accesstoken = context.Request.Cookies["access_token"];
            var decryptToken = _tokenService.DecryptToken(accesstoken);
            var user = _tokenService.GetPrincipalFromToken(decryptToken);
            var response = await _serviceManager.LookupService.Update(req, user);
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> view(RequestId req)
        {
            var context = _httpContextAccessor.HttpContext;
            var accesstoken = context.Request.Cookies["access_token"];
            var decryptToken = _tokenService.DecryptToken(accesstoken);
            var user = _tokenService.GetPrincipalFromToken(decryptToken);
            var response = await _serviceManager.LookupService.View(req, user);
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> delete(DeleteLookup req)
        {
            var context = _httpContextAccessor.HttpContext;
            var accesstoken = context.Request.Cookies["access_token"];
            var decryptToken = _tokenService.DecryptToken(accesstoken);
            var user = _tokenService.GetPrincipalFromToken(decryptToken);
            var response = await _serviceManager.LookupService.Delete(req, user);
            return _responseService.CreateResponse(response.Code, response.Message, response.Data);
        }



    }
}
