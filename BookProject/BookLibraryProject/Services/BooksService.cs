using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTOs;
using Models;

namespace Services
{
    public class BooksService
    {
        private DataContext _context;

        public BooksService(DataContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookDto bookDto)
        {
            var _book = new Book()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                PublishedAt = bookDto.PublishedAt,
                CoverUrl = bookDto.CoverUrl,
                Genre = bookDto.Genre,
                Author = bookDto.Author
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

        }

        public List<Book> GetAllBooks() => _context.Books.ToList();


        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId.ToString());

        public Book UpdateBookById(int bookId, BookDto book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId.ToString());
            if (_book != null)
            {

                _book.Title = book.Title;
                _book.PublishedAt = book.PublishedAt;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.Author = book.Author;

                _context.SaveChanges();
            }

            return _book;
        }


        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId.ToString());
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }




    }
}
