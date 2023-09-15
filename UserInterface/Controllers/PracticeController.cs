using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
        private readonly IWordService _wordService;
        private static Random random = new Random();
        public PracticeController(IWordService wordService)
        {
            _wordService=wordService;
        }

        public async Task<IActionResult> Index()
        {
            string newEnglishWord = await getNewWord();
            return View((object)newEnglishWord);
        }
        private bool IsCorrect(string turkish, string english)
        {
            var word = _wordService.Where(x => x.EnglishWord==english).FirstOrDefault();
            if (word != null && word.TurkishWord==turkish)
            {
                return true;
            }
            return false;
        }
        private async Task<string> getNewWord()
        {
            var lastWord = await _wordService.getLastWord();
            int index = random.Next(1, lastWord.Id+1);
            var newWord = await _wordService.GetByIdAsync(index);
            if (newWord != null)
            {
                return newWord.EnglishWord;
            }
            while (newWord == null)
            {
                index = random.Next(1, lastWord.Id+1);
                newWord = await _wordService.GetByIdAsync(index);
            }
            return newWord.EnglishWord;
        }
        public IActionResult CheckTranslation(string turkishWord, string englishWord)
        {
            bool isCorrect = IsCorrect(turkishWord, englishWord);
            return Json(new { isCorrect });
        }
        public async Task<IActionResult> GetNewEnglishWord()
        {
            string newEnglishWord = await getNewWord();
            return Content(newEnglishWord);
        }
    }
}
