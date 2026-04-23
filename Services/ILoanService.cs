using BookStore.Models;

namespace BookStore.Services
{
    public interface ILoanService
    {
        List<Loan> GetAll();
        Loan? GetById(int id);
        void Add(Loan loan);
        void Delete(int id);
    }
}