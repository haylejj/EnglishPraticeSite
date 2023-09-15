using AutoMapper;
using Core.Entity;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace UserInterface.Controllers
{
    [Authorize]
    public class UnknowsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnknowsService _unknowsService;
        private readonly IWordService _wordService;
        private readonly IFavoriteService _favoriteService;

        public UnknowsController(IMapper mapper, IUnknowsService unknowsService, IWordService wordService, IFavoriteService favoriteService)
        {
            _mapper=mapper;
            _unknowsService=unknowsService;
            _wordService=wordService;
            _favoriteService=favoriteService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var unknows = await _unknowsService.GetAllAsync();
            return View(unknows.ToPagedList(page, 5));
        }
        public async Task<IActionResult> AddUnknows(int id)
        {
            var product = await _wordService.GetByIdAsync(id);
            if (product!=null)
            {
                var unknow = new Unknows
                {
                    WordId=product.Id,
                    EnglishWord=product.EnglishWord,
                    TurkishWord=product.TurkishWord
                };
                await _unknowsService.AddAsync(unknow);
            }
            return RedirectToAction("Index", "Word");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUnknows(int id)
        {
            var product = await _unknowsService.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUnknows(Unknows unknows)
        {
            var word = await _wordService.GetByIdAsync(unknows.WordId);
            var favorite = await _favoriteService.Where(x => x.WordId==word.Id).SingleOrDefaultAsync();
            if (favorite!=null)
            {
                favorite.TurkishWord= favorite.TurkishWord;
                favorite.EnglishWord = favorite.EnglishWord;
                await _favoriteService.UpdateAsync(favorite);
            }
            word.TurkishWord = unknows.TurkishWord;
            word.EnglishWord= unknows.EnglishWord;


            await _unknowsService.UpdateAsync(unknows);
            await _wordService.UpdateAsync(word);

            return RedirectToAction("Index", "Word");
        }
        public async Task<IActionResult> DeleteUnknows(int id)
        {
            var unknow = await _unknowsService.GetByIdAsync(id);
            await _unknowsService.RemoveAsync(unknow);
            return RedirectToAction("Index");
        }
    }
}
