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
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }
    }
}