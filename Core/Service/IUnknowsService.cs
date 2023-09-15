using Core.Entity;

namespace Core.Service
{
    public interface IUnknowsService : IGenericService<Unknows>
    {
        Task<Unknows> GetLastUnknows();
    }
}
