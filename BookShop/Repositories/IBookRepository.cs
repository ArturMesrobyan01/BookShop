using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Repositories
{
    public interface IBookRepository
    {
         Task<IList<Book>> GetAllBooks();
        Task<Book> GetCurrentBook(int ID);
        Task<Book> Create(Book book);
        Task DeleteBook(int ID);
      //  Task UpdateBook(Book book);

    }
}
