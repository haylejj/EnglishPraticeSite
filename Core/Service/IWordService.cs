using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IWordService
    {
        Task<IEnumerable<Word>> GetAllAsync();
        IQueryable<Word> Where(Expression<Func<Word, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Word, bool>> expression);
        Task<Word> GetByIdAsync(int id);
        Task<Word> GetByNameAsync(string name);
        Task AddAsync(Word word);
        Task AddRangeAsync(IEnumerable<Word> words);
        Task UpdateAsync(Word word);
        Task RemoveAsync(Word word);
        Task RemoveRangeAsync(IEnumerable<Word> words);
    }
}
