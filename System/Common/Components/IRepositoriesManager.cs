using Components.Repositories;

namespace Components
{
    public interface IRepositoriesManager
    {
        IApiRepository ICApiRepository { get; }
    }
}
