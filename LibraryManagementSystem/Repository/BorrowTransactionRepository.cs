using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore; // Needed for Include
using LibraryManagementSystem.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Repository
{
    public class BorrowTransactionRepository : IBorrowTransactionRepository
    {
        private readonly LibraryDbContext context;
        public BorrowTransactionRepository(LibraryDbContext _context)
        {
            context = _context;
        }

        public void Add(BorrowTransaction entity)
        {
            context.BorrowTransactions.Add(entity);
        }

        public void Delete(int id)
        {
            var transaction = GetById(id);
            if (transaction != null)
                context.BorrowTransactions.Remove(transaction);
        }

        public List<BorrowTransaction> GetAll()
        {
            // Still here if you need the classic all, with included Book
            return context.BorrowTransactions
                .Include(t => t.Book)
                .ToList();
        }

        public BorrowTransaction GetById(int id)
        {
            return context.BorrowTransactions
                .Include(t => t.Book)
                .FirstOrDefault(t => t.TransactionID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(BorrowTransaction entity)
        {
            var transaction = GetById(entity.TransactionID);
            if (transaction != null)
            {
                transaction.BorrowDate = entity.BorrowDate;
                transaction.DueDate = entity.DueDate;
                transaction.ReturnDate = entity.ReturnDate;
                transaction.BookId = entity.BookId;
                transaction.UserId = entity.UserId;
            }
        }

        // New, recommended method for user's borrows
        public List<BorrowViewModel> GetBorrowsForUser(string userId)
        {
            return context.BorrowTransactions
                .Where(t => t.UserId == userId)
                .Include(t => t.Book)
                .Select(t => new BorrowViewModel
                {
                    TransactionID = t.TransactionID,
                    BookId = t.BookId,
                    BookTitle = t.Book != null ? t.Book.Title : "Unknown",
                    BorrowDate = t.BorrowDate,
                    DueDate = t.DueDate,
                    ReturnDate = t.ReturnDate
                })
                .ToList();
        }
    }
}
