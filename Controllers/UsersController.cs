using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Controllers;
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var users = _service.GetAll();
            return View(users);
        }

        public IActionResult Create()
        {
            return View("CreateEdit", new User());
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View("CreateEdit",user);

            try
            {
                _service.Add(user);

                TempData["Message"] = "User created successfully";
                TempData["Type"] = "success";

                return RedirectToAction("Index");
            }
            catch (BusinessException ex)
            {
                TempData["Message"] = ex.Message;
                TempData["Type"] = "warning";

                return View("CreateEdit",user);
            }
        }

        public IActionResult Edit(int id)
        {
            var user = _service.GetById(id);
            if (user == null) return NotFound();
            return View("CreateEdit",user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _service.Update(user);
            TempData["Message"] = "User edited successfully";
            TempData["Type"] = "info";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _service.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            TempData["Message"] = "User deleted successfully";
            TempData["Type"] = "danger";
            return RedirectToAction("Index");
        }
    }