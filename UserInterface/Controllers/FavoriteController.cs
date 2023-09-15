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
    public class FavoriteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteService _favoriteService;
        private readonly IWordService _wordService;
        private readonly IUnknowsService _unknowsService;
        public FavoriteController(IMapper mapper, IFavoriteService favoriteService, IWordService wordService, IUnknowsService unknowsService)
        {
            _mapper=mapper;
            _favoriteService=favoriteService;
            _wordService=wordService;
            _unknowsService=unknowsService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var favorities = await _favoriteService.GetAllAsync();
            return View(favorities.ToPagedList(page, 5));
        }
        public async Task<IActionResult> AddFavorite(int id)
        {
            var word = await _wordService.GetByIdAsync(id);
            if (word != null)
            {
                var favorite = new Favorite
                {
                    WordId=word.Id,
                    EnglishWord=word.EnglishWord,
                    TurkishWord=word.TurkishWord,
                };
                await _favoriteService.AddAsync(favorite);
            }

            return RedirectToAction("Index", "Word");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFavorite(int id)
        {
            var favorite = await _favoriteService.GetByIdAsync(id);
            return View(favorite);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFavorite(Favorite favorite)
        {
            var word = await _wordService.GetByIdAsync(favorite.WordId);
            var unknow = await _unknowsService.Where(x => x.WordId==word.Id).SingleOrDefaultAsync();
            if (unknow!=null)
            {
                unknow.TurkishWord= favorite.TurkishWord;
                unknow.EnglishWord = favorite.EnglishWord;
                await _unknowsService.UpdateAsync(unknow);
            }
            word.TurkishWord = favorite.TurkishWord;
            word.EnglishWord = favorite.EnglishWord;


            await _favoriteService.UpdateAsync(favorite);
            await _wordService.UpdateAsync(word);


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _favoriteService.GetByIdAsync(id);
            await _favoriteService.RemoveAsync(favorite);
            return RedirectToAction("Index");
        }
    }
}
