
namespace BookShop.Models
{
    public class GenreRepository : IGenreRepository
    {
        public IEnumerable<Genre> allGenres => new List<Genre>
        {
            new Genre{genreId = 1, genreName = "Fiction", genreDescription = "Fiction genre"},
            new Genre{genreId = 2, genreName = "Fantastic", genreDescription = "Fantastic genre"},
            new Genre{genreId = 3, genreName = "Crime", genreDescription = "Crime genre"}

        };
    }
}
