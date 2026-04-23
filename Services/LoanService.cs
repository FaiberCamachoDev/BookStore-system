using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class LoanService : ILoanService
    {
        private readonly AppDbContext _context;

        public LoanService(AppDbContext context)
        {
            _context = context;
        }

        public List<Loan> GetAll()
        {
            return _context.Loans
                .Include(l => l.User)
                .Include(l => l.Book)
                .ToList();
        }

        public Loan? GetById(int id)
        {
            return _context.Loans
                .Include(l => l.User)
                .Include(l => l.Book)
                .FirstOrDefault(l => l.Id == id);
        }

        public void Add(Loan loan)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == loan.UserId);
            if (user == null)
                throw new BusinessException("user doesnt exist");

            var book = _context.Books.FirstOrDefault(x => x.Id == loan.BookId);
            if (book == null)
                throw new BusinessException("Book doesn't exist bruh");

            if (book.IsLoaned)
                throw new BusinessException("The book is loaned reicon");

            //  marcar como prestado
            book.IsLoaned = true;

            loan.LoanDate = DateTime.Now;

            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var loan = _context.Loans
                .Include(l => l.Book)
                .FirstOrDefault(x => x.Id == id);

            if (loan == null)
                throw new BusinessException("Loan not finded.");

            var book = _context.Books.FirstOrDefault(x => x.Id == loan.BookId);

            if (book != null)
            {
                book.IsLoaned = false; // prestado = false
            }

            _context.Loans.Remove(loan);
            _context.SaveChanges();
        }
    }
}