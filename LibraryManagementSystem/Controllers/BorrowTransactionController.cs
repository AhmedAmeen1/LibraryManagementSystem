using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowTransactionController : Controller
    {
        private readonly IBorrowTransactionRepository _borrowRepo;
        private readonly IBookRepository _bookRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public BorrowTransactionController(
            IBorrowTransactionRepository borrowRepo,
            IBookRepository bookRepo,
            UserManager<ApplicationUser> userManager)
        {
            _borrowRepo = borrowRepo;
            _bookRepo = bookRepo;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrow(int bookId)
        {
            var book = _bookRepo.GetById(bookId);
            if (book == null || book.AvailableQuantity <= 0)
                return BadRequest("Book not available.");

            var user = await _userManager.GetUserAsync(User);

            var transaction = new BorrowTransaction
            {
                BookId = bookId,
                UserId = user.Id,
                BorrowDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14)
            };

            book.AvailableQuantity--;
            _borrowRepo.Add(transaction);
            _bookRepo.Update(book);
            _borrowRepo.Save();
            _bookRepo.Save();

            return RedirectToAction("MyBorrows");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int transactionId)
        {
            var transaction = _borrowRepo.GetById(transactionId);
            if (transaction == null || transaction.ReturnDate != null)
                return BadRequest("Invalid transaction.");

            transaction.ReturnDate = DateTime.UtcNow;
            var book = _bookRepo.GetById(transaction.BookId);
            book.AvailableQuantity++;

            _borrowRepo.Update(transaction);
            _bookRepo.Update(book);
            _borrowRepo.Save();
            _bookRepo.Save();

            return RedirectToAction("MyBorrows");
        }

        public async Task<IActionResult> MyBorrows()
        {
            var user = await _userManager.GetUserAsync(User);
            var borrows = _borrowRepo.GetBorrowsForUser(user.Id); // Use the new, safe method
            return View(borrows);
        }
    }
}
