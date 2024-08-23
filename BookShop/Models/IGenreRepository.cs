namespace BookShop.Models
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> allGenres { get; }
        public Genre? getGenreById(int genreId);
    }
}
