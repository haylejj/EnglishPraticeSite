using Core.Dto;
using Core.Entity;
using Core.Repositories;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class WordRepository : GenericRepository<Word>, IWordRepository
    {
        public WordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Word> getLastWord()
        {
            return await _context.Words.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
