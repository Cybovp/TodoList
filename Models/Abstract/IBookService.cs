namespace TodoList.Models.Abstract;

interface IBookService{
    IEnumerable<Book> GetBooks();
    void InsertBook(Book book);
    void UpdateBook(int id,Book book);
    void DeleteBook(int id,Book book);
    Book SingleBook(int id);

}