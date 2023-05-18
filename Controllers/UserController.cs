using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Produces("application/json", "application/xml")]
        public List<User> GetUsers()
        {
            var users = _db.Users.Include(c => c.Books).ToList();
            foreach(var user in users)
            {
                if (user.Books != null)
                {
                    foreach (var book in user.Books)
                    {
                        book.user = null;
                    }
                }
            }
            return users;
        }
        [HttpGet("{id}")]
        public async Task<User> GetCategory(long id)
        {
            var user = await _db.Users.Include(c => c.Books).FirstAsync(c => c.ID == id);
            if (user.Books != null)
            {
                foreach (var book in user.Books)
                {
                    book.user = null;
                }
            }
            return user;
        }
    }
}