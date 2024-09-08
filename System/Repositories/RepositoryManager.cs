using Entities.Models.DbAplikasi;
using Entities.Models.DbPenampung;
using Components;
using Components.Repositories;
using Repositories.Master;

namespace Repositories
{
    public class RepositoryManager : IRepositoriesManager
    {

        private readonly Lazy<IApiRepository> _lazyIApiRepository;
        public RepositoryManager(dbaplikasi_context _context, dbpenampung_context _contextPenampung) 
        {
            _lazyIApiRepository = new Lazy<IApiRepository>(() => new ICApiRepository(_context, _contextPenampung));
        }

        public IApiRepository ICApiRepository => _lazyIApiRepository.Value;
    }
}
