using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BookController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IAsyncEnumerable<Book> GetBooks(){
            return  _db.Books.AsAsyncEnumerable();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            Book book = await _db.Books.FindAsync(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> SaveBook([FromBody] Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPut]
        public void UpdateBook(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var obj = _db.Books.Find(id);
            if(obj == null)
                return NotFound();
            _db.Books.Remove(obj);
            _db.SaveChanges();
            return Ok();
        }

    }
}