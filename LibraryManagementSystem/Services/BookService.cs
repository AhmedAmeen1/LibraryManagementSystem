using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddBooks(List<Book> books)
        {
            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        public void AddBookWithAuthor(string title, int year, string authorName)
        {
            var book = new Book
            {
                Title = title,
                PublishedYear = year,
                Author = new Author { Name = authorName }
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateFirstBookTitle(string newTitle)
        {
            var book = _context.Books.FirstOrDefault();
            if (book != null)
            {
                book.Title = newTitle;
                _context.SaveChanges();
            }
        }


        // Attach() to update without fetching the entity first
        public void UpdateBookTitleWithoutFetch(int bookId, string newTitle)
        {
            var book = new Book { Id = bookId }; // Only Id is needed
            _context.Books.Attach(book);         // Attach to context
            book.Title = newTitle;               // Modify property
            _context.Entry(book).Property(b => b.Title).IsModified = true;
            _context.SaveChanges();
        }

        public void MarkFirstBookUnchanged()
        {
            var book = _context.Books.FirstOrDefault();
            if (book != null)
            {
                _context.Entry(book).State = EntityState.Unchanged;
                _context.SaveChanges();
            }
        }

        public void DeleteBooksWhere(Func<Book, bool> condition)
        {
            var books = _context.Books.Where(condition).ToList();
            _context.Books.RemoveRange(books);
            _context.SaveChanges();
        }


        // Using a stored procedure to get books by author ID
        public List<Book> GetBooksByAuthorId_StoredProcedure(int authorId)
        {
            return _context.Books
                .FromSqlRaw("EXEC GetBookByAuthorId @p0", authorId)
                .ToList();
        }
    }
}
