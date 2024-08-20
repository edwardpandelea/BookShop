namespace BookShop.Models
{
    public class Book
    {
        public int bookId {  get; set; }
        public string title { get; set; } = string.Empty;
        public string imgUrl { get; set; } = string.Empty;
        public string? shortDescritpion { get; set; } = string.Empty;
        public string author { get; set; } = string.Empty;

        public string? description { get; set; }

        public string? publisher { get; set; }

        public bool inStock { get; set; }
        public int? publishYear { get; set; }

        public double price { get; set; }

        public Genre genre { get; set; } = default!;

    }
}
