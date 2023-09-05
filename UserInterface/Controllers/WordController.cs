using Core.Dto;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService=wordService;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _wordService.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> AddWord()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWord(WordDto word)
        {
            await _wordService.AddAsync(word);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var word=await _wordService.GetByIdAsync(id);
            await _wordService.RemoveAsync(word);
            return RedirectToAction(nameof(Index));
        }
    }
}
