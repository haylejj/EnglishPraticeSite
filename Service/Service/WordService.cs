using Core.Entity;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWorks;

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
