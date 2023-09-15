using Core.Entity;

namespace Core.Service
{
    public interface IWordService : IGenericService<Word>
    {
        Task<Word> getLastWord();
    }
}
