using BookStore.Models;

namespace BookStore.ViewModels
{
    public class LoanViewModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public List<User> Users { get; set; } = new();
        public List<Book> Books { get; set; } = new();
    }
}