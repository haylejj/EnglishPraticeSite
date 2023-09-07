using Core.Entity;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
