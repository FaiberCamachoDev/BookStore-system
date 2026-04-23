using Microsoft.AspNetCore.Mvc;
using BookStore.Services;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers;
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public LoansController(
            ILoanService loanService,
            IUserService userService,
            IBookService bookService)
        {
            _loanService = loanService;
            _userService = userService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var loans = _loanService.GetAll();
            return View(loans);
        }

        public IActionResult Create()
        {
            var vm = new LoanViewModel
            {
                Users = _userService.GetAll(),
                Books = _bookService.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(LoanViewModel vm)
        {
            var loan = new Loan
            {
                UserId = vm.UserId,
                BookId = vm.BookId
            };

            _loanService.Add(loan);
            TempData["Message"] = "Loan created successfully";
            TempData["Type"] = "success";
    
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var loan = _loanService.GetById(id);
            if (loan == null) return NotFound();

            return View(loan);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _loanService.Delete(id);
            TempData["Message"] = "Loan deleted successfully";
            TempData["Type"] = "danger";
            return RedirectToAction("Index");
        }
    }