using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Must be select a user")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required(ErrorMessage = "Must be select a book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
    }
}