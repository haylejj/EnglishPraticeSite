using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    [Authorize]
    public class PracticeUnknowsController : Controller
    {
        private readonly IUnknowsService _unknowsService;
        private static Random random = new Random();
        public PracticeUnknowsController(IUnknowsService unknowsService)
        {
            _unknowsService=unknowsService;
        }


        public async Task<IActionResult> Index()
        {
            string newEnglishWord = await getNewWord();
            return View((object)newEnglishWord);
        }

        private bool IsCorrect(string turkish, string english)
        {
            var word = _unknowsService.Where(x => x.EnglishWord==english).FirstOrDefault();
            if (word != null && word.TurkishWord==turkish)
            {
                return true;
            }
            return false;
        }
        private async Task<string> getNewWord()
        {
            var lastWord = await _unknowsService.GetLastUnknows();
            int index = random.Next(1, lastWord.Id+1);
            var newWord = await _unknowsService.GetByIdAsync(index);
            if (newWord != null)
            {
                return newWord.EnglishWord;
            }
            while (newWord == null)
            {
                index = random.Next(1, lastWord.Id+1);
                newWord = await _unknowsService.GetByIdAsync(index);
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
