using Microsoft.AspNetCore.Mvc;
using BookStore.Services;
using BookStore.ViewModels;

namespace BookStore.Controllers;

public class HomeController : Controller
{
    // 1. Cambiar los tipos a las interfaces (con la 'I' al principio)
    private readonly IBookService _bookService;
    private readonly IUserService _userService;
    private readonly ILoanService _loanService;

    // 2. Pedir las interfaces en el constructor
    public HomeController(
        IBookService bookService,
        IUserService userService,
        ILoanService loanService)
    {
        _bookService = bookService;
        _userService = userService;
        _loanService = loanService;
    }

    public IActionResult Index()
    {
        var books = _bookService.GetAll();

        var vm = new DashboardViewModel
        {
            TotalBooks = books.Count,
            TotalUsers = _userService.GetAll().Count,
            ActiveLoans = _loanService.GetAll().Count,
            TotalValue = books.Sum(b => b.Price)
        };

        return View(vm);
    }
}