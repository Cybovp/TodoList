using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TodoList.Models;

public class User
{
    [Key]
    public int ID { get; set; }
    [Required]
    [DisplayName("Name")]
    public string? Name { get; set; }
    [Required]
    [DisplayName("Email")]
    public string? Email { get; set;}
    [Required]
    [DisplayName("Password")]
    public string? Password {get; set;}
    [DisplayName("Created Date")]
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
}