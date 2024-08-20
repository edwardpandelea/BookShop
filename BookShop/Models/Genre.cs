namespace BookShop.Models
{
    public class Genre
    {
        public int genreId { get; set; }
        public string genreName { get; set; } = string.Empty;

        public string? genreDescription { get; set; }

        public List<Book>? books { get; set; }
    }
}
