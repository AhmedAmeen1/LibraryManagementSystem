using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext context;
        public BookRepository(LibraryDbContext _context)
        {
            context = _context;
        }

        public void Add(Book entity)
        {
            context.Books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
                context.Books.Remove(book);
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Book entity)
        {
            var book = GetById(entity.Id);
            if (book != null)
            {
                book.Title = entity.Title;
                book.Author = entity.Author;
                book.Genre = entity.Genre;
                book.TotalQuantity = entity.TotalQuantity;
                book.AvailableQuantity = entity.AvailableQuantity;
            }

        }
    }
}
