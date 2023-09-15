using Core.Entity;

namespace Core.Service
{
    public interface IFavoriteService : IGenericService<Favorite>
    {
        Task<Favorite> GetLastFavorite();
    }
}
