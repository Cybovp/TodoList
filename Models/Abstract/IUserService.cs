namespace TodoList.Models.Abstract;

interface IUserService{
    IEnumerable<Book> GetUsers();
    void InsertUser(Book book);
    void UpdateUser(int id,Book book);
    void DeleteUser(int id,Book book);
    Book SingleUser(int id);

}