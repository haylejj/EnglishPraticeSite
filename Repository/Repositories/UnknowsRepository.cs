using Core.Entity;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UnknowsRepository : GenericRepository<Unknows>, IUnknowsRepository
    {
        public UnknowsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
