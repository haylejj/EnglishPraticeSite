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
        public FavoriteService(IGenericRepository<Favorite> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
