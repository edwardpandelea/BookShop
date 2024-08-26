namespace BookShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }  

        public int OrderId { get; set; } 

        public int bookId { get; set; }

        public int Amount { get; set; } 

        public decimal Price { get; set; }

        public Book book { get; set; } = default!;

        public Order order { get; set; } = default!;
    }
}
