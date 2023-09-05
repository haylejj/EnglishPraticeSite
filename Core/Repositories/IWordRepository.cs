using Core.Dto;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IWordRepository
    {
        IQueryable<Word> GetAll();
        IQueryable<Word> Where(Expression<Func<Word, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Word,bool>> expression);
        Task<Word> GetByIdAsync(int id);
        Task<Word> GetByNameAsync(string name);
        Task AddAsync(Word word);
        Task AddRangeAsync(IEnumerable<Word> words);
        void Update(Word word);
        void Remove(Word word);
        void RemoveRange(IEnumerable<Word> words);
    }
}
