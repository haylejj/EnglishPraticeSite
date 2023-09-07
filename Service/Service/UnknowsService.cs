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
    public class UnknowsService : GenericService<Unknows>, IUnknowsService
    {
        private readonly IUnknowsRepository _repository;
        public UnknowsService(IGenericRepository<Unknows> repository, IUnitOfWork unitOfWork, IUnknowsRepository unknowsRepository) : base(repository, unitOfWork)
        {
            _repository=unknowsRepository;
        }

        public async Task<Unknows> GetLastUnknows()
        {
           return await _repository.GetLastUnknows();
        }
    }
}
