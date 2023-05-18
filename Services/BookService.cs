using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Service;

public class BookService
{
    public BookFilterViewModel Filter(List<Book>? source, string? searchString,
                                        int? userID, string? name, 
                                        string? author, string? genre )
    {
        var obj = from m in source select m;

        var userIDQuery = from m in source orderby m.UserID select m.UserID;
        var nameQuery = from m in source orderby m.Name select m.Name;
        var authorQuery = from m in source orderby m.Author select m.Author;
        var genreQuery = from m in source orderby m.Genre select m.Genre;

        if(!String.IsNullOrEmpty(searchString))
            {
                obj = obj.Where(m => 
                m.Name!.Contains(searchString) || 
                m.Author!.Contains(searchString) ||
                m.Description!.Contains(searchString) ||
                m.Genre!.Contains(searchString) ||
                m.UserID.ToString()!.Contains(searchString)
                );
            }
        if(userID != null)
            obj = obj.Where(m => m.UserID == userID);
        if(name != null)
            obj = obj.Where(m => m.Name == name);
        if(author != null)
            obj = obj.Where(m => m.Author == author);
        if(genre != null)
            obj = obj.Where(m => m.Genre == genre);

        return new BookFilterViewModel{
            UserIDs = userIDQuery.Distinct().ToList(),
            Names = nameQuery.Distinct().ToList(),
            Authors = authorQuery.Distinct().ToList(),
            Genres = genreQuery.Distinct().ToList(),
            Books = obj.ToList()
        };
    }
}
