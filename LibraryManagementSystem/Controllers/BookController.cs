using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        // Admin-only book management
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var books = _bookRepo.GetAll()
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    TotalQuantity = b.TotalQuantity,
                    AvailableQuantity = b.AvailableQuantity
                }).ToList();

            return View("Index", books);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var book = new Book
            {
                Title = vm.Title,
                Author = vm.Author,
                Genre = vm.Genre,
                TotalQuantity = vm.TotalQuantity,
                AvailableQuantity = vm.TotalQuantity
            };

            _bookRepo.Add(book);
            _bookRepo.Save();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookRepo.GetById(id);
            if (book == null) return NotFound();

            var vm = new BookEditViewModel
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                TotalQuantity = book.TotalQuantity
            };
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var book = _bookRepo.GetById(id);
            if (book == null) return NotFound();

            book.Title = vm.Title;
            book.Author = vm.Author;
            book.Genre = vm.Genre;
            book.TotalQuantity = vm.TotalQuantity;

            _bookRepo.Update(book);
            _bookRepo.Save();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _bookRepo.Delete(id);
            _bookRepo.Save();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var book = _bookRepo.GetById(id);
            if (book == null) return NotFound();

            var vm = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                TotalQuantity = book.TotalQuantity,
                AvailableQuantity = book.AvailableQuantity
            };
            return View(vm);
        }

        // User book browser (read-only, can borrow)
        [Authorize]
        public IActionResult UserBrowse()
        {
            var books = _bookRepo.GetAll()
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    TotalQuantity = b.TotalQuantity,
                    AvailableQuantity = b.AvailableQuantity
                }).ToList();

            return View("UserBrowse", books);
        }
    }
}
