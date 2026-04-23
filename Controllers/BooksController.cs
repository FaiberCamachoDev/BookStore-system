using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }
    public IActionResult Index()
    {
        var books = _service.GetAll();
        return View(books);
    }

    public IActionResult Create()
    {
        return View("CreateEdit", new Book());
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (!ModelState.IsValid)
            return View(book);
        _service.Add(book);
        TempData["Message"] = "Book created successfully";
        TempData["Type"] = "Success";
        return RedirectToAction("Index");
    }
    // Edit - este metodo carga todos los datos
    public IActionResult Edit(int id)
    {
        var book = _service.GetById(id);

        if (book == null)
            return NotFound();

        return View("CreateEdit", book);
    }
    // Edit - este metodo es el que genera el post
    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (!ModelState.IsValid)
            return View(book);

        _service.Update(book);
        TempData["Message"] = "Book edited successfully";
        TempData["Type"] = "info";
        return RedirectToAction("Index");
    }
    // delete - esto nos entrega la vista de confirmacion de eliminacion
    public IActionResult Delete(int id)
    {
        var book = _service.GetById(id);

        if (book == null)
            return NotFound();

        return View(book);
    }
    // delete- este metodo genera la eliminacion y refleja en db
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _service.Delete(id);
        TempData["Message"] = "Book deleted successfully";
        TempData["Type"] = "danger";
        return RedirectToAction("Index");
    }
}