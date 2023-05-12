using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TodoList.Models;

public class Book
{
    [Key]
    [DisplayName("ID")]
    public int Id { get; set; }
    [Required]
    [DisplayName("User ID")]
    public int UserID { get; set; }
    [Required]
    [DisplayName("Name")]
    public string? Name { get; set; }
    [Required]
    [DisplayName("Author")]
    public string? Author { get; set; }
    [Required]
    [DisplayName("Description")]
    public string? Description { get; set; }
    [Required]
    [DisplayName("Genre")]
    public string? Genre { get; set; }
    [DisplayName("Created Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}