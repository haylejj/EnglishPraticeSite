using AutoMapper;
using Core.Dto;
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
        IMapper _mapper;

        public WordService(IWordRepository wordRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _wordRepository=wordRepository;
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task AddAsync(WordDto wordDto)
        {
            var word=_mapper.Map<Word>(wordDto);
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

        public async Task<IEnumerable<WordDto>> GetAllAsync()
        {
            var words = await _wordRepository.GetAll().ToListAsync();
            var wordsDto = _mapper.Map<List<WordDto>>(words);
            return wordsDto;
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

        public async Task UpdateAsync(WordDto wordDto)
        {
            var word = _mapper.Map<Word>(wordDto);
            _wordRepository.Update(word);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Word> Where(Expression<Func<Word, bool>> expression)
        {
            return _wordRepository.Where(expression);
        }
    }
}
