using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Components
{
    public class GenreMenu : ViewComponent
    {
        private readonly IGenreRepository _genreRepository;

        public GenreMenu(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _genreRepository.allGenres.OrderBy(g => g.genreName);
            return View(genres);
        }
    }
}
