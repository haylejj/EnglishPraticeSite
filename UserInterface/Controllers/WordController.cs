using AutoMapper;
using Core.Dto;
using Core.Entity;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordService _wordService;
        private readonly IMapper _mapper;
        public WordController(IWordService wordService, IMapper mapper)
        {
            _wordService=wordService;
            _mapper=mapper;
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
        public async Task<IActionResult> AddWord(WordDto wordDto)
        {
            var word=_mapper.Map<Word>(wordDto);
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
        [HttpGet]
        public async Task<IActionResult> UpdateWord(int id)
        {
            var word=await _wordService.GetByIdAsync(id);
            return View(word);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWord(Word word)
        {
            await _wordService.UpdateAsync(word);
            return RedirectToAction(nameof(Index));
        }
    }
}
