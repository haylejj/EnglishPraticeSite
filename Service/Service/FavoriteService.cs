using Core.Entity;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class FavoriteService : GenericService<Favorite>, IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IGenericRepository<Favorite> repository, IUnitOfWork unitOfWork, IFavoriteRepository favoriteRepository) : base(repository, unitOfWork)
        {
            _favoriteRepository=favoriteRepository;
        }

        public async Task<Favorite> GetLastFavorite()
        {
            return await _favoriteRepository.GetLastFavorite();
        }
    }
}
