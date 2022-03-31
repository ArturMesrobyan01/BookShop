using BookShop.Models;
using BookShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookShopController : Controller
    {

        private readonly IBookRepository _repository = new BookRepository();

        public BookShopController(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        [HttpGet]
        public async Task<IList<Book>> GetAllBooks()
        {
         
            return await _repository.GetAllBooks(); 
        }

        [HttpGet("id")]
        public async Task<Book> GetCurrentBook(int Id)
        {
            return await _repository.GetCurrentBook(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateNewBook([FromBody]Book book)
        {
            var newBook = await _repository.Create(book);
            return CreatedAtAction(nameof(GetAllBooks),new {id = newBook.Id },newBook);
        }

        [HttpDelete("id")]
        public IActionResult DeleteGivenBook(int Id)
        {
            return View();
        }



    }
}
