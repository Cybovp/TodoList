using TodoList.Data;
using TodoList.Models;
using TodoList.Models.Abstract;

namespace TodoList.Service;

public class BookService : IBookService
{
    private AppDbContext _db;
    public BookService(AppDbContext db){
        _db = db;
    }
    public void DeleteBook(int id, Book book)
    {
       try{
        var obj = _db.Books.Find(id);
        _db.Books.Remove(obj);
        _db.SaveChanges();
       }
       catch{
        throw;
       }
    }

    public IEnumerable<Book> GetBooks()
    {
        try{
            return _db.Books.ToList();
        }
        catch{
            throw;
        }
    }

    public void InsertBook(Book book)
    {
        try{
            _db.Books.Add(book);
            _db.SaveChanges();
        }
        catch{
            throw;
        }
    }

    public Book SingleBook(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(int id, Book book)
    {
        try{
            var oldBook = _db.Books.Find(id);
            if(oldBook == null)
            throw new NullReferenceException();

            var newbook = new Book{
               Id = oldBook.Id,
               UserID = book.UserID,
               Name = book.Name,
               Author = book.Author,
               Description = book.Description,
               Genre = book.Genre,
               CreatedDate = DateTime.UtcNow
            };

            _db.Books.Update(newbook);
            _db.SaveChanges();
        }
        catch{
            throw;
        }
    }
}
