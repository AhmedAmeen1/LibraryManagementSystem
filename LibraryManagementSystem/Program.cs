using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext context = new LibraryDbContext();
            var authorService = new AuthorService(context);
            var bookService = new BookService(context);





            authorService.AddAuthor("Ahmed Ameen");



            bookService.AddBooks(new List<Book>
            {
                new Book { Title = "Book One", PublishedYear = 2002, AuthorId = 1 },
                new Book { Title = "Book Two", PublishedYear = 2024, AuthorId = 1 },
                new Book { Title = "Book Three", PublishedYear = 2020, AuthorId = 1 }
            });




            bookService.AddBookWithAuthor("Navigation query example", 2023, "Ahmed Mansour");

           
            bookService.UpdateFirstBookTitle("Updated title");


            bookService.MarkFirstBookUnchanged();


            bookService.DeleteBooksWhere(b => b.Id > 2);


            authorService.PrintAuthorsWithBooks();


            authorService.LazyLoadFirstAuthorBooks();


            bookService.UpdateBookTitleWithoutFetch(1, "Ay Dummy update");

            var booksByStoredProc = bookService.GetBooksByAuthorId_StoredProcedure(1);
            foreach (var book in booksByStoredProc)
            {
                Console.WriteLine($"Stored Proc Book: {book.Title}");
            }

            authorService.PrintAuthorsWithBooks_Optimized();    
        }
    }
}
