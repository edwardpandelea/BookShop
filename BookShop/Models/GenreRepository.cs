
namespace BookShop.Models
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookShopDbContext _context;

        public GenreRepository(BookShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> allGenres => _context.Genres.OrderBy(p => p.genreName);

        public Genre? getGenreById(int genreId)
        {
            return _context.Genres.FirstOrDefault(b => b.genreId == genreId);
        }
    }
}
