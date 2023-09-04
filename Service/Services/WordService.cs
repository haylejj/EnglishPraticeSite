using Core.Entity;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WordService : IWordService
    {
        IWordRepository _wordRepository;
        IUnitOfWork _unitOfWork;

        public WordService(IWordRepository wordRepository, IUnitOfWork unitOfWork)
        {
            _wordRepository=wordRepository;
            _unitOfWork=unitOfWork;
        }

        public async Task AddAsync(Word word)
        {
            await _wordRepository.AddAsync(word);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Word> words)
        {
            await _wordRepository.AddRangeAsync(words);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Word, bool>> expression)
        {
            return await _wordRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _wordRepository.GetAll().ToListAsync();
        }

        public async Task<Word> GetByIdAsync(int id)
        {
            return await _wordRepository.GetByIdAsync(id);
        }

        public Task<Word> GetByNameAsync(string name)
        {
            return _wordRepository.GetByNameAsync(name);
        }

        public async Task RemoveAsync(Word word)
        {
             _wordRepository.Remove(word);
            await  _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Word> words)
        {
            _wordRepository.RemoveRange(words);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Word word)
        {
            _wordRepository.Update(word);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Word> Where(Expression<Func<Word, bool>> expression)
        {
            return _wordRepository.Where(expression);
        }
    }
}
