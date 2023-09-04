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
    public class WordRepository : IWordRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Word> _words;

        public WordRepository(AppDbContext context)
        {
            _context=context;
            _words=_context.Set<Word>();
        }

        
        public async Task AddAsync(Word word)
        {
            await _words.AddAsync(word);
        }

        public async Task AddRangeAsync(IEnumerable<Word> words)
        {
            await _words.AddRangeAsync(words);
        }

        public async Task<bool> AnyAsync(Expression<Func<Word, bool>> expression)
        {
           return await _words.AnyAsync(expression);
        }

        public IQueryable<Word> GetAll()
        {
            return _words.AsNoTracking().AsQueryable();
        }

        public async Task<Word> GetByIdAsync(int id)
        {
            return await _words.FindAsync(id);
        }

        public async Task<Word> GetByNameAsync(string name)
        {
            return await _words.FindAsync(name);
        }

        public void Remove(Word word)
        {
            _words.Remove(word);
        }

        public void RemoveRange(IEnumerable<Word> words)
        {
            _words.RemoveRange(words);
        }

        public void Update(Word word)
        {
            _words.Update(word);
        }

        public IQueryable<Word> Where(Expression<Func<Word, bool>> expression)
        {
            return _words.Where(expression);
        }
    }
}
