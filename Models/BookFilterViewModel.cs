using Microsoft.AspNetCore.Mvc.Rendering;

namespace TodoList.Models;
public class BookFilterViewModel
{
    public List<Book?> Books { get; set; } = new List<Book?>();

    public List<int?> UserIDs { get; set; } = new List<int?>();
    public List<string?> Names { get; set; } = new List<string?>();
    public List<string?> Authors { get; set; } = new List<string?>();
    public List<string?> Genres { get; set; } = new List<string?>();

    public int? UserID { get; set; }
    public string? name { get; set; }
    public string? author { get; set; }
    public string? genre { get; set; }

    public string? searchString { get; set; }
}