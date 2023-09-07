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
    public class WordService : GenericService<Word>, IWordService
    {
        private readonly IWordRepository _wordRepository;
        public WordService(IGenericRepository<Word> repository, IUnitOfWork unitOfWork, IWordRepository wordRepository) : base(repository, unitOfWork)
        {
            _wordRepository=wordRepository;
        }

        public async Task<Word> getLastWord()
        {
            return await _wordRepository.getLastWord();
        }
    }
}
