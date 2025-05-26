using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class AuthorService
    {
        private readonly LibraryDbContext _context;

        public AuthorService(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(string name)
        {
            var author = new Author { Name = name };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void PrintAuthorsWithBooks()
        {
            var authors = _context.Authors.Select(a => a).ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($" - Book: {book.Title}");
                }
            }
        }


        // As no tracking version

        public void PrintAuthorsWithBooks_Optimized()
        {
            var authors = _context.Authors
                .Include(a => a.Books)
                .AsNoTracking()  // No change tracking
                .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($" - Book: {book.Title}");
                }
            }
        }



        public void LazyLoadFirstAuthorBooks()
        {
            var author = _context.Authors.FirstOrDefault();
            if (author != null)
            {
                Console.WriteLine($"Author: {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($" - Book: {book.Title}");
                }
            }
        }
    }