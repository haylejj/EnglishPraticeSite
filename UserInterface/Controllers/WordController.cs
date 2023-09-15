using AutoMapper;
using Core.Dto;
using Core.Entity;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace UserInterface.Controllers
{
    [Authorize]
    public class WordController : Controller
    {
        private readonly IWordService _wordService;
        private readonly IMapper _mapper;
        private readonly IUnknowsService _unknowsService;
        private readonly IFavoriteService _favoriteService;
        public WordController(IWordService wordService, IMapper mapper, IFavoriteService favoriteService, IUnknowsService unknowsService)
        {
            _wordService=wordService;
            _mapper=mapper;
            _favoriteService=favoriteService;
            _unknowsService=unknowsService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var words = await _wordService.GetAllAsync();
            return View(words.ToPagedList(page, 10));
        }
        [HttpGet]
        public IActionResult AddWord()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWord(WordDto wordDto)
        {
            var word = _mapper.Map<Word>(wordDto);
            await _wordService.AddAsync(word);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var word = await _wordService.GetByIdAsync(id);
            await _wordService.RemoveAsync(word);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWord(int id)
        {
            var word = await _wordService.GetByIdAsync(id);
            return View(word);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWord(Word word)
        {
            var favorite = await _favoriteService.Where(x => x.WordId==word.Id).SingleOrDefaultAsync();
            var unknow = await _unknowsService.Where(x => x.WordId==word.Id).SingleOrDefaultAsync();
            if (favorite!=null)
            {
                favorite.TurkishWord=word.TurkishWord;
                favorite.EnglishWord=word.EnglishWord;
                await _favoriteService.UpdateAsync(favorite);
            }
            if (unknow!=null)
            {
                unknow.TurkishWord=word.TurkishWord;
                unknow.EnglishWord=word.EnglishWord;
                await _unknowsService.UpdateAsync(unknow);
            }
            await _wordService.UpdateAsync(word);
            return RedirectToAction(nameof(Index));
        }

    }
}
