using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Repositories
{
    public class BookRepository : IBookRepository
    {
        private IList<Book> _books;
        private readonly BooksJsonCreater _creator;

        public BookRepository()
        {
            BooksJsonCreater.ItemGetter();
        }
        public async Task<Book> Create(Book book)
        {
            _books = await _creator.GetBooks();
            if(!_books.Contains(book))
            {
                _books.Add(book);
                _creator.SetBooks(_books);
            }
            return  book;
        }

        public async Task DeleteBook(int ID)
        {
            _books = await _creator.GetBooks();
            try
            {
                Book book = _books.Where<Book>(book => book.Id == ID).Single();
                _books.Remove(book);
                _creator.SetBooks(_books);
            }
            catch
            {
                throw new Exception("There is not any book with givven ID");
            }
        }

        public Task<IList<Book>> GetAllBooks()
        {
            
            return _creator.GetBooks();
        }

        public async Task<Book> GetCurrentBook(int ID)
        {
           try
           {
               _books = await _creator.GetBooks();
               Book book =_books.Where<Book>(book => book.Id == ID).Single();
               return book;
           }
            catch
            {
               throw new Exception("There is not any book with givven ID");
            }
        }

       
    }
}
