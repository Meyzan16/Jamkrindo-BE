using Components;
using Microsoft.AspNetCore.Http;

namespace Services;

public class ServiceManager : IServiceManager
{
 
    private readonly Lazy<IApiService> _api;
    //dbRmTools_Context context,
    public ServiceManager(IHttpContextAccessor httpContextAccessor, IRepositoriesManager repositoriesManager)
    {

        _api = new Lazy<IApiService>(() => new ApiService(repositoriesManager));

    }

    public IApiService ApiService => _api.Value;

}



